//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContLineGetContractInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContLineGetContractInfoFactory
	{
		public ISSSFSContLineGetContractInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSContLineGetContractInfo = new Logistics.FieldService.SSSFSContLineGetContractInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSContLineGetContractInfoExt = timerfactory.Create<Logistics.FieldService.ISSSFSContLineGetContractInfo>(_SSSFSContLineGetContractInfo);
			
			return iSSSFSContLineGetContractInfoExt;
		}
	}
}
