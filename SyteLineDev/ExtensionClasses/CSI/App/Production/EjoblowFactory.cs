//PROJECT NAME: CSIProduct
//CLASS NAME: EjoblowFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class EjoblowFactory
	{
		public IEjoblow Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _Ejoblow = new Production.Ejoblow(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEjoblowExt = timerfactory.Create<Production.IEjoblow>(_Ejoblow);
			
			return iEjoblowExt;
		}
	}
}
