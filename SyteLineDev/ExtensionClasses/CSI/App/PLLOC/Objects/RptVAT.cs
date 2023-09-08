using System;
using System.Collections.Generic;
using System.Text;
using PLLOC.Interfaces;

namespace PLLOC.Objects
{
    public class RptVAT : IRptVAT
    {
        public RptVAT()
        {
            this.JPK7MSalesRegisters = new List<IJPK7MSalesRegister>();
            this.JPKV7MPurchaseRegisters = new List<IJPKV7MPurchaseRegister>();
        }

        public List<IJPKV7MPurchaseRegister> JPKV7MPurchaseRegisters { get; }
        public IJPKV7MSalesControl JPKV7MSalesControl { get; set; }
        public List<IJPK7MSalesRegister> JPK7MSalesRegisters { get; }
        public IJPKV7MPurchaseControl JPKV7MPurchaseControl { get; set; }
    }
}
