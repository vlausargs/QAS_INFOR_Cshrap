//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBPersonnelSkillsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadESBPersonnelSkillsFactory
	{
		public ILoadESBPersonnelSkills Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadESBPersonnelSkills = new BusInterface.LoadESBPersonnelSkills(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBPersonnelSkillsExt = timerfactory.Create<BusInterface.ILoadESBPersonnelSkills>(_LoadESBPersonnelSkills);
			
			return iLoadESBPersonnelSkillsExt;
		}
	}
}
