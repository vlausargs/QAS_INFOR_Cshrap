//PROJECT NAME: Finance
//CLASS NAME: PerGetFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class PerGetFactory : IPerGetFactory
    {
		public IPerGet Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PerGet = new Finance.PerGet(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPerGetExt = timerfactory.Create<Finance.IPerGet>(_PerGet);
			
			return iPerGetExt;
		}

		public IPerGet Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _PerGet = new Finance.PerGet(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPerGetExt = timerfactory.Create<Finance.IPerGet>(_PerGet);

			return iPerGetExt;
		}
	}
}
