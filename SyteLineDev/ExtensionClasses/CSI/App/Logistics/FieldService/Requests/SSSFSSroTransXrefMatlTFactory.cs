//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSroTransXrefMatlTFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroTransXrefMatlTFactory
	{
		public ISSSFSSroTransXrefMatlT Create(IApplicationDB appDB)
		{
			var _SSSFSSroTransXrefMatlT = new Logistics.FieldService.Requests.SSSFSSroTransXrefMatlT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroTransXrefMatlTExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroTransXrefMatlT>(_SSSFSSroTransXrefMatlT);
			
			return iSSSFSSroTransXrefMatlTExt;
		}
	}
}
