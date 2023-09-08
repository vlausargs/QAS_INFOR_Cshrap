//PROJECT NAME: Admin
//CLASS NAME: SaveUserSelectedKPIFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class SaveUserSelectedKPIFactory
	{
		public ISaveUserSelectedKPI Create(IApplicationDB appDB)
		{
			var _SaveUserSelectedKPI = new Admin.SaveUserSelectedKPI(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSaveUserSelectedKPIExt = timerfactory.Create<Admin.ISaveUserSelectedKPI>(_SaveUserSelectedKPI);
			
			return iSaveUserSelectedKPIExt;
		}
	}
}
