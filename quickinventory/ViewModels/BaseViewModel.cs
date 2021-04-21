using SimpleInventory.Interfaces;
using SimpleInventory.Models;
using BadBetaSoftware.Quick.Common.Helpers;

namespace SimpleInventory.ViewModels
{
    class BaseViewModel : ChangeNotifier, IChangeViewModel
    {
        IChangeViewModel _viewModelChanger;

        bb_accesscontrol_User _currentUser;

        public BaseViewModel(IChangeViewModel viewModelChanger)
        {
            ViewModelChanger = viewModelChanger;
        }

        public IChangeViewModel ViewModelChanger
        {
            get { return _viewModelChanger; }
            set { _viewModelChanger = value; }
        }

        public bb_accesscontrol_User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; NotifyPropertyChanged(); }
        }

        #region IChangeViewModel

        public void PopViewModel()
        {
            _viewModelChanger?.PopViewModel();
        }

        public void PushViewModel(BaseViewModel model)
        {
            _viewModelChanger?.PushViewModel(model);
        }

        #endregion
    }
}
