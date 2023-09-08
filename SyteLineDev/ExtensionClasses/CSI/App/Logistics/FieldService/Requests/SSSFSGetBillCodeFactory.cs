//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetBillCodeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSGetBillCodeFactory
	{
		public ISSSFSGetBillCode Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSGetBillCode = new Logistics.FieldService.Requests.SSSFSGetBillCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSGetBillCodeExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSGetBillCode>(_SSSFSGetBillCode);
			
			return iSSSFSGetBillCodeExt;
		}
	}
}
