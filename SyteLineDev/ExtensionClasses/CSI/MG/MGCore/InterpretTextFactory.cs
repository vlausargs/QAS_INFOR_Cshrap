//PROJECT NAME: MG.MGCore
//CLASS NAME: InterpretTextFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class InterpretTextFactory : IInterpretTextFactory
    {
        public IInterpretText Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _InterpretText = new InterpretText(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iInterpretTextExt = timerfactory.Create<MG.MGCore.IInterpretText>(_InterpretText);

            return iInterpretTextExt;
        }
    }
}
