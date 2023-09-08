//PROJECT NAME: Logistics
//CLASS NAME: CheckPrcRecordFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CheckPrcRecordFactory
	{
		public ICheckPrcRecord Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckPrcRecord = new Logistics.Customer.CheckPrcRecord(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckPrcRecordExt = timerfactory.Create<Logistics.Customer.ICheckPrcRecord>(_CheckPrcRecord);
			
			return iCheckPrcRecordExt;
		}
	}
}
