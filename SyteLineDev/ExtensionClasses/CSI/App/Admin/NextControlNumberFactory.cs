//PROJECT NAME: Admin
//CLASS NAME: NextControlNumberFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
	public class NextControlNumberFactory
	{
		public INextControlNumber Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _NextControlNumber = new Admin.NextControlNumber(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iNextControlNumberExt = timerfactory.Create<Admin.INextControlNumber>(_NextControlNumber);
			
			return iNextControlNumberExt;
		}
	}
}
