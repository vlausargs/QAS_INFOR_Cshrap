//PROJECT NAME: CSICodes
//CLASS NAME: LoadESBCodeDefinitionFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class LoadESBCodeDefinitionFactory
	{
		public ILoadESBCodeDefinition Create(IApplicationDB appDB)
		{
			var _LoadESBCodeDefinition = new Codes.LoadESBCodeDefinition(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBCodeDefinitionExt = timerfactory.Create<Codes.ILoadESBCodeDefinition>(_LoadESBCodeDefinition);
			
			return iLoadESBCodeDefinitionExt;
		}
	}
}
