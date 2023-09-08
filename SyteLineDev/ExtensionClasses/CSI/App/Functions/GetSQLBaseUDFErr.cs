//PROJECT NAME: Data
//CLASS NAME: GetSQLBaseUDFErr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetSQLBaseUDFErr : IGetSQLBaseUDFErr
	{
		readonly IApplicationDB appDB;
		
		public GetSQLBaseUDFErr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string SQLBaseUDFErr) GetSQLBaseUDFErrSp(
			string SQLBaseUDFErr)
		{
			InfobarType _SQLBaseUDFErr = SQLBaseUDFErr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetSQLBaseUDFErrSp";
				
				appDB.AddCommandParameter(cmd, "SQLBaseUDFErr", _SQLBaseUDFErr, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SQLBaseUDFErr = _SQLBaseUDFErr;
				
				return (Severity, SQLBaseUDFErr);
			}
		}
	}
}
