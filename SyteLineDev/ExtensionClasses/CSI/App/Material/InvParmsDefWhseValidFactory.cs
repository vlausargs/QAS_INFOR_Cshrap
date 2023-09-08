//PROJECT NAME: CSIMaterial
//CLASS NAME: InvParmsDefWhseValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class InvParmsDefWhseValidFactory
    {
        public IInvParmsDefWhseValid Create(IApplicationDB appDB)
        {
            var _InvParmsDefWhseValid = new InvParmsDefWhseValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iInvParmsDefWhseValidExt = timerfactory.Create<IInvParmsDefWhseValid>(_InvParmsDefWhseValid);

            return iInvParmsDefWhseValidExt;
        }
    }
}
