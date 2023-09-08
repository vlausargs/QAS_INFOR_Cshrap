//PROJECT NAME: Data
//CLASS NAME: GetRowCountSetting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetRowCountSetting : IGetRowCountSetting
	{
		readonly IApplicationDB appDB;
		
		public GetRowCountSetting(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			long? RowCount) GetRowCountSettingSp(
			long? RowCount)
		{
			LongType _RowCount = RowCount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetRowCountSettingSp";
				
				appDB.AddCommandParameter(cmd, "RowCount", _RowCount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RowCount = _RowCount;
				
				return (Severity, RowCount);
			}
		}
	}
}
