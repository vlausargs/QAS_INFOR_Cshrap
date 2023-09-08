//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContractGetUnitInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContractGetUnitInfoFactory
	{
		public ISSSFSContractGetUnitInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSContractGetUnitInfo = new Logistics.FieldService.SSSFSContractGetUnitInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSContractGetUnitInfoExt = timerfactory.Create<Logistics.FieldService.ISSSFSContractGetUnitInfo>(_SSSFSContractGetUnitInfo);
			
			return iSSSFSContractGetUnitInfoExt;
		}
	}
}
