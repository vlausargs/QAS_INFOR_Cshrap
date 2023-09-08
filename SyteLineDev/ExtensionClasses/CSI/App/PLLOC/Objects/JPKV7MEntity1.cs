using System;
using PLLOC.Interfaces;

namespace PLLOC.Objects
{
    public class JPKV7MEntity1 : IJPKV7MEntity1
    {
        public JPKV7MEntity1(string email, string name, string phone, string taxId)
        {
            Email = email;
            Name = name;
            Phone = phone;
            TaxId = taxId;
        }

        public string Email { get; }
        public string Name { get; }
        public string Phone { get; }
        public string TaxId { get; }
    }
}
