//PROJECT NAME: Data
//CLASS NAME: NextTmpMatltranAmtAdjSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextTmpMatltranAmtAdjSeq : INextTmpMatltranAmtAdjSeq
	{
		readonly IApplicationDB appDB;
		
		public NextTmpMatltranAmtAdjSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? NextTmpMatltranAmtAdjSeqFn(
			decimal? TransNum)
		{
			MatlTransNumType _TransNum = TransNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[NextTmpMatltranAmtAdjSeq](@TransNum)";
				
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
