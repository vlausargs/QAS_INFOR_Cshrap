//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSGetIncSRODescFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetIncSRODescFactory
	{
		public ISSSFSGetIncSRODesc Create(IApplicationDB appDB)
		{
			var _SSSFSGetIncSRODesc = new Logistics.FieldService.SSSFSGetIncSRODesc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSGetIncSRODescExt = timerfactory.Create<Logistics.FieldService.ISSSFSGetIncSRODesc>(_SSSFSGetIncSRODesc);
			
			return iSSSFSGetIncSRODescExt;
		}
	}
}
