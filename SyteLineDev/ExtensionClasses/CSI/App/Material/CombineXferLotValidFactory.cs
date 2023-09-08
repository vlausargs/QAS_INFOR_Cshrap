//PROJECT NAME: Material
//CLASS NAME: CombineXferLotValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CombineXferLotValidFactory
	{
		public ICombineXferLotValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CombineXferLotValid = new Material.CombineXferLotValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCombineXferLotValidExt = timerfactory.Create<Material.ICombineXferLotValid>(_CombineXferLotValid);
			
			return iCombineXferLotValidExt;
		}
	}
}
