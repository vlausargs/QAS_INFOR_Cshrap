using System;
using System.Collections.Generic;
using System.Text;
using PLLOC.Interfaces;

namespace PLLOC.Interfaces
{
    public interface IRptVAT
    {
        List<IJPKV7MPurchaseRegister> JPKV7MPurchaseRegisters { get; }
        IJPKV7MSalesControl JPKV7MSalesControl { get; set; }
        List<IJPK7MSalesRegister> JPK7MSalesRegisters { get; }
        IJPKV7MPurchaseControl JPKV7MPurchaseControl { get; set; }
    }
}