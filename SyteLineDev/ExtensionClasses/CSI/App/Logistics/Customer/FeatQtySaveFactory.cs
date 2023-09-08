//PROJECT NAME: Logistics
//CLASS NAME: FeatQtySaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class FeatQtySaveFactory
	{
		public IFeatQtySave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FeatQtySave = new Logistics.Customer.FeatQtySave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFeatQtySaveExt = timerfactory.Create<Logistics.Customer.IFeatQtySave>(_FeatQtySave);
			
			return iFeatQtySaveExt;
		}
	}
}
