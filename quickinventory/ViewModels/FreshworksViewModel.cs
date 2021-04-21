using System;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;
using System.Data.Entity.Migrations;
using System.Data.Entity;
//
using Newtonsoft.Json;
//
using SimpleInventory.Models;
//
using BadBetaSoftware.Quick.Common;
using BadBetaSoftware.Quick.Common.Helpers;
//
using SimpleInventory.Interfaces;
using System.Windows;
//
namespace SimpleInventory.ViewModels
{
    class FreshworksViewModel : BaseViewModel
    {
        private fw_ConfigItem _selectedItem;
        private ObservableCollection<fw_ConfigItem> _items;
        private string _scancurrentdata;
        private string _scannewdata;
        private long _displayid;
        private string _name;
        SimpleInventoryContext db = new SimpleInventoryContext();
        private string fdDomain = "plclbj"; // your freshdesk domain
        private string apiKey = "BcZgRnHp3PLC8Hjrqur";
        private string apiPath = "/cmdb/items.json"; // API path
        private string responseBody = String.Empty;
        List<fw_ConfigItem> pagelist = null;
        //
        //
        public FreshworksViewModel(IChangeViewModel viewModelChanger, bb_accesscontrol_User userToEdit, ICreatedUser createdUserCallback) : base(viewModelChanger)
        {
            _items = new ObservableCollection<fw_ConfigItem>(db.fwInventory);
        }
        public FreshworksViewModel(IChangeViewModel viewModelChanger) : base(viewModelChanger)
        {
            _items = new ObservableCollection<fw_ConfigItem>(db.fwInventory);
        }
        public ObservableCollection<fw_ConfigItem> Items
        {
            get { return _items; }
            set { _items = value; NotifyPropertyChanged(); }
        }
        public string ScanCurrentData
        {
            get { return _scancurrentdata; }
            set { _scancurrentdata = value; NotifyPropertyChanged(); }
        }
        public long DisplayID
        {
            get { return _displayid; }
            set { _displayid = value; NotifyPropertyChanged(); }
        }
        public string ScanNewData
        {
            get { return _scannewdata; }
            set { _scannewdata = value; NotifyPropertyChanged(); }
        }
        public fw_ConfigItem SelectedItemGrid
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value; NotifyPropertyChanged();
            }
        }
        #region Buttons definition 
        public ICommand CmdGoToMainMenu
        {
            get { return new RelayCommand(GoToMainMenu); }
        }
        private void GoToMainMenu()
        {
            PopViewModel();
        }
        public ICommand CmdMouseItemSelect
        {
            get { return new RelayCommand<object>((param) => MouseItemSelect(param)); }
        }
        private void MouseItemSelect(object item)
        {
            fw_ConfigItem selectedItem = item as fw_ConfigItem;
            if (selectedItem != null)
            {
                ScanCurrentData = selectedItem.asset_tag;
                DisplayID = selectedItem.display_id;
                _name = selectedItem.name;
            }
        }
        public ICommand UpdateAssestTag
        {
            get { return new RelayCommand(UpdateAssestTagGo); }
        }
        private void UpdateAssestTagGo()
        {
            int f1 = db.fwInventory.ToList().FindIndex(m => m.asset_tag.Contains(_scancurrentdata));
            apiPath = "https://plclbj.freshservice.com/cmdb/items/" + _displayid + ".json";
            string payload = "{\"cmdb_config_item\": { \"name\": \"" + _name + "\",    \"asset_tag\": \"" + ScanNewData + "\"} }";
            FWAPI_UpdateAssest(fdDomain, apiKey, apiPath, payload);
        }
        public ICommand FreshWorksResync
        {
            get { return new RelayCommand(FreshWorksResyncGo); }
        }
        private void FreshWorksResyncGo()
        {
            db.fwInventory.SqlQuery("delete from FW_Inventory");
            db.SaveChanges();
            for (int i = 1; i < 20; i++)
            {
                FWAPI_ReadInventory(fdDomain, apiKey, apiPath, i, ref responseBody);
                if (responseBody.Length > 0)
                {
                    pagelist = JsonConvert.DeserializeObject<List<fw_ConfigItem>>(responseBody);
                    if (pagelist != null)
                    {
                        if (pagelist.Count != 0)
                        {
                            foreach (fw_ConfigItem item in pagelist)
                            {
                                db.fwInventory.AddOrUpdate(item);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    db.SaveChanges();
                }
                else
                {
                    break;
                }
            }
        }
        #endregion
        public void FWAPI_UpdateAssest(string fdDomain, string apiKey, string apiPath, string payload)
        {
            try
            {
                string str = payload;
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] arr = encoding.GetBytes(str);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(apiPath);
                string authInfo = apiKey + ":X";
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                request.Headers["Authorization"] = "Basic " + authInfo;
                request.Method = "PUT";
                request.ContentType = "application/json";
                request.ContentLength = arr.Length;
                request.KeepAlive = true;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(arr, 0, arr.Length);
                dataStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string returnString = response.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine(ex.Message);
            }
        }

        private void FWAPI_ReadInventory(string fdDomain, string apiKey, string apiPath, int page, ref string responseBody)
        {
            //This request is paginated to return only 50 assets per page.Append the parameter "page=[:page_no]" in the url to traverse through pages.
            //  curl -u BcZgRnHp3PLC8Hjrqur:X -H "Content-Type: application/json" -X GET ttps://plclbj.freshservice.com/helpdesk/tickets.json
            //  https://domain.freshservice.com/cmdb/items/113.json
            responseBody = String.Empty;
            //
            //
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://" + fdDomain + ".freshservice.com" + apiPath + "?page=" + page);
            request.ContentType = "application/json";
            request.Method = "GET";
            string authInfo = apiKey + ":X"; // It could be your username:password also.
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;
            try
            {
                Console.WriteLine("Submitting Request");
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    responseBody = reader.ReadToEnd();
                    responseBody.Replace('[', ' ');
                    responseBody.Replace(']', ' ');
                    reader.Close();
                    dataStream.Close();
                    Console.WriteLine("Status Code: {1} {0}", ((HttpWebResponse)response).StatusCode, (int)((HttpWebResponse)response).StatusCode);
                }
                Console.Out.WriteLine(responseBody);
            }
            catch (WebException ex)
            {
                Console.WriteLine("API Error: Your request is not successful. If you are not able to debug this error properly, mail us at support@freshdesk.com with the follwing X-Request-Id");
                Console.WriteLine("X-Request-Id: {0}", ex.Response.Headers["X-Request-Id"]);
                Console.WriteLine("Error Status Code : {1} {0}", ((HttpWebResponse)ex.Response).StatusCode, (int)((HttpWebResponse)ex.Response).StatusCode);
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    Console.Write("Error Response: ");
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine(ex.Message);
            }
        }
    }
}