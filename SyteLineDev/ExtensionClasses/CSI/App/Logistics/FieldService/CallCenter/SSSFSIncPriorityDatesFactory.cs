//PROJECT NAME: CSIFSPlusCallCenter
//CLASS NAME: SSSFSIncPriorityDatesFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSIncPriorityDatesFactory
	{
		public ISSSFSIncPriorityDates Create(IApplicationDB appDB)
		{
			var _SSSFSIncPriorityDates = new Logistics.FieldService.CallCenter.SSSFSIncPriorityDates(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSIncPriorityDatesExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSIncPriorityDates>(_SSSFSIncPriorityDates);
			
			return iSSSFSIncPriorityDatesExt;
		}
	}
}
