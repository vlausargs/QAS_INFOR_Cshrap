using PLLOC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Objects
{
    public class JPKV7MSalesControlFactory : IJPKV7MSalesControlFactory
    {
        public IJPKV7MSalesControl Create(int salesCount, decimal taxDues)
        {
            return new JPKV7MSalesControl(salesCount, taxDues);
        }
    }
}
