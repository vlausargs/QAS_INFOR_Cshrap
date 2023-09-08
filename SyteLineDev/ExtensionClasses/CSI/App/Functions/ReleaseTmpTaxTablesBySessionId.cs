//PROJECT NAME: Data
//CLASS NAME: ReleaseTmpTaxTablesBySessionId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ReleaseTmpTaxTablesBySessionId : IReleaseTmpTaxTablesBySessionId
	{
		readonly IApplicationDB appDB;
		
		public ReleaseTmpTaxTablesBySessionId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? LocalInit) ReleaseTmpTaxTablesBySessionIdSp(
			Guid? PSessionId,
			int? LocalInit = 1)
		{
			RowPointerType _PSessionId = PSessionId;
			ListYesNoType _LocalInit = LocalInit;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ReleaseTmpTaxTablesBySessionIdSp";
				
				appDB.AddCommandParameter(cmd, "PSessionId", _PSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocalInit", _LocalInit, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LocalInit = _LocalInit;
				
				return (Severity, LocalInit);
			}
		}
	}
}
