//PROJECT NAME: Data
//CLASS NAME: UseTmpTaxTablesBySessionId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UseTmpTaxTablesBySessionId : IUseTmpTaxTablesBySessionId
	{
		readonly IApplicationDB appDB;
		
		public UseTmpTaxTablesBySessionId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? LocalInit,
			string Infobar) UseTmpTaxTablesBySessionIdSp(
			Guid? PSessionId,
			int? LocalInit,
			string Infobar)
		{
			RowPointerType _PSessionId = PSessionId;
			ListYesNoType _LocalInit = LocalInit;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UseTmpTaxTablesBySessionIdSp";
				
				appDB.AddCommandParameter(cmd, "PSessionId", _PSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocalInit", _LocalInit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LocalInit = _LocalInit;
				Infobar = _Infobar;
				
				return (Severity, LocalInit, Infobar);
			}
		}
	}
}
