//PROJECT NAME: Logistics
//CLASS NAME: SSSFSDispatchEventFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSDispatchEventFactory
	{
		public ISSSFSDispatchEvent Create(IApplicationDB appDB)
		{
			var _SSSFSDispatchEvent = new Logistics.FieldService.Partner.SSSFSDispatchEvent(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSDispatchEventExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSDispatchEvent>(_SSSFSDispatchEvent);
			
			return iSSSFSDispatchEventExt;
		}
	}
}
