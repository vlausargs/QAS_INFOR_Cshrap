//PROJECT NAME: Config
//CLASS NAME: CfgDynamicUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgDynamicUpdate : ICfgDynamicUpdate
	{
		readonly IApplicationDB appDB;
		
		public CfgDynamicUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CfgDynamicUpdateSp(
			string pFields,
			string pValues,
			string pRowPointer,
			string pTable,
			string Infobar)
		{
			LongListType _pFields = pFields;
			LongListType _pValues = pValues;
			LongListType _pRowPointer = pRowPointer;
			LongListType _pTable = pTable;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgDynamicUpdateSp";
				
				appDB.AddCommandParameter(cmd, "pFields", _pFields, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pValues", _pValues, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRowPointer", _pRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTable", _pTable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
