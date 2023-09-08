//PROJECT NAME: Material
//CLASS NAME: TransNextKeyDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class TransNextKeyDelFactory
	{
		public ITransNextKeyDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TransNextKeyDel = new Material.TransNextKeyDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTransNextKeyDelExt = timerfactory.Create<Material.ITransNextKeyDel>(_TransNextKeyDel);
			
			return iTransNextKeyDelExt;
		}
	}
}
