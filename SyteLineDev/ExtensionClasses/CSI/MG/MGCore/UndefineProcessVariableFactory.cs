//PROJECT NAME: MG.MGCore
//CLASS NAME: UndefineProcessVariableFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class UndefineProcessVariableFactory: IUndefineProcessVariableFactory
	{
		public IUndefineProcessVariable Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UndefineProcessVariable = new UndefineProcessVariable(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUndefineProcessVariableExt = timerfactory.Create<MG.MGCore.IUndefineProcessVariable>(_UndefineProcessVariable);

			return iUndefineProcessVariableExt;
		}
	}
}
