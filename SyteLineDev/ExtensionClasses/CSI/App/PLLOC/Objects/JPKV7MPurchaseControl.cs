using System;
using System.Collections.Generic;
using System.Text;
using PLLOC.Interfaces;

namespace PLLOC.Objects
{
    public class JPKV7MPurchaseControl : IJPKV7MPurchaseControl
    {
        public JPKV7MPurchaseControl(int purchaseCount, decimal inputTax)
        {
            PurchaseCount = purchaseCount;
            InputTax = inputTax;
        }

        public int PurchaseCount { get; }
        public decimal InputTax { get; }

    }
}
