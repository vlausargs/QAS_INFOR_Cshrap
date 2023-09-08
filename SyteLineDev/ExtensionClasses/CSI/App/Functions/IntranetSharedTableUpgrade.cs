//PROJECT NAME: Data
//CLASS NAME: IntranetSharedTableUpgrade.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IntranetSharedTableUpgrade : IIntranetSharedTableUpgrade
	{
		readonly IApplicationDB appDB;
		
		public IntranetSharedTableUpgrade(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) IntranetSharedTableUpgradeSp(
			string Mode = "CREATE",
			string Infobar = null)
		{
			StringType _Mode = Mode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IntranetSharedTableUpgradeSp";
				
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
