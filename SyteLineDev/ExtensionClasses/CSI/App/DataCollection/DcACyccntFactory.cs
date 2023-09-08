//PROJECT NAME: DataCollection
//CLASS NAME: DcACyccntFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcACyccntFactory
	{
		public IDcACyccnt Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcACyccnt = new DataCollection.DcACyccnt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcACyccntExt = timerfactory.Create<DataCollection.IDcACyccnt>(_DcACyccnt);
			
			return iDcACyccntExt;
		}
	}
}
