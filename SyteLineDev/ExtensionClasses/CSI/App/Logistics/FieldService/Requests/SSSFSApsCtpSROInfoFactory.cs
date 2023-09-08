//PROJECT NAME: Logistics
//CLASS NAME: SSSFSApsCtpSROInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSApsCtpSROInfoFactory
	{
		public ISSSFSApsCtpSROInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSApsCtpSROInfo = new Logistics.FieldService.Requests.SSSFSApsCtpSROInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSApsCtpSROInfoExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSApsCtpSROInfo>(_SSSFSApsCtpSROInfo);
			
			return iSSSFSApsCtpSROInfoExt;
		}
	}
}
