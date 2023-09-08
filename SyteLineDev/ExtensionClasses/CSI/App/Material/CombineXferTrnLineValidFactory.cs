//PROJECT NAME: Material
//CLASS NAME: CombineXferTrnLineValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CombineXferTrnLineValidFactory
	{
		public ICombineXferTrnLineValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CombineXferTrnLineValid = new Material.CombineXferTrnLineValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCombineXferTrnLineValidExt = timerfactory.Create<Material.ICombineXferTrnLineValid>(_CombineXferTrnLineValid);
			
			return iCombineXferTrnLineValidExt;
		}
	}
}
