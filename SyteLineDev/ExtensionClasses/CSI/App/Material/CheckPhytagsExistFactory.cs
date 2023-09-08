//PROJECT NAME: Material
//CLASS NAME: CheckPhytagsExistFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CheckPhytagsExistFactory
	{
		public ICheckPhytagsExist Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckPhytagsExist = new Material.CheckPhytagsExist(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckPhytagsExistExt = timerfactory.Create<Material.ICheckPhytagsExist>(_CheckPhytagsExist);
			
			return iCheckPhytagsExistExt;
		}
	}
}
