//PROJECT NAME: Config
//CLASS NAME: CfgGetDataType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgGetDataType : ICfgGetDataType
	{
		readonly IApplicationDB appDB;
		
		public CfgGetDataType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string CfgGetDataTypeFn(
			string Type)
		{
			LongList _Type = Type;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CfgGetDataType](@Type)";
				
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
