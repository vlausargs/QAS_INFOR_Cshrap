using PLLOC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Interfaces
{
    public interface IJPKV7MPurchaseControlFactory
    {
        IJPKV7MPurchaseControl Create(int purchaseCount, decimal inputTax);
    }
}
