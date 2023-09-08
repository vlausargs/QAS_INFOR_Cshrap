//PROJECT NAME: DataCollection
//CLASS NAME: DcmatlPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcmatlPFactory
	{
		public IDcmatlP Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcmatlP = new DataCollection.DcmatlP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcmatlPExt = timerfactory.Create<DataCollection.IDcmatlP>(_DcmatlP);
			
			return iDcmatlPExt;
		}
	}
}
