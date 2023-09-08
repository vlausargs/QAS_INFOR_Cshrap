//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPortalAddConsumerFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSPortalAddConsumerFactory
	{
		public ISSSFSPortalAddConsumer Create(IApplicationDB appDB)
		{
			var _SSSFSPortalAddConsumer = new Logistics.FieldService.SSSFSPortalAddConsumer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPortalAddConsumerExt = timerfactory.Create<Logistics.FieldService.ISSSFSPortalAddConsumer>(_SSSFSPortalAddConsumer);
			
			return iSSSFSPortalAddConsumerExt;
		}
	}
}
