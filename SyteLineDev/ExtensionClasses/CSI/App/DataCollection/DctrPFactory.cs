//PROJECT NAME: DataCollection
//CLASS NAME: DctrPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DctrPFactory
	{
		public IDctrP Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DctrP = new DataCollection.DctrP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDctrPExt = timerfactory.Create<DataCollection.IDctrP>(_DctrP);
			
			return iDctrPExt;
		}
	}
}
