//PROJECT NAME: CSIFinance
//CLASS NAME: GetFaParmsFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class GetFaParmsFactory
	{
		public IGetFaParms Create(IApplicationDB appDB)
		{
			var _GetFaParms = new Finance.GetFaParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetFaParmsExt = timerfactory.Create<Finance.IGetFaParms>(_GetFaParms);
			
			return iGetFaParmsExt;
		}
	}
}
