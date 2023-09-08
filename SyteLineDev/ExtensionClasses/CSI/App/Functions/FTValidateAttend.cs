//PROJECT NAME: Data
//CLASS NAME: FTValidateAttend.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTValidateAttend : IFTValidateAttend
	{
		readonly IApplicationDB appDB;
		
		public FTValidateAttend(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FTValidateAttendSp(
			Guid? SessionID)
		{
			RowPointerType _SessionID = SessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTValidateAttendSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
