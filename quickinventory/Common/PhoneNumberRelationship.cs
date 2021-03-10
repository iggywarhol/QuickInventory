using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SimpleInventory.Common
{
    //[Table("EvPhoneNumbers")]
    public class PhoneNumberRelationship //: Entity<Guid>
    {
        public PhoneNumber PhoneNumber { get; set; }
        public string Type { get; set; }
        public PhoneNumberRelationship(string number, string type)
        {
            PhoneNumber = new PhoneNumber(number);
            Type = type;
        }
        public PhoneNumberRelationship(PhoneNumber phoneNumber, string type)
        {
            PhoneNumber = phoneNumber;
            Type = type;
        }
        private PhoneNumberRelationship() { } //needed by ORM
    }
}
