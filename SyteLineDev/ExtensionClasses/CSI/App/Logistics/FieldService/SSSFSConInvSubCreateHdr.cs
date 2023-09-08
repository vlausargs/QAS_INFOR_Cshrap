//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubCreateHdr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubCreateHdr : ISSSFSConInvSubCreateHdr
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubCreateHdr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InvNum,
			int? InvSeq,
			string SalesAcct,
			string SalesAcctUnit1,
			string SalesAcctUnit2,
			string SalesAcctUnit3,
			string SalesAcctUnit4,
			decimal? ExchRate,
			Guid? ArinvRowPointer,
			string Infobar) SSSFSConInvSubCreateHdrSp(
			string Contract,
			int? SetAllFromContract,
			DateTime? InvDate,
			string InvNum,
			int? InvSeq,
			string SalesAcct,
			string SalesAcctUnit1,
			string SalesAcctUnit2,
			string SalesAcctUnit3,
			string SalesAcctUnit4,
			decimal? ExchRate,
			Guid? ArinvRowPointer,
			string Infobar,
			string CustNum = null,
			int? CustSeq = null,
			string ServType = null,
			string BillFreq = null,
			string BillType = null,
			string ProductCode = null,
			string TermsCode = null,
			string TaxCode1 = null,
			string TaxCode2 = null,
			string Slsman = null,
			string InvCred = "I")
		{
			FSContractType _Contract = Contract;
			ListYesNoType _SetAllFromContract = SetAllFromContract;
			DateType _InvDate = InvDate;
			InvNumType _InvNum = InvNum;
			InvSeqType _InvSeq = InvSeq;
			AcctType _SalesAcct = SalesAcct;
			UnitCode1Type _SalesAcctUnit1 = SalesAcctUnit1;
			UnitCode2Type _SalesAcctUnit2 = SalesAcctUnit2;
			UnitCode3Type _SalesAcctUnit3 = SalesAcctUnit3;
			UnitCode4Type _SalesAcctUnit4 = SalesAcctUnit4;
			ExchRateType _ExchRate = ExchRate;
			RowPointerType _ArinvRowPointer = ArinvRowPointer;
			Infobar _Infobar = Infobar;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			FSContServTypeType _ServType = ServType;
			FSContBillFreqType _BillFreq = BillFreq;
			FSContBillTypeType _BillType = BillType;
			ProductCodeType _ProductCode = ProductCode;
			TermsCodeType _TermsCode = TermsCode;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			SlsmanType _Slsman = Slsman;
			StringType _InvCred = InvCred;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubCreateHdrSp";
				
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetAllFromContract", _SetAllFromContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SalesAcct", _SalesAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SalesAcctUnit1", _SalesAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SalesAcctUnit2", _SalesAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SalesAcctUnit3", _SalesAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SalesAcctUnit4", _SalesAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArinvRowPointer", _ArinvRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServType", _ServType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillFreq", _BillFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillType", _BillType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InvNum = _InvNum;
				InvSeq = _InvSeq;
				SalesAcct = _SalesAcct;
				SalesAcctUnit1 = _SalesAcctUnit1;
				SalesAcctUnit2 = _SalesAcctUnit2;
				SalesAcctUnit3 = _SalesAcctUnit3;
				SalesAcctUnit4 = _SalesAcctUnit4;
				ExchRate = _ExchRate;
				ArinvRowPointer = _ArinvRowPointer;
				Infobar = _Infobar;
				
				return (Severity, InvNum, InvSeq, SalesAcct, SalesAcctUnit1, SalesAcctUnit2, SalesAcctUnit3, SalesAcctUnit4, ExchRate, ArinvRowPointer, Infobar);
			}
		}
	}
}
