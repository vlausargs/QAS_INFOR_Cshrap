//PROJECT NAME: POS
//CLASS NAME: SSSPOSCreatePayh.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSCreatePayh : ISSSPOSCreatePayh
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSCreatePayh(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string BankCode,
			string Infobar) SSSPOSCreatePayhSp(
			string POSMCustNum,
			string CustomerBankCode,
			string PmtType,
			int? CheckNum,
			decimal? AmtToApply,
			Guid? PosmPaymentRowPointer,
			Guid? SessionID,
			string BankCode,
			string Infobar)
		{
			CustNumType _POSMCustNum = POSMCustNum;
			BankCodeType _CustomerBankCode = CustomerBankCode;
			ArpmtTypeType _PmtType = PmtType;
			ArCheckNumType _CheckNum = CheckNum;
			AmountType _AmtToApply = AmtToApply;
			RowPointer _PosmPaymentRowPointer = PosmPaymentRowPointer;
			RowPointer _SessionID = SessionID;
			BankCodeType _BankCode = BankCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSCreatePayhSp";
				
				appDB.AddCommandParameter(cmd, "POSMCustNum", _POSMCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerBankCode", _CustomerBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PmtType", _PmtType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtToApply", _AmtToApply, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PosmPaymentRowPointer", _PosmPaymentRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BankCode = _BankCode;
				Infobar = _Infobar;
				
				return (Severity, BankCode, Infobar);
			}
		}
	}
}
