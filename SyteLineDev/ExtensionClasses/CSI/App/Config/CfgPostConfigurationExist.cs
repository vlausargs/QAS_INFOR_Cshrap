//PROJECT NAME: Config
//CLASS NAME: CfgPostConfigurationExist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgPostConfigurationExist : ICfgPostConfigurationExist
	{
		readonly IApplicationDB appDB;
		
		public CfgPostConfigurationExist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CfgPostConfigurationExistFn(
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
				cmd.CommandText = "SELECT  dbo.[CfgPostConfigurationExist](@SourceRefType, @RefNum, @RefLineSuf)";
				
				appDB.AddCommandParameter(cmd, "SourceRefType", _SourceRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
