//PROJECT NAME: CSITest
//CLASS NAME: SAMPProcessErrorOrPromptFactory.cs

using CSI.MG;

namespace CSI.Test
{
	public class SAMPProcessErrorOrPromptFactory
	{
		public ISAMPProcessErrorOrPrompt Create(IApplicationDB appDB)
		{
			var _SAMPProcessErrorOrPrompt = new Test.SAMPProcessErrorOrPrompt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSAMPProcessErrorOrPromptExt = timerfactory.Create<Test.ISAMPProcessErrorOrPrompt>(_SAMPProcessErrorOrPrompt);
			
			return iSAMPProcessErrorOrPromptExt;
		}
	}
}
