//PROJECT NAME: Production
//CLASS NAME: MatlGetInvparmsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class MatlGetInvparmsFactory
	{
		public IMatlGetInvparms Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MatlGetInvparms = new Production.MatlGetInvparms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMatlGetInvparmsExt = timerfactory.Create<Production.IMatlGetInvparms>(_MatlGetInvparms);
			
			return iMatlGetInvparmsExt;
		}
	}
}
