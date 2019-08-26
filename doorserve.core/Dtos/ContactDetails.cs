using System;
using System.Collections.Generic;
using System.Text;

namespace Doorserve.Core.Dtos
{
    public class ContactDetails
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string CompanyLogo { get; set; }

        public string SocialLink { get; set; }
    }
}
