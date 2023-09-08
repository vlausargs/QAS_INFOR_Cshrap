//PROJECT NAME: DataCollection
//CLASS NAME: DcpoPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcpoPFactory
	{
		public IDcpoP Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcpoP = new DataCollection.DcpoP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcpoPExt = timerfactory.Create<DataCollection.IDcpoP>(_DcpoP);
			
			return iDcpoPExt;
		}
	}
}
