//PROJECT NAME: Logistics
//CLASS NAME: GetLatestPORcvdDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetLatestPORcvdDateFactory
	{
		public IGetLatestPORcvdDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetLatestPORcvdDate = new Logistics.Vendor.GetLatestPORcvdDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetLatestPORcvdDateExt = timerfactory.Create<Logistics.Vendor.IGetLatestPORcvdDate>(_GetLatestPORcvdDate);
			
			return iGetLatestPORcvdDateExt;
		}
	}
}
