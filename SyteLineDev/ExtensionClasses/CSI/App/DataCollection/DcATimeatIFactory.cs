//PROJECT NAME: DataCollection
//CLASS NAME: DcATimeatIFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcATimeatIFactory
	{
		public IDcATimeatI Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcATimeatI = new DataCollection.DcATimeatI(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcATimeatIExt = timerfactory.Create<DataCollection.IDcATimeatI>(_DcATimeatI);
			
			return iDcATimeatIExt;
		}
	}
}
