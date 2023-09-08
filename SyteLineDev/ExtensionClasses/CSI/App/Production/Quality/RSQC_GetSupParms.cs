//PROJECT NAME: Production
//CLASS NAME: RSQC_GetSupParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetSupParms : IRSQC_GetSupParms
	{
		readonly IApplicationDB appDB;
		
		public RSQC_GetSupParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? NeedsQC) RSQC_GetSupParmsSp(
			int? NeedsQC)
		{
			ListYesNoType _NeedsQC = NeedsQC;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetSupParmsSp";
				
				appDB.AddCommandParameter(cmd, "NeedsQC", _NeedsQC, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NeedsQC = _NeedsQC;
				
				return (Severity, NeedsQC);
			}
		}
	}
}
