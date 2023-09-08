//PROJECT NAME: DataCollection
//CLASS NAME: DcmoveLogErrorFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcmoveLogErrorFactory
	{
		public IDcmoveLogError Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _DcmoveLogError = new DataCollection.DcmoveLogError(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcmoveLogErrorExt = timerfactory.Create<DataCollection.IDcmoveLogError>(_DcmoveLogError);
			
			return iDcmoveLogErrorExt;
		}
	}
}
