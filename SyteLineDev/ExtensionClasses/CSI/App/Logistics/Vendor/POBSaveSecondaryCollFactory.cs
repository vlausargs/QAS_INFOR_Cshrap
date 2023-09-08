//PROJECT NAME: Logistics
//CLASS NAME: POBSaveSecondaryCollFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class POBSaveSecondaryCollFactory
	{
		public IPOBSaveSecondaryColl Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _POBSaveSecondaryColl = new Logistics.Vendor.POBSaveSecondaryColl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPOBSaveSecondaryCollExt = timerfactory.Create<Logistics.Vendor.IPOBSaveSecondaryColl>(_POBSaveSecondaryColl);
			
			return iPOBSaveSecondaryCollExt;
		}
	}
}
