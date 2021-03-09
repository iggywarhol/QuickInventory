using System;
using System.Linq;
using System.Globalization;
using Bogus;
using Bogus.Extensions;
using SimpleInventory.Helpers;

namespace SimpleInventory.Common
{

    /*
    FullAuditedEntity<Guid> , IMustHaveEvent
    namespace CustomReg.RegistrationEvents
    {
        public interface IMustHaveEvent : IEntity<Guid> //Event Entities must have Guids as primary keys
        {
            int EventId { get; set; }
        }
    }
    */

    public class Address : ValueObject<Address>
    {
        public string Line1 { get; private set; }
        public string Line2 { get; private set; }
        public string City { get; private set; }
        /// <summary>
        /// i.e. State, Region, Province, Territory, etc.
        /// </summary>
        public string AdministrativeDivision { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }
        public string TwoLetterISORegionName { get; private set; }
        public string ThreeLetterISORegionName { get; private set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public static readonly string UnitedStates = "United States";
        private static readonly string[] usa_aliases = {
            "USA",
            "US",
            "U.S.A",
            "UNITED STATES",
            "UNITED STATES OF AMERICA"};
        public string CityState
        {
            get
            {
                if (TwoLetterISORegionName == "US")
                {
                    return City != null ?
                        $"{City}, {AdministrativeDivision}" :
                        (AdministrativeDivision ?? Country) ?? string.Empty;
                }
                else
                {
                    return City != null ?
                        $"{City}, {Country}" :
                        Country ?? string.Empty;
                }
            }
        }
        public override string ToString()
        {
            var parts = new string[] { Line1, Line2, City, AdministrativeDivision, PostalCode, Country }.Where(p => !string.IsNullOrWhiteSpace(p));
            return string.Join(", ", parts);
        }
        public string ToHtml()
        {
            var parts = new string[] { Line1, Line2, City, AdministrativeDivision, PostalCode, Country }.Where(p => !string.IsNullOrWhiteSpace(p));
            return string.Join("<br>", parts);
        }
        public Address Copy()
        {
            var dto = new Address();
            dto.Line1 = this.Line1;
            dto.Line2 = this.Line2;
            dto.City = this.City;
            dto.AdministrativeDivision = this.AdministrativeDivision;
            dto.PostalCode = this.PostalCode;
            dto.Country = this.Country;
            //TwoLetterISORegionName = getRegionInfo(Country)?.TwoLetterISORegionName;
            //ThreeLetterISORegionName = getRegionInfo(Country)?.ThreeLetterISORegionName;
            return dto;
        }

        public Address(string line1, string line2, string city, string state, string zip, string country)
        {
            Line1 = line1;
            Line2 = line2;
            City = city;
            AdministrativeDivision = normalizeState(state);
            PostalCode = zip;
            Country = normalizeCountry(country);
            TryToCalculateOtherFields();
        }
        public bool IsValid => !string.IsNullOrWhiteSpace(AdministrativeDivision) && !string.IsNullOrWhiteSpace(Country);
        public Address() { } //needed by ORM
        public void Faker(bool usaonly)
        {
            var faker = new Faker("en");
            Line1 = faker.Address.StreetAddress();
            Line1 = null;
            City = faker.Address.City();
            AdministrativeDivision = normalizeState(faker.Address.State());
            PostalCode = faker.Address.ZipCode();
            Country = normalizeCountry(faker.Address.Country());
            Longitude = 0;
            Latitude = 0;
        }
        private void TryToCalculateOtherFields()
        {
            //This can be enhanced later.  Pretty naive implementation for now.
            TwoLetterISORegionName = getRegionInfo(Country)?.TwoLetterISORegionName;
            ThreeLetterISORegionName = getRegionInfo(Country)?.ThreeLetterISORegionName;
        }
        private static RegionInfo getRegionInfo(string countryEnglishName)
        {
            if (string.IsNullOrEmpty(countryEnglishName))
            {
                return null;
            }
            //Note: This is computed every time. This may be optimized
            var regionInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
               .Select(c => new RegionInfo(c.LCID))
               .Distinct()
               .ToList();
            RegionInfo r = regionInfos.Find(
                   region => region.EnglishName.ToLower().Equals(countryEnglishName.ToLower()));
            return r;
        }
        private static string normalizeCountry(string country)
        {
            if (country == null)
            {
                return null;
            }

            if (usa_aliases.Contains(country, StringComparer.OrdinalIgnoreCase))
            {
                return UnitedStates;
            }
            else
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                return textInfo.ToTitleCase(country);
            }
        }
        private static string normalizeState(string state)
        {
            if (state == null)
            {
                return null;
            }

            switch (state)
            {
                case "AL":
                    return "Alabama";
                case "AK":
                    return "Alaska";
                case "AS":
                    return "American Samoa";
                case "AZ":
                    return "Arizona";
                case "AR":
                    return "Arkansas";
                case "CA":
                    return "California";
                case "CO":
                    return "Colorado";
                case "CT":
                    return "Connecticut";
                case "DE":
                    return "Delaware";
                case "DC":
                    return "District Of Columbia";
                case "FM":
                    return "Federated States of Micronesia";
                case "FL":
                    return "Florida";
                case "GA":
                    return "Georgia";
                case "GU":
                    return "Guam";
                case "HI":
                    return "Hawaii";
                case "ID":
                    return "Idaho";
                case "IL":
                    return "Illinois";
                case "IN":
                    return "Indiana";
                case "IA":
                    return "Iowa";
                case "KS":
                    return "Kansas";
                case "KY":
                    return "Kentucky";
                case "LA":
                    return "Louisiana";
                case "ME":
                    return "Maine";
                case "MH":
                    return "Marshall Islands";
                case "MD":
                    return "Maryland";
                case "MA":
                    return "Massachusetts";
                case "MI":
                    return "Michigan";
                case "MN":
                    return "Minnesota";
                case "MS":
                    return "Mississippi";
                case "MO":
                    return "Missouri";
                case "MT":
                    return "Montana";
                case "NE":
                    return "Nebraska";
                case "NV":
                    return "Nevada";
                case "NH":
                    return "New Hampshire";
                case "NJ":
                    return "New Jersey";
                case "NM":
                    return "New Mexico";
                case "NY":
                    return "New York";
                case "NC":
                    return "North Carolina";
                case "ND":
                    return "North Dakota";
                case "MP":
                    return "Northern Mariana Islands";
                case "OH":
                    return "Ohio";
                case "OK":
                    return "Oklahoma";
                case "OR":
                    return "Oregon";
                case "PW":
                    return "Palau";
                case "PA":
                    return "Pennsylvania";
                case "PR":
                    return "Puerto Rico";
                case "RI":
                    return "Rhode Island";
                case "SC":
                    return "South Carolina";
                case "SD":
                    return "South Dakota";
                case "TN":
                    return "Tennessee";
                case "TX":
                    return "Texas";
                case "UT":
                    return "Utah";
                case "VT":
                    return "Vermont";
                case "VI":
                    return "Virgin Islands";
                case "VA":
                    return "Virginia";
                case "WA":
                    return "Washington";
                case "WV":
                    return "West Virginia";
                case "WI":
                    return "Wisconsin";
                case "WY":
                    return "Wyoming";
                default:
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    return textInfo.ToTitleCase(state);
            }
        }
    }
}
