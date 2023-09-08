//PROJECT NAME: DataCollection
//CLASS NAME: DcjrPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcjrPFactory
	{
		public IDcjrP Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcjrP = new DataCollection.DcjrP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcjrPExt = timerfactory.Create<DataCollection.IDcjrP>(_DcjrP);
			
			return iDcjrPExt;
		}
	}
}
