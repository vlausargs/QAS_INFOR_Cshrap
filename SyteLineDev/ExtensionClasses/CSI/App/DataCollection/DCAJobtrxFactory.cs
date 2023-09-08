//PROJECT NAME: DataCollection
//CLASS NAME: DCAJobtrxFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DCAJobtrxFactory
	{
		public IDCAJobtrx Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _DCAJobtrx = new DataCollection.DCAJobtrx(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDCAJobtrxExt = timerfactory.Create<DataCollection.IDCAJobtrx>(_DCAJobtrx);
			
			return iDCAJobtrxExt;
		}
	}
}
