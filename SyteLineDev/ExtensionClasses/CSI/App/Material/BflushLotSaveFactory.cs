//PROJECT NAME: Material
//CLASS NAME: BflushLotSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class BflushLotSaveFactory
	{
		public IBflushLotSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _BflushLotSave = new Material.BflushLotSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBflushLotSaveExt = timerfactory.Create<Material.IBflushLotSave>(_BflushLotSave);
			
			return iBflushLotSaveExt;
		}
	}
}
