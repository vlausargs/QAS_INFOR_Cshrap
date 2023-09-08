//PROJECT NAME: Logistics
//CLASS NAME: DelVocuhAdjNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class DelVocuhAdjNumFactory
	{
		public IDelVocuhAdjNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DelVocuhAdjNum = new Logistics.Vendor.DelVocuhAdjNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDelVocuhAdjNumExt = timerfactory.Create<Logistics.Vendor.IDelVocuhAdjNum>(_DelVocuhAdjNum);
			
			return iDelVocuhAdjNumExt;
		}
	}
}
