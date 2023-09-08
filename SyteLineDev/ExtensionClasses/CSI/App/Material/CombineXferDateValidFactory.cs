//PROJECT NAME: Material
//CLASS NAME: CombineXferDateValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CombineXferDateValidFactory
	{
		public ICombineXferDateValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CombineXferDateValid = new Material.CombineXferDateValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCombineXferDateValidExt = timerfactory.Create<Material.ICombineXferDateValid>(_CombineXferDateValid);
			
			return iCombineXferDateValidExt;
		}
	}
}
