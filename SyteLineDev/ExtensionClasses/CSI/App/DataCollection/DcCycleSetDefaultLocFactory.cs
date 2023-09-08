//PROJECT NAME: DataCollection
//CLASS NAME: DcCycleSetDefaultLocFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcCycleSetDefaultLocFactory
	{
		public IDcCycleSetDefaultLoc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcCycleSetDefaultLoc = new DataCollection.DcCycleSetDefaultLoc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcCycleSetDefaultLocExt = timerfactory.Create<DataCollection.IDcCycleSetDefaultLoc>(_DcCycleSetDefaultLoc);
			
			return iDcCycleSetDefaultLocExt;
		}
	}
}
