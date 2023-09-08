//PROJECT NAME: DataCollection
//CLASS NAME: DcATimeatFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcATimeatFactory
	{
		public IDcATimeat Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcATimeat = new DataCollection.DcATimeat(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcATimeatExt = timerfactory.Create<DataCollection.IDcATimeat>(_DcATimeat);
			
			return iDcATimeatExt;
		}
	}
}
