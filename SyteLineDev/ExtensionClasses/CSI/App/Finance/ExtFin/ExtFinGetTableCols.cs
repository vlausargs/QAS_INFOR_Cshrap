//PROJECT NAME: Finance
//CLASS NAME: ExtFinGetTableCols.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExtFinGetTableCols : IExtFinGetTableCols
	{
		readonly IApplicationDB appDB;
		
		
		public ExtFinGetTableCols(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar,
		string ColNames,
		int? AllColsAppended) ExtFinGetTableColsSp(string PTableName,
		string LastColReturned,
		string Infobar,
		string ColNames,
		int? AllColsAppended)
		{
			TableNameType _PTableName = PTableName;
			ColumnType _LastColReturned = LastColReturned;
			Infobar _Infobar = Infobar;
			LongListType _ColNames = ColNames;
			SmallintType _AllColsAppended = AllColsAppended;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtFinGetTableColsSp";
				
				appDB.AddCommandParameter(cmd, "PTableName", _PTableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastColReturned", _LastColReturned, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ColNames", _ColNames, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AllColsAppended", _AllColsAppended, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				ColNames = _ColNames;
				AllColsAppended = _AllColsAppended;
				
				return (Severity, Infobar, ColNames, AllColsAppended);
			}
		}
	}
}
