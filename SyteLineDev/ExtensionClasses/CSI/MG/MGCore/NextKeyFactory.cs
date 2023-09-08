//PROJECT NAME: MG.MGCore
//CLASS NAME: NextKeyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class NextKeyFactory : INextKeyFactory
    {
        public INextKey Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _NextKey = new NextKey(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iNextKeyExt = timerfactory.Create<MG.MGCore.INextKey>(_NextKey);

            return iNextKeyExt;
        }
    }
}
