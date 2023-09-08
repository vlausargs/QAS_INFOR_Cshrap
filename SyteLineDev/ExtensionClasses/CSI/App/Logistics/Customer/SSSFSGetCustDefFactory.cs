//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetCustDefFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class SSSFSGetCustDefFactory
	{
		public ISSSFSGetCustDef Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSGetCustDef = new Logistics.Customer.SSSFSGetCustDef(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSGetCustDefExt = timerfactory.Create<Logistics.Customer.ISSSFSGetCustDef>(_SSSFSGetCustDef);
			
			return iSSSFSGetCustDefExt;
		}
	}
}
