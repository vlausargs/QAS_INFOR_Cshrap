//PROJECT NAME: Finance
//CLASS NAME: ArpmtCalcAppliedForAmount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArpmtCalcAppliedForAmount : IArpmtCalcAppliedForAmount
	{
		readonly IApplicationDB appDB;
		
		public ArpmtCalcAppliedForAmount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ArpmtCalcAppliedForAmountFn(
			string PBankCode,
			string PCustNum,
			string PType,
			int? PCheckNum,
			string PCreditMemoNum)
		{
			BankCodeType _PBankCode = PBankCode;
			CustNumType _PCustNum = PCustNum;
			ArpmtTypeType _PType = PType;
			ArCheckNumType _PCheckNum = PCheckNum;
			InvNumType _PCreditMemoNum = PCreditMemoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ArpmtCalcAppliedForAmount](@PBankCode, @PCustNum, @PType, @PCheckNum, @PCreditMemoNum)";
				
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCreditMemoNum", _PCreditMemoNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
