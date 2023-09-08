//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedValidSchedDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedValidSchedDateFactory
	{
		public ISSSFSSchedValidSchedDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSchedValidSchedDate = new Logistics.FieldService.Partner.SSSFSSchedValidSchedDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSchedValidSchedDateExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSSchedValidSchedDate>(_SSSFSSchedValidSchedDate);
			
			return iSSSFSSchedValidSchedDateExt;
		}
	}
}
