//PROJECT NAME: Logistics
//CLASS NAME: GetArparmLinesPerDocFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetArparmLinesPerDocFactory
	{
		public IGetArparmLinesPerDoc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetArparmLinesPerDoc = new Logistics.Customer.GetArparmLinesPerDoc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetArparmLinesPerDocExt = timerfactory.Create<Logistics.Customer.IGetArparmLinesPerDoc>(_GetArparmLinesPerDoc);
			
			return iGetArparmLinesPerDocExt;
		}
	}
}
