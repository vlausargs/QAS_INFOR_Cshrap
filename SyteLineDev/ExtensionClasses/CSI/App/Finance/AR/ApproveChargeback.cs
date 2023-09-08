//PROJECT NAME: Finance
//CLASS NAME: ApproveChargeback.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ApproveChargeback : IApproveChargeback
	{
		readonly IApplicationDB appDB;
		
		public ApproveChargeback(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar) ApproveChargebackSp(
			Guid? RowPointer,
			string CustNum,
			string ChargebackInvNum,
			string InvNum,
			string ChargebackType,
			decimal? Amount,
			int? CheckNum,
			int? ChargebackSeq,
			string InfoBar)
		{
			RowPointerType _RowPointer = RowPointer;
			CustNumType _CustNum = CustNum;
			InvNumType _ChargebackInvNum = ChargebackInvNum;
			InvNumType _InvNum = InvNum;
			ChargebackTypeType _ChargebackType = ChargebackType;
			AmountType _Amount = Amount;
			ArCheckNumType _CheckNum = CheckNum;
			ChargebackSequenceType _ChargebackSeq = ChargebackSeq;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApproveChargebackSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargebackInvNum", _ChargebackInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargebackType", _ChargebackType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargebackSeq", _ChargebackSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
