//PROJECT NAME: Admin
//CLASS NAME: UnlockLockedFunction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class UnlockLockedFunction : IUnlockLockedFunction
	{
		IApplicationDB appDB;
		
		
		public UnlockLockedFunction(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UnlockLockedFunctionSp(string FunctionName,
		string Infobar)
		{
			DescriptionType _FunctionName = FunctionName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UnlockLockedFunctionSp";
				
				appDB.AddCommandParameter(cmd, "FunctionName", _FunctionName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
