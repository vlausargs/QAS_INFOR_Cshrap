//PROJECT NAME: Logistics
//CLASS NAME: APVchPostingAptrxdSnapShot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class APVchPostingAptrxdSnapShot : IAPVchPostingAptrxdSnapShot
	{
		readonly IApplicationDB appDB;
		
		
		public APVchPostingAptrxdSnapShot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) APVchPostingAptrxdSnapShotSp(Guid? PSessionID,
		string Infobar)
		{
			RowPointer _PSessionID = PSessionID;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APVchPostingAptrxdSnapShotSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
