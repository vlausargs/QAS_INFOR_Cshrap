//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSroCopyDefaultFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroCopyDefaultFactory
	{
		public ISSSFSSroCopyDefault Create(IApplicationDB appDB)
		{
			var _SSSFSSroCopyDefault = new Logistics.FieldService.Requests.SSSFSSroCopyDefault(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroCopyDefaultExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroCopyDefault>(_SSSFSSroCopyDefault);
			
			return iSSSFSSroCopyDefaultExt;
		}
	}
}
