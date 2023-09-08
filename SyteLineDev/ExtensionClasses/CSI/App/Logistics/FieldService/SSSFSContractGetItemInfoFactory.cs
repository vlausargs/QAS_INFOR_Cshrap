//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContractGetItemInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContractGetItemInfoFactory
	{
		public ISSSFSContractGetItemInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSContractGetItemInfo = new Logistics.FieldService.SSSFSContractGetItemInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSContractGetItemInfoExt = timerfactory.Create<Logistics.FieldService.ISSSFSContractGetItemInfo>(_SSSFSContractGetItemInfo);
			
			return iSSSFSContractGetItemInfoExt;
		}
	}
}
