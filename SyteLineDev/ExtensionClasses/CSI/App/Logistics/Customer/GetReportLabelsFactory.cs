//PROJECT NAME: CSICustomer
//CLASS NAME: GetReportLabelsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetReportLabelsFactory
	{
		public IGetReportLabels Create(IApplicationDB appDB)
		{
			var _GetReportLabels = new Logistics.Customer.GetReportLabels(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetReportLabelsExt = timerfactory.Create<Logistics.Customer.IGetReportLabels>(_GetReportLabels);
			
			return iGetReportLabelsExt;
		}
	}
}
