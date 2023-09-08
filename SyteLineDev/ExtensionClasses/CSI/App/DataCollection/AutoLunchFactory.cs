//PROJECT NAME: DataCollection
//CLASS NAME: AutoLunchFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class AutoLunchFactory
	{
		public IAutoLunch Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AutoLunch = new DataCollection.AutoLunch(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAutoLunchExt = timerfactory.Create<DataCollection.IAutoLunch>(_AutoLunch);
			
			return iAutoLunchExt;
		}
	}
}
