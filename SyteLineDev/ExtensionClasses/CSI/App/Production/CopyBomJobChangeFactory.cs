//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomJobChangeFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class CopyBomJobChangeFactory
    {
        public ICopyBomJobChange Create(IApplicationDB appDB)
        {
            var _CopyBomJobChange = new Production.CopyBomJobChange(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCopyBomJobChangeExt = timerfactory.Create<Production.ICopyBomJobChange>(_CopyBomJobChange);

            return iCopyBomJobChangeExt;
        }
    }
}
