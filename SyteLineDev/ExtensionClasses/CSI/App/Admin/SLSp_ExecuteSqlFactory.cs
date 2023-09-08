//PROJECT NAME: Admin
//CLASS NAME: SLSp_ExecuteSqlFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class SLSp_ExecuteSqlFactory
	{
		public ISLSp_ExecuteSql Create(IApplicationDB appDB)
		{
			var _SLSp_ExecuteSql = new Admin.SLSp_ExecuteSql(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSLSp_ExecuteSqlExt = timerfactory.Create<Admin.ISLSp_ExecuteSql>(_SLSp_ExecuteSql);
			
			return iSLSp_ExecuteSqlExt;
		}
	}
}
