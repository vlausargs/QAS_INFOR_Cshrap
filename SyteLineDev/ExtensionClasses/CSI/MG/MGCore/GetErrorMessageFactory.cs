//PROJECT NAME: MG.MGCore
//CLASS NAME: GetErrorMessageFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class GetErrorMessageFactory : IGetErrorMessageFactory
    {
        public IGetErrorMessage Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _GetErrorMessage = new MG.MGCore.GetErrorMessage(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetErrorMessageExt = timerfactory.Create<MG.MGCore.IGetErrorMessage>(_GetErrorMessage);

            return iGetErrorMessageExt;
        }
    }
}
