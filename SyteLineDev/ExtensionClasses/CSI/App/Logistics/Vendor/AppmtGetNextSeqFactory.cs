//PROJECT NAME: Logistics
//CLASS NAME: AppmtGetNextSeqFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AppmtGetNextSeqFactory
	{
		public IAppmtGetNextSeq Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AppmtGetNextSeq = new Logistics.Vendor.AppmtGetNextSeq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppmtGetNextSeqExt = timerfactory.Create<Logistics.Vendor.IAppmtGetNextSeq>(_AppmtGetNextSeq);
			
			return iAppmtGetNextSeqExt;
		}
	}
}
