//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvFactory
	{
		public ISSSFSConInv Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSConInv = new Logistics.FieldService.SSSFSConInv(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSConInvExt = timerfactory.Create<Logistics.FieldService.ISSSFSConInv>(_SSSFSConInv);
			
			return iSSSFSConInvExt;
		}
	}
}
