//PROJECT NAME: Logistics
//CLASS NAME: SSSFSDrpGenFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSDrpGenFactory
	{
		public ISSSFSDrpGen Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSDrpGen = new Logistics.FieldService.Requests.SSSFSDrpGen(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSDrpGenExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSDrpGen>(_SSSFSDrpGen);
			
			return iSSSFSDrpGenExt;
		}
	}
}
