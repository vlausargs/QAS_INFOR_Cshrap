//PROJECT NAME: CSIMOIndPack
//CLASS NAME: MO_ResourceJobSaveDeleteFactory.cs

using CSI.MG;

namespace CSI.MOIndPack
{
	public class MO_ResourceJobSaveDeleteFactory
	{
		public IMO_ResourceJobSaveDelete Create(IApplicationDB appDB)
		{
			var _MO_ResourceJobSaveDelete = new MOIndPack.MO_ResourceJobSaveDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_ResourceJobSaveDeleteExt = timerfactory.Create<MOIndPack.IMO_ResourceJobSaveDelete>(_MO_ResourceJobSaveDelete);
			
			return iMO_ResourceJobSaveDeleteExt;
		}
	}
}
