//PROJECT NAME: CSIMOIndPack
//CLASS NAME: MO_ResourceJobSaveFactory.cs

using CSI.MG;

namespace CSI.MOIndPack
{
	public class MO_ResourceJobSaveFactory
	{
		public IMO_ResourceJobSave Create(IApplicationDB appDB)
		{
			var _MO_ResourceJobSave = new MOIndPack.MO_ResourceJobSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_ResourceJobSaveExt = timerfactory.Create<MOIndPack.IMO_ResourceJobSave>(_MO_ResourceJobSave);
			
			return iMO_ResourceJobSaveExt;
		}
	}
}
