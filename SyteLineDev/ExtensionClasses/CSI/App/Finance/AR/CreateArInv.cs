//PROJECT NAME: Finance
//CLASS NAME: CreateArInv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class CreateArInv : ICreateArInv
	{
		readonly IApplicationDB appDB;
		
		public CreateArInv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CreateArInvSp(
			string CustNum,
			string InvNum,
			string Type,
			string CoNum,
			DateTime? InvDate,
			DateTime? DueDate,
			decimal? Amount,
			decimal? MiscCharges,
			decimal? SalesTax,
			decimal? Freight,
			string _ref,
			string TermsCode,
			string Description,
			int? PostFromCo,
			decimal? ExchRate,
			decimal? SalesTax2,
			int? UseExchRate,
			string TaxCode1,
			string TaxCode2,
			string Acct,
			string AcctUnit1,
			string AcctUnit2,
			string AcctUnit3,
			string AcctUnit4,
			string DistAcct,
			string DistAcctUnit1,
			string DistAcctUnit2,
			string DistAcctUnit3,
			string DistAcctUnit4,
			int? FixedRate,
			int? Rma,
			string PayType,
			int? DraftPrintFlag,
			string DoNum,
			int? NoteExistsflag,
			string Infobar,
			int? ReturnedCheck,
			string DiscAcct,
			string DiscAcctUnit1,
			string DiscAcctUnit2,
			string DiscAcctUnit3,
			string DiscAcctUnit4,
			decimal? DiscAmt,
			decimal? ShipmentId)
		{
			CustNumType _CustNum = CustNum;
			InvNumType _InvNum = InvNum;
			ArinvTypeType _Type = Type;
			CoNumType _CoNum = CoNum;
			DateType _InvDate = InvDate;
			DateType _DueDate = DueDate;
			AmountType _Amount = Amount;
			AmountType _MiscCharges = MiscCharges;
			AmountType _SalesTax = SalesTax;
			AmountType _Freight = Freight;
			ReferenceType __ref = _ref;
			TermsCodeType _TermsCode = TermsCode;
			DescriptionType _Description = Description;
			ListYesNoType _PostFromCo = PostFromCo;
			ExchRateType _ExchRate = ExchRate;
			AmountType _SalesTax2 = SalesTax2;
			ListYesNoType _UseExchRate = UseExchRate;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			AcctType _Acct = Acct;
			UnitCode1Type _AcctUnit1 = AcctUnit1;
			UnitCode2Type _AcctUnit2 = AcctUnit2;
			UnitCode3Type _AcctUnit3 = AcctUnit3;
			UnitCode4Type _AcctUnit4 = AcctUnit4;
			AcctType _DistAcct = DistAcct;
			UnitCode1Type _DistAcctUnit1 = DistAcctUnit1;
			UnitCode2Type _DistAcctUnit2 = DistAcctUnit2;
			UnitCode3Type _DistAcctUnit3 = DistAcctUnit3;
			UnitCode4Type _DistAcctUnit4 = DistAcctUnit4;
			ListYesNoType _FixedRate = FixedRate;
			ListYesNoType _Rma = Rma;
			CustPayTypeType _PayType = PayType;
			ListYesNoType _DraftPrintFlag = DraftPrintFlag;
			DoNumType _DoNum = DoNum;
			FlagNyType _NoteExistsflag = NoteExistsflag;
			InfobarType _Infobar = Infobar;
			ListYesNoType _ReturnedCheck = ReturnedCheck;
			AcctType _DiscAcct = DiscAcct;
			UnitCode1Type _DiscAcctUnit1 = DiscAcctUnit1;
			UnitCode2Type _DiscAcctUnit2 = DiscAcctUnit2;
			UnitCode3Type _DiscAcctUnit3 = DiscAcctUnit3;
			UnitCode4Type _DiscAcctUnit4 = DiscAcctUnit4;
			AmountType _DiscAmt = DiscAmt;
			ShipmentIDType _ShipmentId = ShipmentId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateArInvSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscCharges", _MiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTax", _SalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Freight", _Freight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ref", __ref, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostFromCo", _PostFromCo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTax2", _SalesTax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseExchRate", _UseExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit1", _AcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit2", _AcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit3", _AcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit4", _AcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistAcct", _DistAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistAcctUnit1", _DistAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistAcctUnit2", _DistAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistAcctUnit3", _DistAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistAcctUnit4", _DistAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FixedRate", _FixedRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Rma", _Rma, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DraftPrintFlag", _DraftPrintFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoNum", _DoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteExistsflag", _NoteExistsflag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReturnedCheck", _ReturnedCheck, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscAcct", _DiscAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscAcctUnit1", _DiscAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscAcctUnit2", _DiscAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscAcctUnit3", _DiscAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscAcctUnit4", _DiscAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscAmt", _DiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
