//PROJECT NAME: Data
//CLASS NAME: GetSqlProductVersionMajor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetSqlProductVersionMajor : IGetSqlProductVersionMajor
	{
		readonly IApplicationDB appDB;
		
		public GetSqlProductVersionMajor(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? ProductVersionMajor,
			string Infobar) GetSqlProductVersionMajorSp(
			int? ProductVersionMajor,
			string Infobar)
		{
			IntType _ProductVersionMajor = ProductVersionMajor;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetSqlProductVersionMajorSp";
				
				appDB.AddCommandParameter(cmd, "ProductVersionMajor", _ProductVersionMajor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProductVersionMajor = _ProductVersionMajor;
				Infobar = _Infobar;
				
				return (Severity, ProductVersionMajor, Infobar);
			}
		}
	}
}
