//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROTransWipRemainFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransWipRemainFactory
	{
		public ISSSFSSROTransWipRemain Create(IApplicationDB appDB)
		{
			var _SSSFSSROTransWipRemain = new Logistics.FieldService.Requests.SSSFSSROTransWipRemain(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTransWipRemainExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTransWipRemain>(_SSSFSSROTransWipRemain);
			
			return iSSSFSSROTransWipRemainExt;
		}
	}
}
