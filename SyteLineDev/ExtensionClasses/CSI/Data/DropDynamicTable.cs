//PROJECT NAME: Data
//CLASS NAME: DropDynamicTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data
{

	public interface IDropDynamicTable
	{
		(int? ReturnCode, string Infobar) DropDynamicTableSp(string pTable,
		string Infobar,
		string pParm1 = null,
		string pParm2 = "");
	}

	public class DropDynamicTable : IDropDynamicTable
	{
		IApplicationDB appDB;

		
		public DropDynamicTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode, string Infobar) DropDynamicTableSp(string pTable,
		string Infobar,
		string pParm1 = null,
		string pParm2 = "")
		{
			StringType _pTable = pTable;
			InfobarType _Infobar = Infobar;
			StringType _pParm1 = pParm1;
			StringType _pParm2 = pParm2;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DropDynamicTableSp";

				appDB.AddCommandParameter(cmd, "pTable", _pTable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pParm1", _pParm1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pParm2", _pParm2, ParameterDirection.Input);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}
	}

	
}
