using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Interfaces
{
    public interface IJPKV7MSalesControlFactory
    {
        IJPKV7MSalesControl Create(int salesCount, decimal taxDues);
    }
}
