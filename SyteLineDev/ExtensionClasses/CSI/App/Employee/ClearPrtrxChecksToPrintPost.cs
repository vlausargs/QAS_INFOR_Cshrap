//PROJECT NAME: Employee
//CLASS NAME: ClearPrtrxChecksToPrintPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class ClearPrtrxChecksToPrintPost : IClearPrtrxChecksToPrintPost
	{
		readonly IApplicationDB appDB;
		
		
		public ClearPrtrxChecksToPrintPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ClearPrtrxChecksToPrintPostSp(Guid? pSessionID = null)
		{
			RowPointerType _pSessionID = pSessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ClearPrtrxChecksToPrintPostSp";
				
				appDB.AddCommandParameter(cmd, "pSessionID", _pSessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
