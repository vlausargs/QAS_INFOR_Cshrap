using PLLOC.Interfaces;

namespace PLLOC.Objects
{
    public class JPKV7MSalesControl : IJPKV7MSalesControl
    {

        public JPKV7MSalesControl(int salesCount, decimal taxDues)
        {
            SalesCount = salesCount;
            TaxDues = taxDues;
        }

        public int SalesCount { get; }

        public decimal TaxDues { get; }
    }
}