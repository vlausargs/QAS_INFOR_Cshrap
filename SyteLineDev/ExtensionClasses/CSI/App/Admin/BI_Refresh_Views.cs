//PROJECT NAME: CSIAdmin
//CLASS NAME: BI_Refresh_Views.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
	public interface IBI_Refresh_Views
	{
		int BI_Refresh_ViewsSp(string DefSite,
		                       ref string InforBar);
	}
	
	public class BI_Refresh_Views : IBI_Refresh_Views
	{
		IApplicationDB appDB;
		
		public BI_Refresh_Views(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int BI_Refresh_ViewsSp(string DefSite,
		                              ref string InforBar)
		{
			StringType _DefSite = DefSite;
			InfobarType _InforBar = InforBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BI_Refresh_ViewsSp";
				
				appDB.AddCommandParameter(cmd, "DefSite", _DefSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InforBar", _InforBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InforBar = _InforBar;
				
				return Severity;
			}
		}
	}
}
