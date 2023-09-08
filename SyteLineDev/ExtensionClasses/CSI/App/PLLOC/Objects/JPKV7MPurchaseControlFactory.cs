using System;
using System.Collections.Generic;
using System.Text;
using PLLOC.Interfaces;

namespace PLLOC.Objects
{
    public class JPKV7MPurchaseControlFactory : IJPKV7MPurchaseControlFactory
    {
        public IJPKV7MPurchaseControl Create(int purchaseCount, decimal inputTax)
        {
            return new JPKV7MPurchaseControl(purchaseCount, inputTax);
        }
    }
}
