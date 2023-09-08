//PROJECT NAME: MOIndPack
//CLASS NAME: MO_ResourceJobDeleteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MOIndPack
{
	public class MO_ResourceJobDeleteFactory
	{
		public IMO_ResourceJobDelete Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MO_ResourceJobDelete = new MOIndPack.MO_ResourceJobDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_ResourceJobDeleteExt = timerfactory.Create<MOIndPack.IMO_ResourceJobDelete>(_MO_ResourceJobDelete);
			
			return iMO_ResourceJobDeleteExt;
		}
	}
}
