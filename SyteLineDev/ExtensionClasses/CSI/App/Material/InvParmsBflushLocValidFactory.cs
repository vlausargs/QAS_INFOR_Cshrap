//PROJECT NAME: CSIMaterial
//CLASS NAME: InvParmsBflushLocValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class InvParmsBflushLocValidFactory
    {
        public IInvParmsBflushLocValid Create(IApplicationDB appDB)
        {
            var _InvParmsBflushLocValid = new InvParmsBflushLocValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iInvParmsBflushLocValidExt = timerfactory.Create<IInvParmsBflushLocValid>(_InvParmsBflushLocValid);

            return iInvParmsBflushLocValidExt;
        }
    }
}
