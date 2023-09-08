//PROJECT NAME: Logistics
//CLASS NAME: SaveAptrxpFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class SaveAptrxpFactory
	{
		public ISaveAptrxp Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SaveAptrxp = new Logistics.Vendor.SaveAptrxp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSaveAptrxpExt = timerfactory.Create<Logistics.Vendor.ISaveAptrxp>(_SaveAptrxp);
			
			return iSaveAptrxpExt;
		}
	}
}
