//PROJECT NAME: CSIFinance
//CLASS NAME: LogVATReturnStampFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class LogVATReturnStampFactory
	{
		public ILogVATReturnStamp Create(IApplicationDB appDB)
		{
			var _LogVATReturnStamp = new Finance.LogVATReturnStamp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLogVATReturnStampExt = timerfactory.Create<Finance.ILogVATReturnStamp>(_LogVATReturnStamp);
			
			return iLogVATReturnStampExt;
		}
	}
}
