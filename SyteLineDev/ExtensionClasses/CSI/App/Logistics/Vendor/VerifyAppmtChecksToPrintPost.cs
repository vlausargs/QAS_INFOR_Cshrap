//PROJECT NAME: Logistics
//CLASS NAME: VerifyAppmtChecksToPrintPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VerifyAppmtChecksToPrintPost : IVerifyAppmtChecksToPrintPost
	{
		readonly IApplicationDB appDB;
		
		
		public VerifyAppmtChecksToPrintPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? PSessionID) VerifyAppmtChecksToPrintPostSp(Guid? PSessionID = null)
		{
			RowPointerType _PSessionID = PSessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VerifyAppmtChecksToPrintPostSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSessionID = _PSessionID;
				
				return (Severity, PSessionID);
			}
		}
	}
}
