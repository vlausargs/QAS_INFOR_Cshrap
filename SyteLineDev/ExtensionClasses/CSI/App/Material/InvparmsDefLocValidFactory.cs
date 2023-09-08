//PROJECT NAME: CSIMaterial
//CLASS NAME: InvparmsDefLocValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class InvparmsDefLocValidFactory
    {
        public IInvparmsDefLocValid Create(IApplicationDB appDB)
        {
            var _InvparmsDefLocValid = new InvparmsDefLocValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iInvparmsDefLocValidExt = timerfactory.Create<IInvparmsDefLocValid>(_InvparmsDefLocValid);

            return iInvparmsDefLocValidExt;
        }
    }
}
