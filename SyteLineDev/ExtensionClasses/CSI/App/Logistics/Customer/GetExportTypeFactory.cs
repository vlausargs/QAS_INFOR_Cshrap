//PROJECT NAME: CSICustomer
//CLASS NAME: GetExportTypeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetExportTypeFactory
	{
		public IGetExportType Create(IApplicationDB appDB)
		{
			var _GetExportType = new Logistics.Customer.GetExportType(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetExportTypeExt = timerfactory.Create<Logistics.Customer.IGetExportType>(_GetExportType);
			
			return iGetExportTypeExt;
		}
	}
}
