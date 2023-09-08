//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROTransGetEcCodeFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransGetEcCodeFactory
	{
		public ISSSFSSROTransGetEcCode Create(IApplicationDB appDB)
		{
			var _SSSFSSROTransGetEcCode = new Logistics.FieldService.Requests.SSSFSSROTransGetEcCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTransGetEcCodeExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTransGetEcCode>(_SSSFSSROTransGetEcCode);
			
			return iSSSFSSROTransGetEcCodeExt;
		}
	}
}
