//PROJECT NAME: CSITest
//CLASS NAME: SAMPErrorOrPromptValidationFactory.cs

using CSI.MG;

namespace CSI.Test
{
	public class SAMPErrorOrPromptValidationFactory
	{
		public ISAMPErrorOrPromptValidation Create(IApplicationDB appDB)
		{
			var _SAMPErrorOrPromptValidation = new Test.SAMPErrorOrPromptValidation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSAMPErrorOrPromptValidationExt = timerfactory.Create<Test.ISAMPErrorOrPromptValidation>(_SAMPErrorOrPromptValidation);
			
			return iSAMPErrorOrPromptValidationExt;
		}
	}
}
