//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROInvSubDepositSum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROInvSubDepositSum : ISSSFSSROInvSubDepositSum
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROInvSubDepositSum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? SRODeposit,
			string Infobar) SSSFSSROInvSubDepositSumSp(
			string SRONum,
			string CustNum,
			string InvNum,
			int? InvSeq,
			decimal? PInvTot,
			int? PDistSeq,
			decimal? SRODeposit,
			string Infobar)
		{
			FSSRONumType _SRONum = SRONum;
			CustNumType _CustNum = CustNum;
			InvNumType _InvNum = InvNum;
			InvSeqType _InvSeq = InvSeq;
			AmountType _PInvTot = PInvTot;
			ArDistSeqType _PDistSeq = PDistSeq;
			AmountType _SRODeposit = SRODeposit;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROInvSubDepositSumSp";
				
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvTot", _PInvTot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDistSeq", _PDistSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRODeposit", _SRODeposit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SRODeposit = _SRODeposit;
				Infobar = _Infobar;
				
				return (Severity, SRODeposit, Infobar);
			}
		}
	}
}
