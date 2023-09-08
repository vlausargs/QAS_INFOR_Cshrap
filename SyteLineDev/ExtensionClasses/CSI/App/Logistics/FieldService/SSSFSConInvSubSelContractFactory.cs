//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubSelContractFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubSelContractFactory
	{
		public ISSSFSConInvSubSelContract Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSConInvSubSelContract = new Logistics.FieldService.SSSFSConInvSubSelContract(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSConInvSubSelContractExt = timerfactory.Create<Logistics.FieldService.ISSSFSConInvSubSelContract>(_SSSFSConInvSubSelContract);
			
			return iSSSFSConInvSubSelContractExt;
		}
	}
}
