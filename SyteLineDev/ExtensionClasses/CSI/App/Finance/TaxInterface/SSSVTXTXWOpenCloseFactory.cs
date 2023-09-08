//PROJECT NAME: CSITaxInterface
//CLASS NAME: SSSVTXTXWOpenCloseFactory.cs

using CSI.MG;

namespace CSI.Finance.TaxInterface
{
    public class SSSVTXTXWOpenCloseFactory
    {
        public ISSSVTXTXWOpenClose Create(IApplicationDB appDB)
        {
            var _SSSVTXTXWOpenClose = new SSSVTXTXWOpenClose(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSVTXTXWOpenCloseExt = timerfactory.Create<ISSSVTXTXWOpenClose>(_SSSVTXTXWOpenClose);

            return iSSSVTXTXWOpenCloseExt;
        }
    }
}

