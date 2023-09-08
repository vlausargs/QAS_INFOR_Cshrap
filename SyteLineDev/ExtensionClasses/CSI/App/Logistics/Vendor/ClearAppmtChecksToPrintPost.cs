//PROJECT NAME: Logistics
//CLASS NAME: ClearAppmtChecksToPrintPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ClearAppmtChecksToPrintPost : IClearAppmtChecksToPrintPost
	{
		readonly IApplicationDB appDB;
		
		
		public ClearAppmtChecksToPrintPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ClearAppmtChecksToPrintPostSp(Guid? PSessionID = null)
		{
			RowPointerType _PSessionID = PSessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ClearAppmtChecksToPrintPostSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
