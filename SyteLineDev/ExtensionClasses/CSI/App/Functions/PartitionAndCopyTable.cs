//PROJECT NAME: Data
//CLASS NAME: PartitionAndCopyTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PartitionAndCopyTable : IPartitionAndCopyTable
	{
		readonly IApplicationDB appDB;
		
		public PartitionAndCopyTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string FullTextIndexString,
			string Infobar) PartitionAndCopyTableSp(
			string PDatabaseSchema,
			string PTableName,
			string PSiteColumn,
			string FullTextIndexString,
			string Infobar)
		{
			ObjectNameType _PDatabaseSchema = PDatabaseSchema;
			ObjectNameType _PTableName = PTableName;
			ColumnNameType _PSiteColumn = PSiteColumn;
			StringType _FullTextIndexString = FullTextIndexString;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PartitionAndCopyTableSp";
				
				appDB.AddCommandParameter(cmd, "PDatabaseSchema", _PDatabaseSchema, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTableName", _PTableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteColumn", _PSiteColumn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FullTextIndexString", _FullTextIndexString, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FullTextIndexString = _FullTextIndexString;
				Infobar = _Infobar;
				
				return (Severity, FullTextIndexString, Infobar);
			}
		}
	}
}
