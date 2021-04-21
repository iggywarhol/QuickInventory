using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BadBetaSoftware.Quick.Common
{
    /// <summary>
    /// Represents an entity that has contact information.
    /// </summary>
    /// 

    //namespace CustomReg.RegistrationEvents
    //{
     //   public interface IMustHaveEvent : IEntity<Guid> //Event Entities must have Guids as primary keys
     //   {
     //       int EventId { get; set; }
     //   }
    //}

    public abstract class ContactEntity  //: FullAuditedEntity<Guid>, IMustHaveEvent
    {
        //public const int ClientIdMaxLength = 128;
        public const int CompanyNameMaxLength = 128;
        public const int EmailAddressMaxLength = 128;

        //public int EventId { get; set; }
        //[ForeignKey(nameof(EventId))]
        //public virtual Event Event { get; set; }
        //[MaxLength(ClientIdMaxLength)]
        //public string ClientId { get; set; }

        [MaxLength(CompanyNameMaxLength)]
        public virtual string CompanyName { get; set; }
        [MaxLength(EmailAddressMaxLength)]
        public string EmailAddress { get; set; }
        [MaxLength(EmailAddressMaxLength)]
        public string EmailCC { get; set; }
        //public List<EmailAddressRelationship> OtherEmailAddresses { get; set; } = new List<EmailAddressRelationship>();

        //public PhoneNumber PhoneNumber { get; set; }
        //public List<PhoneNumberRelationship> OtherPhoneNumbers { get; set; } = new List<PhoneNumberRelationship>();

        public Address Address { get; set; }
        //public List<AddressRelationship> OtherAddresses { get; set; } = new List<AddressRelationship>();
        //public List<EmailLog> EmailLogs { get; set; } = new List<EmailLog>();

        //public string Notes { get; set; }
        //public string Notes2 { get; set; }
        //public string Notes3 { get; set; }

        //protected ContactEntity(Event regEvent)
        //{
        //     this.Event = regEvent;
        //       this.EventId = regEvent.Id;
        //      this.PhoneNumber = new PhoneNumber(null);
        //     this.Address = new Address();
        //  }
        protected ContactEntity() { } //needed by orm
    }

}
