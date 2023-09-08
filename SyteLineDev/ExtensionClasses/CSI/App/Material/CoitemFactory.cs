//PROJECT NAME: Material
//CLASS NAME: CoitemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CoitemFactory
	{
		public ICoitem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Coitem = new Material.Coitem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoitemExt = timerfactory.Create<Material.ICoitem>(_Coitem);
			
			return iCoitemExt;
		}
	}
}
