//PROJECT NAME: Material
//CLASS NAME: CheckWhsePhyInvFlgFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CheckWhsePhyInvFlgFactory
	{
		public ICheckWhsePhyInvFlg Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckWhsePhyInvFlg = new Material.CheckWhsePhyInvFlg(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckWhsePhyInvFlgExt = timerfactory.Create<Material.ICheckWhsePhyInvFlg>(_CheckWhsePhyInvFlg);
			
			return iCheckWhsePhyInvFlgExt;
		}
	}
}
