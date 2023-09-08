//PROJECT NAME: Logistics
//CLASS NAME: EFTImportAppmtFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class EFTImportAppmtFactory
	{
		public IEFTImportAppmt Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EFTImportAppmt = new Logistics.Vendor.EFTImportAppmt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEFTImportAppmtExt = timerfactory.Create<Logistics.Vendor.IEFTImportAppmt>(_EFTImportAppmt);
			
			return iEFTImportAppmtExt;
		}
	}
}
