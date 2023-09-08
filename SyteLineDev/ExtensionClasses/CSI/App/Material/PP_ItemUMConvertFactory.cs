//PROJECT NAME: Material
//CLASS NAME: PP_ItemUMConvertFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class PP_ItemUMConvertFactory
	{
		public IPP_ItemUMConvert Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PP_ItemUMConvert = new Material.PP_ItemUMConvert(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_ItemUMConvertExt = timerfactory.Create<Material.IPP_ItemUMConvert>(_PP_ItemUMConvert);
			
			return iPP_ItemUMConvertExt;
		}
	}
}
