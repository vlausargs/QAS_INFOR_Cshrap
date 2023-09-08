//PROJECT NAME: CSIMaterial
//CLASS NAME: CLM_GetSearchItemsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class CLM_GetSearchItemsFactory
	{
		public ICLM_GetSearchItems Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _CLM_GetSearchItems = new Material.CLM_GetSearchItems(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetSearchItemsExt = timerfactory.Create<Material.ICLM_GetSearchItems>(_CLM_GetSearchItems);
			
			return iCLM_GetSearchItemsExt;
		}
	}
}
