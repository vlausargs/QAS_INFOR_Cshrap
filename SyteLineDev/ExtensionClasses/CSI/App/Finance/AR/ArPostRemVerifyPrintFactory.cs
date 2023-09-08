//PROJECT NAME: CSIFinance
//CLASS NAME: ArPostRemVerifyPrintFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArPostRemVerifyPrintFactory
    {
        public IArPostRemVerifyPrint Create(IApplicationDB appDB)
        {
            var _ArPostRemVerifyPrint = new ArPostRemVerifyPrint(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLCustdrftsExt = timerfactory.Create<IArPostRemVerifyPrint>(_ArPostRemVerifyPrint);

            return iSLCustdrftsExt;
        }
    }
}
