//PROJECT NAME: Data
//CLASS NAME: App_DeleteReplicationError.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class App_DeleteReplicationError : IApp_DeleteReplicationError
	{
		readonly IApplicationDB appDB;
		
		public App_DeleteReplicationError(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) App_DeleteReplicationErrorSp(
			decimal? OperationNumber,
			string Value1,
			string Value2,
			string Infobar)
		{
			OperationCounterType _OperationNumber = OperationNumber;
			OleObjectType _Value1 = Value1;
			OleObjectType _Value2 = Value2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "App_DeleteReplicationErrorSp";
				
				appDB.AddCommandParameter(cmd, "OperationNumber", _OperationNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Value1", _Value1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Value2", _Value2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
