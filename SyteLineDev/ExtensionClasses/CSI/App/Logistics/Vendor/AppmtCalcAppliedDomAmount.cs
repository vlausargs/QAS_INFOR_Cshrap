//PROJECT NAME: Logistics
//CLASS NAME: AppmtCalcAppliedDomAmount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AppmtCalcAppliedDomAmount : IAppmtCalcAppliedDomAmount
	{
		readonly IApplicationDB appDB;
		
		public AppmtCalcAppliedDomAmount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? AppmtCalcAppliedDomAmountFn(
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
				cmd.CommandText = "SELECT  dbo.[AppmtCalcAppliedDomAmount](@PBankCode, @PVendNum, @PCheckSeq)";
				
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckSeq", _PCheckSeq, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
