//PROJECT NAME: Material
//CLASS NAME: CpTFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CpTFactory
	{
		public ICpT Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CpT = new Material.CpT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCpTExt = timerfactory.Create<Material.ICpT>(_CpT);
			
			return iCpTExt;
		}
	}
}
