using PhoneNumbers;
using SimpleInventory.Helpers;
//
namespace SimpleInventory.Common
{
    public class PhoneNumber : ValueObject<PhoneNumber>
    {
        //International format that we use to store data
        public string E164 { get; private set; }
        //store for reporting convenience
        public string National { get; private set; }
        public string International { get; private set; }
        public string DialedFromUS { get; private set; }
        public bool HasValue => !string.IsNullOrWhiteSpace(E164);
        public PhoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number) == false)
            {
                var phoneUtil = PhoneNumberUtil.GetInstance();

                try
                {
                    var phoneNumber = phoneUtil.Parse(number, "US");

                    E164 = phoneUtil.Format(phoneNumber, PhoneNumberFormat.E164);
                    National = phoneUtil.Format(phoneNumber, PhoneNumberFormat.NATIONAL);
                    International = phoneUtil.Format(phoneNumber, PhoneNumberFormat.INTERNATIONAL);
                    DialedFromUS = phoneUtil.FormatOutOfCountryCallingNumber(phoneNumber, "US");
                }
                catch
                {
                    //swallow
                }
            }
        }
        private PhoneNumber() { } //needed by ORM
    }
}
