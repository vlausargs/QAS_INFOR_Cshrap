//PROJECT NAME: CSIProduct
//CLASS NAME: EstJobItemVFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class EstJobItemVFactory
	{
		public IEstJobItemV Create(IApplicationDB appDB)
		{
			var _EstJobItemV = new Production.EstJobItemV(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEstJobItemVExt = timerfactory.Create<Production.IEstJobItemV>(_EstJobItemV);
			
			return iEstJobItemVExt;
		}
	}
}
