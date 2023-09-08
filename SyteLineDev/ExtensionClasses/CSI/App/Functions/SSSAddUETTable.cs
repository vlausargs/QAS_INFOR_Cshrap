//PROJECT NAME: Data
//CLASS NAME: SSSAddUETTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SSSAddUETTable : ISSSAddUETTable
	{
		readonly IApplicationDB appDB;
		
		public SSSAddUETTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSAddUETTableSp(
			string iClassName,
			string iClassLabel,
			string iClassDesc,
			string iTableName)
		{
			ClassNameType _iClassName = iClassName;
			LabelType _iClassLabel = iClassLabel;
			DescriptionType _iClassDesc = iClassDesc;
			TableNameType _iTableName = iTableName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSAddUETTableSp";
				
				appDB.AddCommandParameter(cmd, "iClassName", _iClassName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iClassLabel", _iClassLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iClassDesc", _iClassDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTableName", _iTableName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
