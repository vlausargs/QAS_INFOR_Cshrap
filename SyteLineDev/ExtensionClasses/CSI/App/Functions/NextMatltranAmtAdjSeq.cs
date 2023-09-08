//PROJECT NAME: Data
//CLASS NAME: NextMatltranAmtAdjSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextMatltranAmtAdjSeq : INextMatltranAmtAdjSeq
	{
		readonly IApplicationDB appDB;
		
		public NextMatltranAmtAdjSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? NextMatltranAmtAdjSeqFn(
			decimal? TransNum)
		{
			MatlTransNumType _TransNum = TransNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[NextMatltranAmtAdjSeq](@TransNum)";
				
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
