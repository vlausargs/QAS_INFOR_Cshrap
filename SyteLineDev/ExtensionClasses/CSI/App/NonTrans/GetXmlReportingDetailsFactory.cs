//PROJECT NAME: NonTrans
//CLASS NAME: GetXmlReportingDetailsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.NonTrans
{
	public class GetXmlReportingDetailsFactory
	{
		public IGetXmlReportingDetails Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetXmlReportingDetails = new NonTrans.GetXmlReportingDetails(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetXmlReportingDetailsExt = timerfactory.Create<NonTrans.IGetXmlReportingDetails>(_GetXmlReportingDetails);
			
			return iGetXmlReportingDetailsExt;
		}
	}
}
