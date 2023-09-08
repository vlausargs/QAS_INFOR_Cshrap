//PROJECT NAME: DataCollection
//CLASS NAME: DcAMatlmvFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcAMatlmvFactory
	{
		public IDcAMatlmv Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _DcAMatlmv = new DataCollection.DcAMatlmv(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcAMatlmvExt = timerfactory.Create<DataCollection.IDcAMatlmv>(_DcAMatlmv);
			
			return iDcAMatlmvExt;
		}
	}
}
