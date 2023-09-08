//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROInvSubCreateHdr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROInvSubCreateHdr : ISSSFSSROInvSubCreateHdr
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROInvSubCreateHdr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InvNum,
			Guid? ArinvRowPointer,
			string Infobar) SSSFSSROInvSubCreateHdrSp(
			string Mode,
			string CustNum,
			int? CustSeq,
			string TaxCode1,
			string TaxCode2,
			string TermsCode,
			string SRONum,
			string InvCred,
			DateTime? InvDate,
			string ArAcct,
			string ArAcctUnit1,
			string ArAcctUnit2,
			string ArAcctUnit3,
			string ArAcctUnit4,
			string InvNum,
			Guid? ArinvRowPointer,
			string Infobar)
		{
			StringType _Mode = Mode;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			TermsCodeType _TermsCode = TermsCode;
			FSSRONumType _SRONum = SRONum;
			StringType _InvCred = InvCred;
			DateType _InvDate = InvDate;
			AcctType _ArAcct = ArAcct;
			UnitCode1Type _ArAcctUnit1 = ArAcctUnit1;
			UnitCode2Type _ArAcctUnit2 = ArAcctUnit2;
			UnitCode3Type _ArAcctUnit3 = ArAcctUnit3;
			UnitCode4Type _ArAcctUnit4 = ArAcctUnit4;
			InvNumType _InvNum = InvNum;
			RowPointerType _ArinvRowPointer = ArinvRowPointer;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROInvSubCreateHdrSp";
				
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArAcct", _ArAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArAcctUnit1", _ArAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArAcctUnit2", _ArAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArAcctUnit3", _ArAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArAcctUnit4", _ArAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArinvRowPointer", _ArinvRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InvNum = _InvNum;
				ArinvRowPointer = _ArinvRowPointer;
				Infobar = _Infobar;
				
				return (Severity, InvNum, ArinvRowPointer, Infobar);
			}
		}
	}
}
