//PROJECT NAME: Production
//CLASS NAME: RSQC_Deletetmpser.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_Deletetmpser : IRSQC_Deletetmpser
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_Deletetmpser(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RSQC_DeletetmpserSp(string Infobar)
		{
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_DeletetmpserSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
