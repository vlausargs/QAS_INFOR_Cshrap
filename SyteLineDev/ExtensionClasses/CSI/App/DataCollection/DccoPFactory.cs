//PROJECT NAME: DataCollection
//CLASS NAME: DccoPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DccoPFactory
	{
		public IDccoP Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DccoP = new DataCollection.DccoP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDccoPExt = timerfactory.Create<DataCollection.IDccoP>(_DccoP);
			
			return iDccoPExt;
		}
	}
}
