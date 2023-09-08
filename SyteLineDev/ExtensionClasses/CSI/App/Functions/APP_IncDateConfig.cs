//PROJECT NAME: Data
//CLASS NAME: APP_IncDateConfig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class APP_IncDateConfig : IAPP_IncDateConfig
	{
		readonly IApplicationDB appDB;
		
		public APP_IncDateConfig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ExcludedTableNameList,
			string ExcludedColumnNameList,
			string ExcludedTypeNameList,
			string YearTypeNameList) APP_IncDateConfigSp(
			string ExcludedTableNameList,
			string ExcludedColumnNameList,
			string ExcludedTypeNameList,
			string YearTypeNameList)
		{
			VeryLongListType _ExcludedTableNameList = ExcludedTableNameList;
			VeryLongListType _ExcludedColumnNameList = ExcludedColumnNameList;
			VeryLongListType _ExcludedTypeNameList = ExcludedTypeNameList;
			VeryLongListType _YearTypeNameList = YearTypeNameList;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APP_IncDateConfigSp";
				
				appDB.AddCommandParameter(cmd, "ExcludedTableNameList", _ExcludedTableNameList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExcludedColumnNameList", _ExcludedColumnNameList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExcludedTypeNameList", _ExcludedTypeNameList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "YearTypeNameList", _YearTypeNameList, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExcludedTableNameList = _ExcludedTableNameList;
				ExcludedColumnNameList = _ExcludedColumnNameList;
				ExcludedTypeNameList = _ExcludedTypeNameList;
				YearTypeNameList = _YearTypeNameList;
				
				return (Severity, ExcludedTableNameList, ExcludedColumnNameList, ExcludedTypeNameList, YearTypeNameList);
			}
		}
	}
}
