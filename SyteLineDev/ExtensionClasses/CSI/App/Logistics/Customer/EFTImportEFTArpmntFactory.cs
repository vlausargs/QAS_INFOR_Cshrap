//PROJECT NAME: Logistics
//CLASS NAME: EFTImportEFTArpmntFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EFTImportEFTArpmntFactory
	{
		public IEFTImportEFTArpmnt Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EFTImportEFTArpmnt = new Logistics.Customer.EFTImportEFTArpmnt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEFTImportEFTArpmntExt = timerfactory.Create<Logistics.Customer.IEFTImportEFTArpmnt>(_EFTImportEFTArpmnt);
			
			return iEFTImportEFTArpmntExt;
		}
	}
}
