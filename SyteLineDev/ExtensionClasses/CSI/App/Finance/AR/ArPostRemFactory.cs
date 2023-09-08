//PROJECT NAME: CSIFinance
//CLASS NAME: ArPostRemFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArPostRemFactory
    {
        public IArPostRem Create(IApplicationDB appDB)
        {
            var _ArPostRem = new ArPostRem(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLCustdrftsExt = timerfactory.Create<IArPostRem>(_ArPostRem);

            return iSLCustdrftsExt;
        }
    }
}
