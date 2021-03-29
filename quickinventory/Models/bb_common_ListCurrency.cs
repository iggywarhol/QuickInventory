using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
    public class bb_common_ListCurrency
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(25)]
        public string Abbreviation { get; set; }
        [MaxLength(2)]
        public string Symbol { get; set; }
        public decimal ConversionRateToUSD { get; set; } // One X to 1 USD = formula
        public bool IsDefaultCurrency { get; set; }
        public string NameWithSymbol { get { return Name + " (" + Symbol + ")"; } }
        [Required]
        public System.DateTime CreatedDate { get; set; }
        [ForeignKey("Tenant")]
        public long Tenant_ID { get; set; }
        public bb_accesscontrol_Tenant Tenant { get; set; }
        /*
        public static List<Currency> LoadCurrencies(string whereClause = "", List<Tuple<string, string>> whereParams = null)
        {
            var items = new List<Currency>();
            string query = "" +
                "SELECT ID, Name, Abbreviation, Symbol, ConversionRateToUSD, IsDefaultCurrency " +
                "FROM Currencies " +
                (string.IsNullOrEmpty(whereClause) ? "" : whereClause) + " " +
                "ORDER BY lower(Name), Abbreviation, ConversionRateToUSD";

            var dbHelper = new DatabaseHelper();
            using (var conn = dbHelper.GetDatabaseConnection())
            {
                using (var command = dbHelper.GetSQLiteCommand(conn))
                {
                    command.CommandText = query;
                    if (!string.IsNullOrEmpty(whereClause) && whereParams != null)
                    {
                        foreach (Tuple<string, string> keyValuePair in whereParams)
                        {
                            command.Parameters.AddWithValue(keyValuePair.Item1, keyValuePair.Item2);
                        }
                    }
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Currency();
                            item.ID = dbHelper.ReadInt(reader, "ID");
                            item.Name = dbHelper.ReadString(reader, "Name");
                            item.Abbreviation = dbHelper.ReadString(reader, "Abbreviation");
                            item.Symbol = dbHelper.ReadString(reader, "Symbol");
                            item.ConversionRateToUSD = dbHelper.ReadDecimal(reader, "ConversionRateToUSD");
                            item.IsDefaultCurrency = dbHelper.ReadBool(reader, "IsDefaultCurrency");
                            items.Add(item);
                        }
                        reader.Close();
                    }
                }
                conn.Close();
            }
            return items;
        }
        */
        //public static Dictionary<int, Currency> GetKeyValueCurrencyList(string whereClause = "", List<Tuple<string, string>> whereParams = null)
        //{
        // var currencies = LoadCurrencies(whereClause, whereParams);
        // return ConvertListToKeyValueList(currencies);
        //}

        //public static Dictionary<int, Currency> ConvertListToKeyValueList(List<Currency> currencies)
        //{
        //    var dictionary = new Dictionary<int, Currency>();
        //    foreach (Currency currency in currencies)
        //    {
        //        dictionary.Add(currency.ID, currency);
        //    }
        //    return dictionary;
        //}
    }
}
