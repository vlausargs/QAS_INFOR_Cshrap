//PROJECT NAME: MG.MGCore
//CLASS NAME: GetUserPrivilegesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class GetUserPrivilegesFactory : IGetUserPrivilegesFactory
    {
        public IGetUserPrivileges Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _GetUserPrivileges = new GetUserPrivileges(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetUserPrivilegesExt = timerfactory.Create<MG.MGCore.IGetUserPrivileges>(_GetUserPrivileges);

            return iGetUserPrivilegesExt;
        }
    }
}
