//PROJECT NAME: DataCollection
//CLASS NAME: AutoLunchCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class AutoLunchCheckFactory
	{
		public IAutoLunchCheck Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AutoLunchCheck = new DataCollection.AutoLunchCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAutoLunchCheckExt = timerfactory.Create<DataCollection.IAutoLunchCheck>(_AutoLunchCheck);
			
			return iAutoLunchCheckExt;
		}
	}
}
