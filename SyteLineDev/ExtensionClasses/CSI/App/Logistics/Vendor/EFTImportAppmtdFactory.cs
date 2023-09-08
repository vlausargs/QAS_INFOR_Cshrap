//PROJECT NAME: Logistics
//CLASS NAME: EFTImportAppmtdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class EFTImportAppmtdFactory
	{
		public IEFTImportAppmtd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EFTImportAppmtd = new Logistics.Vendor.EFTImportAppmtd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEFTImportAppmtdExt = timerfactory.Create<Logistics.Vendor.IEFTImportAppmtd>(_EFTImportAppmtd);
			
			return iEFTImportAppmtdExt;
		}
	}
}
