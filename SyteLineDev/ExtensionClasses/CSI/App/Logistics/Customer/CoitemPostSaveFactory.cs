//PROJECT NAME: Logistics
//CLASS NAME: CoitemPostSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoitemPostSaveFactory
	{
		public ICoitemPostSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoitemPostSave = new Logistics.Customer.CoitemPostSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoitemPostSaveExt = timerfactory.Create<Logistics.Customer.ICoitemPostSave>(_CoitemPostSave);
			
			return iCoitemPostSaveExt;
		}
	}
}
