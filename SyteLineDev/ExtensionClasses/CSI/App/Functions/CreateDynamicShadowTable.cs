//PROJECT NAME: Data
//CLASS NAME: CreateDynamicShadowTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CreateDynamicShadowTable : ICreateDynamicShadowTable
	{
		readonly IApplicationDB appDB;
		
		public CreateDynamicShadowTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CreateDynamicShadowTableSp(
			string pTable,
			string Infobar)
		{
			StringType _pTable = pTable;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateDynamicShadowTableSp";
				
				appDB.AddCommandParameter(cmd, "pTable", _pTable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
