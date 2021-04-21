using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
//
namespace BadBetaSoftware.Quick.Common
{
    public abstract class PersonEntity : ContactEntity
    {
        public const int FirstNameMaxLength = 50;
        public const int LastNameMaxLength = 50;
        public const int PrefixMaxLength = 8;
        public const int CredentialsMaxLength = 12;
        public const int TitleMaxLength = 128;
        //
        [Display(Name = "First")]
        [DataType(DataType.Text)]
        [Required]
        [StringLength(FirstNameMaxLength)]
        public string FirstName { get; set; }
        [StringLength(LastNameMaxLength)]
        public string LastName { get; set; }

        public string FirstLastName
        {
            get
            {
                var parts = new string[] { FirstName, LastName }.Where(s => !string.IsNullOrWhiteSpace(s));
                return string.Join(" ", parts);
            }
        }
        [StringLength(PrefixMaxLength)]
        public string Prefix { get; set; }
        [StringLength(CredentialsMaxLength)]
        public string Credentials { get; set; }
        [StringLength(TitleMaxLength)]
        public string Title { get; set; }
        public string FullName
        {
            get
            {
                var parts = new string[] { Prefix, FirstName, LastName }.Where(s => !string.IsNullOrWhiteSpace(s));
                return string.Join(" ", parts) + (!string.IsNullOrEmpty(Credentials) ? ", " + Credentials : "");
            }
        }
        protected PersonEntity() : base() { } //needed by orm
    }
}
