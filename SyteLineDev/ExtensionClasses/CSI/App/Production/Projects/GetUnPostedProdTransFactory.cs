//PROJECT NAME: Production
//CLASS NAME: GetUnPostedProdTransFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class GetUnPostedProdTransFactory
	{
		public IGetUnPostedProdTrans Create(IApplicationDB appDB)
		{
			var _GetUnPostedProdTrans = new Production.Projects.GetUnPostedProdTrans(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetUnPostedProdTransExt = timerfactory.Create<Production.Projects.IGetUnPostedProdTrans>(_GetUnPostedProdTrans);
			
			return iGetUnPostedProdTransExt;
		}
	}
}
