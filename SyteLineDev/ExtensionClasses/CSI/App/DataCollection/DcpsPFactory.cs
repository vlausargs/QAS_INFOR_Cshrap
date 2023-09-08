//PROJECT NAME: DataCollection
//CLASS NAME: DcpsPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcpsPFactory
	{
		public IDcpsP Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcpsP = new DataCollection.DcpsP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcpsPExt = timerfactory.Create<DataCollection.IDcpsP>(_DcpsP);
			
			return iDcpsPExt;
		}
	}
}
