//PROJECT NAME: MG.MGCore
//CLASS NAME: BuildXMLFilterStringFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class BuildXMLFilterStringFactory : IBuildXMLFilterStringFactory
    {
        public IBuildXMLFilterString Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _BuildXMLFilterString = new BuildXMLFilterString(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iBuildXMLFilterStringExt = timerfactory.Create<MG.MGCore.IBuildXMLFilterString>(_BuildXMLFilterString);

            return iBuildXMLFilterStringExt;
        }
    }
}
