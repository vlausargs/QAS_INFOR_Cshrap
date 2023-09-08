//PROJECT NAME: DataCollection
//CLASS NAME: DcAPorcvFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcAPorcvFactory
	{
		public IDcAPorcv Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcAPorcv = new DataCollection.DcAPorcv(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcAPorcvExt = timerfactory.Create<DataCollection.IDcAPorcv>(_DcAPorcv);
			
			return iDcAPorcvExt;
		}
	}
}
