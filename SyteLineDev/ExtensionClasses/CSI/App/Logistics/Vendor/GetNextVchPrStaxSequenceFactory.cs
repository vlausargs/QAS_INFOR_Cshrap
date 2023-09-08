//PROJECT NAME: Logistics
//CLASS NAME: GetNextVchPrStaxSequenceFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetNextVchPrStaxSequenceFactory
	{
		public IGetNextVchPrStaxSequence Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetNextVchPrStaxSequence = new Logistics.Vendor.GetNextVchPrStaxSequence(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetNextVchPrStaxSequenceExt = timerfactory.Create<Logistics.Vendor.IGetNextVchPrStaxSequence>(_GetNextVchPrStaxSequence);
			
			return iGetNextVchPrStaxSequenceExt;
		}
	}
}
