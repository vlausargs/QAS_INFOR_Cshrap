//PROJECT NAME: Logistics
//CLASS NAME: EFTImportEFTArpmntdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EFTImportEFTArpmntdFactory
	{
		public IEFTImportEFTArpmntd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EFTImportEFTArpmntd = new Logistics.Customer.EFTImportEFTArpmntd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEFTImportEFTArpmntdExt = timerfactory.Create<Logistics.Customer.IEFTImportEFTArpmntd>(_EFTImportEFTArpmntd);
			
			return iEFTImportEFTArpmntdExt;
		}
	}
}
