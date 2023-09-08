//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContractDefaultsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContractDefaultsFactory
	{
		public ISSSFSContractDefaults Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSContractDefaults = new Logistics.FieldService.SSSFSContractDefaults(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSContractDefaultsExt = timerfactory.Create<Logistics.FieldService.ISSSFSContractDefaults>(_SSSFSContractDefaults);
			
			return iSSSFSContractDefaultsExt;
		}
	}
}
