//PROJECT NAME: App.Reporting
//CLASS NAME: ReportNotesExist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class ReportNotesExist : IReportNotesExist
	{
		readonly IApplicationDB appDB;


		public ReportNotesExist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? ReportNotesExistFn(string TableName,
		Guid? RowPointer,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		int? NoteExists = 1)
		{
			StringType _TableName = TableName;
			RowPointerType _RowPointer = RowPointer;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _NoteExists = NoteExists;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ReportNotesExist](@TableName, @RowPointer, @ShowInternal, @ShowExternal, @NoteExists)";

				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteExists", _NoteExists, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
