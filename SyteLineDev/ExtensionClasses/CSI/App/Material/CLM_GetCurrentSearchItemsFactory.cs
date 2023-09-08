//PROJECT NAME: CSIMaterial
//CLASS NAME: CLM_GetCurrentSearchItemsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class CLM_GetCurrentSearchItemsFactory
	{
		public ICLM_GetCurrentSearchItems Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _CLM_GetCurrentSearchItems = new Material.CLM_GetCurrentSearchItems(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetCurrentSearchItemsExt = timerfactory.Create<Material.ICLM_GetCurrentSearchItems>(_CLM_GetCurrentSearchItems);
			
			return iCLM_GetCurrentSearchItemsExt;
		}
	}
}
