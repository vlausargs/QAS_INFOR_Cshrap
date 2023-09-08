//PROJECT NAME: Production
//CLASS NAME: ApsBomPartSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsBomPartSeq : IApsBomPartSeq
	{
		readonly IApplicationDB appDB;
		
		public ApsBomPartSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsBomPartSeqFn(
			int? POperNum,
			int? PAltGroup,
			int? PAltGroupRank)
		{
			OperNumType _POperNum = POperNum;
			JobmatlSequenceType _PAltGroup = PAltGroup;
			JobmatlRankType _PAltGroupRank = PAltGroupRank;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsBomPartSeq](@POperNum, @PAltGroup, @PAltGroupRank)";
				
				appDB.AddCommandParameter(cmd, "POperNum", _POperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAltGroup", _PAltGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAltGroupRank", _PAltGroupRank, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
