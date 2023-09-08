//PROJECT NAME: DataCollection
//CLASS NAME: DcCycleValLocFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcCycleValLocFactory
	{
		public IDcCycleValLoc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcCycleValLoc = new DataCollection.DcCycleValLoc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcCycleValLocExt = timerfactory.Create<DataCollection.IDcCycleValLoc>(_DcCycleValLoc);
			
			return iDcCycleValLocExt;
		}
	}
}
