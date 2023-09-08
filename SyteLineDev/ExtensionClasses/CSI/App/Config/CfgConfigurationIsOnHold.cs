//PROJECT NAME: Config
//CLASS NAME: CfgConfigurationIsOnHold.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgConfigurationIsOnHold : ICfgConfigurationIsOnHold
	{
		readonly IApplicationDB appDB;
		
		public CfgConfigurationIsOnHold(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CfgConfigurationIsOnHoldFn(
			string SourceRefType,
			string RefNum,
			int? RefLineSuf)
		{
			StringType _SourceRefType = SourceRefType;
			CoNumJobType _RefNum = RefNum;
			CoLineSuffixType _RefLineSuf = RefLineSuf;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CfgConfigurationIsOnHold](@SourceRefType, @RefNum, @RefLineSuf)";
				
				appDB.AddCommandParameter(cmd, "SourceRefType", _SourceRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
