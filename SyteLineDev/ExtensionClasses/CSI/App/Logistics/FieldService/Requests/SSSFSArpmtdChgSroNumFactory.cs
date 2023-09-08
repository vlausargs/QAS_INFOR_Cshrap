//PROJECT NAME: Logistics
//CLASS NAME: SSSFSArpmtdChgSroNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSArpmtdChgSroNumFactory
	{
		public ISSSFSArpmtdChgSroNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSArpmtdChgSroNum = new Logistics.FieldService.Requests.SSSFSArpmtdChgSroNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSArpmtdChgSroNumExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSArpmtdChgSroNum>(_SSSFSArpmtdChgSroNum);
			
			return iSSSFSArpmtdChgSroNumExt;
		}
	}
}
