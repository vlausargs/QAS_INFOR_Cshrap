//PROJECT NAME: CSICCI
//CLASS NAME: SSSCCIPayOpenNext.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public interface ISSSCCIPayOpenNext
	{
		int SSSCCIPayOpenNextSp(ref int? NextOpenNum);
	}
	
	public class SSSCCIPayOpenNext : ISSSCCIPayOpenNext
	{
		readonly IApplicationDB appDB;
		
		public SSSCCIPayOpenNext(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSCCIPayOpenNextSp(ref int? NextOpenNum)
		{
			IntType _NextOpenNum = NextOpenNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSCCIPayOpenNextSp";
				
				appDB.AddCommandParameter(cmd, "NextOpenNum", _NextOpenNum, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextOpenNum = _NextOpenNum;
				
				return Severity;
			}
		}
	}
}
