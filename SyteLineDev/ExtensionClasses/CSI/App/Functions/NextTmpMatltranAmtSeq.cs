//PROJECT NAME: Data
//CLASS NAME: NextTmpMatltranAmtSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextTmpMatltranAmtSeq : INextTmpMatltranAmtSeq
	{
		readonly IApplicationDB appDB;
		
		public NextTmpMatltranAmtSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? NextTmpMatltranAmtSeqFn(
			decimal? TransNum)
		{
			MatlTransNumType _TransNum = TransNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[NextTmpMatltranAmtSeq](@TransNum)";
				
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
