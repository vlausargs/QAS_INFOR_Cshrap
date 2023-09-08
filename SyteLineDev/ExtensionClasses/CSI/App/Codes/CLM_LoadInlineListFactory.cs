//PROJECT NAME: CSICodes
//CLASS NAME: CLM_LoadInlineListFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class CLM_LoadInlineListFactory
	{
		public ICLM_LoadInlineList Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _CLM_LoadInlineList = new Codes.CLM_LoadInlineList(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_LoadInlineListExt = timerfactory.Create<Codes.ICLM_LoadInlineList>(_CLM_LoadInlineList);
			
			return iCLM_LoadInlineListExt;
		}
	}
}
