//PROJECT NAME: Material
//CLASS NAME: MsmpFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class MsmpFactory
	{
		public IMsmp Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Msmp = new Material.Msmp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMsmpExt = timerfactory.Create<Material.IMsmp>(_Msmp);
			
			return iMsmpExt;
		}
	}
}
