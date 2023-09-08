//PROJECT NAME: CSIProduct
//CLASS NAME: GetItemSuffixFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class GetItemSuffixFactory
	{
		public IGetItemSuffix Create(IApplicationDB appDB)
		{
			var _GetItemSuffix = new Production.GetItemSuffix(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetItemSuffixExt = timerfactory.Create<Production.IGetItemSuffix>(_GetItemSuffix);
			
			return iGetItemSuffixExt;
		}
	}
}
