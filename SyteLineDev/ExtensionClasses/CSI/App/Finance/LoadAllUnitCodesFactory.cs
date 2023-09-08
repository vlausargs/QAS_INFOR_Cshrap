//PROJECT NAME: CSIFinance
//CLASS NAME: LoadAllUnitCodesFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class LoadAllUnitCodesFactory
	{
		public ILoadAllUnitCodes Create(IApplicationDB appDB)
		{
			var _LoadAllUnitCodes = new Finance.LoadAllUnitCodes(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadAllUnitCodesExt = timerfactory.Create<Finance.ILoadAllUnitCodes>(_LoadAllUnitCodes);
			
			return iLoadAllUnitCodesExt;
		}
	}
}
