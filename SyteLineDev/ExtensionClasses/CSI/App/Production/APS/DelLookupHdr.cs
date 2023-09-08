//PROJECT NAME: Production
//CLASS NAME: DelLookupHdr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class DelLookupHdr : IDelLookupHdr
	{
		readonly IApplicationDB appDB;
		
		
		public DelLookupHdr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DelLookupHdrSp(string Tabid,
		string Infobar)
		{
			ApsLtableType _Tabid = Tabid;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DelLookupHdrSp";
				
				appDB.AddCommandParameter(cmd, "Tabid", _Tabid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
