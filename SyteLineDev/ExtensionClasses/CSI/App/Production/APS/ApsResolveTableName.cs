//PROJECT NAME: Production
//CLASS NAME: ApsResolveTableName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsResolveTableName : IApsResolveTableName
	{
		readonly IApplicationDB appDB;
		
		public ApsResolveTableName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsResolveTableNameFn(
			int? AltNum,
			string ApsBaseTable)
		{
			ApsAltNoType _AltNum = AltNum;
			TableNameType _ApsBaseTable = ApsBaseTable;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsResolveTableName](@AltNum, @ApsBaseTable)";
				
				appDB.AddCommandParameter(cmd, "AltNum", _AltNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApsBaseTable", _ApsBaseTable, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
