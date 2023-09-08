//PROJECT NAME: DataCollection
//CLASS NAME: DcwcPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcwcPFactory
	{
		public IDcwcP Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcwcP = new DataCollection.DcwcP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcwcPExt = timerfactory.Create<DataCollection.IDcwcP>(_DcwcP);
			
			return iDcwcPExt;
		}
	}
}
