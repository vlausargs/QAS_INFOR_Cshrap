//PROJECT NAME: Config
//CLASS NAME: CfgPostConfigurationMsg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgPostConfigurationMsg : ICfgPostConfigurationMsg
	{
		readonly IApplicationDB appDB;
		
		public CfgPostConfigurationMsg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string CfgPostConfigurationMsgFn(
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
				cmd.CommandText = "SELECT  dbo.[CfgPostConfigurationMsg](@SourceRefType, @RefNum, @RefLineSuf)";
				
				appDB.AddCommandParameter(cmd, "SourceRefType", _SourceRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
