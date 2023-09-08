//PROJECT NAME: Logistics
//CLASS NAME: CoitemSavePreProcFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoitemSavePreProcFactory
	{
		public ICoitemSavePreProc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoitemSavePreProc = new Logistics.Customer.CoitemSavePreProc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoitemSavePreProcExt = timerfactory.Create<Logistics.Customer.ICoitemSavePreProc>(_CoitemSavePreProc);
			
			return iCoitemSavePreProcExt;
		}
	}
}
