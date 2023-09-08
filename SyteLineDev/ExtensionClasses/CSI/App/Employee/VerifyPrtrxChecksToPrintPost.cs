//PROJECT NAME: Employee
//CLASS NAME: VerifyPrtrxChecksToPrintPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IVerifyPrtrxChecksToPrintPost
	{
		(int? ReturnCode, Guid? PSessionID) VerifyPrtrxChecksToPrintPostSp(Guid? PSessionID = null);
	}
	
	public class VerifyPrtrxChecksToPrintPost : IVerifyPrtrxChecksToPrintPost
	{
		readonly IApplicationDB appDB;
		
		public VerifyPrtrxChecksToPrintPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? PSessionID) VerifyPrtrxChecksToPrintPostSp(Guid? PSessionID = null)
		{
			RowPointerType _PSessionID = PSessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VerifyPrtrxChecksToPrintPostSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSessionID = _PSessionID;
				
				return (Severity, PSessionID);
			}
		}
	}
}
