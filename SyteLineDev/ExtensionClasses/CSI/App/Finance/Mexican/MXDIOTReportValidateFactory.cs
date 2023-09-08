//PROJECT NAME: CSIVATTransfer
//CLASS NAME: MXDIOTReportValidateFactory.cs

using CSI.MG;

namespace CSI.Finance.Mexican
{
	public class MXDIOTReportValidateFactory
	{
		public IMXDIOTReportValidate Create(IApplicationDB appDB)
		{
			var _MXDIOTReportValidate = new Finance.Mexican.MXDIOTReportValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMXDIOTReportValidateExt = timerfactory.Create<Finance.Mexican.IMXDIOTReportValidate>(_MXDIOTReportValidate);
			
			return iMXDIOTReportValidateExt;
		}
	}
}
