//PROJECT NAME: Data
//CLASS NAME: CreateDynamicTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CreateDynamicTable : ICreateDynamicTable
	{
		readonly IApplicationDB appDB;
		
		public CreateDynamicTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CreateDynamicTableSp(
			string pTable,
			string Infobar,
			string pParm1 = null,
			string pParm2 = null,
			string pColumns = null,
			int? CopyIndexes = 1)
		{
			StringType _pTable = pTable;
			InfobarType _Infobar = Infobar;
			StringType _pParm1 = pParm1;
			StringType _pParm2 = pParm2;
			LongListType _pColumns = pColumns;
			ListYesNoType _CopyIndexes = CopyIndexes;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateDynamicTableSp";
				
				appDB.AddCommandParameter(cmd, "pTable", _pTable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pParm1", _pParm1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pParm2", _pParm2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pColumns", _pColumns, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyIndexes", _CopyIndexes, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
