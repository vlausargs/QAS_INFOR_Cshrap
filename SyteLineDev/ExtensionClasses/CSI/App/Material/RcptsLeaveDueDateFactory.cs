//PROJECT NAME: Material
//CLASS NAME: RcptsLeaveDueDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class RcptsLeaveDueDateFactory
	{
		public IRcptsLeaveDueDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RcptsLeaveDueDate = new Material.RcptsLeaveDueDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRcptsLeaveDueDateExt = timerfactory.Create<Material.IRcptsLeaveDueDate>(_RcptsLeaveDueDate);
			
			return iRcptsLeaveDueDateExt;
		}
	}
}
