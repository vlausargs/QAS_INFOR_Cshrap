//PROJECT NAME: Logistics
//CLASS NAME: SSSFSValidSeqFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSValidSeqFactory
	{
		public ISSSFSValidSeq Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSValidSeq = new Logistics.FieldService.Requests.SSSFSValidSeq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSValidSeqExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSValidSeq>(_SSSFSValidSeq);
			
			return iSSSFSValidSeqExt;
		}
	}
}
