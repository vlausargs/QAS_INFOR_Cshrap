//PROJECT NAME: CSITest
//CLASS NAME: CLM_XMLViewFactory.cs

using CSI.MG;

namespace CSI.Test
{
	public class CLM_XMLViewFactory
	{
		public ICLM_XMLView Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _CLM_XMLView = new Test.CLM_XMLView(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_XMLViewExt = timerfactory.Create<Test.ICLM_XMLView>(_CLM_XMLView);
			
			return iCLM_XMLViewExt;
		}
	}
}
