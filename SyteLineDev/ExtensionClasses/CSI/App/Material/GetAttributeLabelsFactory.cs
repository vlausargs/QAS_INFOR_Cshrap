//PROJECT NAME: Material
//CLASS NAME: GetAttributeLabelsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetAttributeLabelsFactory
	{
		public IGetAttributeLabels Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetAttributeLabels = new Material.GetAttributeLabels(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAttributeLabelsExt = timerfactory.Create<Material.IGetAttributeLabels>(_GetAttributeLabels);
			
			return iGetAttributeLabelsExt;
		}
	}
}
