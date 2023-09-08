//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetPostDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSGetPostDateFactory
	{
		public ISSSFSGetPostDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSGetPostDate = new Logistics.FieldService.Requests.SSSFSGetPostDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSGetPostDateExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSGetPostDate>(_SSSFSGetPostDate);
			
			return iSSSFSGetPostDateExt;
		}
	}
}
