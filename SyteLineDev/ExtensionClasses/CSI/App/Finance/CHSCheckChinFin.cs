//PROJECT NAME: Finance
//CLASS NAME: CHSCheckChinFin.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class CHSCheckChinFin : ICHSCheckChinFin
	{
		readonly IApplicationDB appDB;
		
		
		public CHSCheckChinFin(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? AvailChinFin) CHSCheckChinFinSp(int? AvailChinFin)
		{
			FlagNyType _AvailChinFin = AvailChinFin;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSCheckChinFinSp";
				
				appDB.AddCommandParameter(cmd, "AvailChinFin", _AvailChinFin, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AvailChinFin = _AvailChinFin;
				
				return (Severity, AvailChinFin);
			}
		}
	}
}
