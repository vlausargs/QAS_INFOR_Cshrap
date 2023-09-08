//PROJECT NAME: DataCollection
//CLASS NAME: DcDcsfcCFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcDcsfcCFactory
	{
		public IDcDcsfcC Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcDcsfcC = new DataCollection.DcDcsfcC(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcDcsfcCExt = timerfactory.Create<DataCollection.IDcDcsfcC>(_DcDcsfcC);
			
			return iDcDcsfcCExt;
		}
	}
}
