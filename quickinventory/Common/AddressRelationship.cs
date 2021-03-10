using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//
namespace SimpleInventory.Common
{
    //[Table("EvAddresses")]
    public class AddressRelationship //: Entity<Guid>
    {
        public Address Address { get; set; }

        public string Type { get; set; }

        public AddressRelationship(Address address, string type)
        {
            Address = address;
            Type = type;
        }

        private AddressRelationship() { } //needed by ORM
    }
}
