//PROJECT NAME: Material
//CLASS NAME: BflushSerialSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class BflushSerialSaveFactory
	{
		public IBflushSerialSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _BflushSerialSave = new Material.BflushSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBflushSerialSaveExt = timerfactory.Create<Material.IBflushSerialSave>(_BflushSerialSave);
			
			return iBflushSerialSaveExt;
		}
	}
}
