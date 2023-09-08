//PROJECT NAME: DataCollection
//CLASS NAME: DcPoUpdateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcPoUpdateFactory
	{
		public IDcPoUpdate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcPoUpdate = new DataCollection.DcPoUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcPoUpdateExt = timerfactory.Create<DataCollection.IDcPoUpdate>(_DcPoUpdate);
			
			return iDcPoUpdateExt;
		}
	}
}
