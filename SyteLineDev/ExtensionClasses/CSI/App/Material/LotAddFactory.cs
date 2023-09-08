//PROJECT NAME: Material
//CLASS NAME: LotAddFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class LotAddFactory
	{
		public ILotAdd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LotAdd = new Material.LotAdd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLotAddExt = timerfactory.Create<Material.ILotAdd>(_LotAdd);
			
			return iLotAddExt;
		}
	}
}
