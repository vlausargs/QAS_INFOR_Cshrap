//PROJECT NAME: DataCollection
//CLASS NAME: DcAPsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcAPsFactory
	{
		public IDcAPs Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcAPs = new DataCollection.DcAPs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcAPsExt = timerfactory.Create<DataCollection.IDcAPs>(_DcAPs);
			
			return iDcAPsExt;
		}
	}
}
