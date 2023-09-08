//PROJECT NAME: Logistics
//CLASS NAME: AppmtCalcAppliedForAmount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AppmtCalcAppliedForAmount : IAppmtCalcAppliedForAmount
	{
		readonly IApplicationDB appDB;
		
		public AppmtCalcAppliedForAmount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? AppmtCalcAppliedForAmountFn(
			string PBankCode,
			string PVendNum,
			int? PCheckSeq)
		{
			BankCodeType _PBankCode = PBankCode;
			CustNumType _PVendNum = PVendNum;
			ArCheckNumType _PCheckSeq = PCheckSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[AppmtCalcAppliedForAmount](@PBankCode, @PVendNum, @PCheckSeq)";
				
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckSeq", _PCheckSeq, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
