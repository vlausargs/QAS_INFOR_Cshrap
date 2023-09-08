//PROJECT NAME: Data
//CLASS NAME: TransferNotesToSiteCrossTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TransferNotesToSiteCrossTable : ITransferNotesToSiteCrossTable
	{
		readonly IApplicationDB appDB;
		
		public TransferNotesToSiteCrossTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) TransferNotesToSiteCrossTableSp(
			string ToSite,
			string TableName,
			Guid? RowPointer,
			string ToWhereClause,
			string ToJoinClause,
			Guid? ToRowPointer,
			string Infobar,
			string ToTableName = null,
			string RemoteDbName = null)
		{
			SiteType _ToSite = ToSite;
			StringType _TableName = TableName;
			RowPointerType _RowPointer = RowPointer;
			LongListType _ToWhereClause = ToWhereClause;
			LongListType _ToJoinClause = ToJoinClause;
			RowPointerType _ToRowPointer = ToRowPointer;
			InfobarType _Infobar = Infobar;
			StringType _ToTableName = ToTableName;
			LongListType _RemoteDbName = RemoteDbName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TransferNotesToSiteCrossTableSp";
				
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhereClause", _ToWhereClause, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJoinClause", _ToJoinClause, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRowPointer", _ToRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToTableName", _ToTableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RemoteDbName", _RemoteDbName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
