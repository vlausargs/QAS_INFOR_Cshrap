//PROJECT NAME: Finance
//CLASS NAME: CreateArPmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class CreateArPmt : ICreateArPmt
	{
		readonly IApplicationDB appDB;
		
		public CreateArPmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CreateArPmtSp(
			string CustNum,
			int? CheckNum,
			DateTime? RecptDate,
			decimal? DomCheckAmt,
			string Ref,
			string Description,
			int? TransferCash,
			string Type,
			string BankCode,
			decimal? ExchRate,
			decimal? ForCheckAmt,
			DateTime? DueDate,
			int? NoteExistsflag,
			string InvNum,
			string Site,
			decimal? DomAmtApplied,
			decimal? DomDiscAmt,
			string DiscAcct,
			decimal? DomAllowAmt,
			string AllowAcct,
			string ApplyCustNum,
			decimal? ForAmtApplied,
			int? CreateArpmt,
			int? CreateArpmtd,
			string Infobar,
			string DiscAcctUnit1,
			string DiscAcctUnit2,
			string DiscAcctUnit3,
			string DiscAcctUnit4,
			decimal? ForDiscAmt,
			decimal? PayCheckAmt,
			decimal? PayExchRate,
			string CurrCode)
		{
			CustNumType _CustNum = CustNum;
			ArCheckNumType _CheckNum = CheckNum;
			DateType _RecptDate = RecptDate;
			AmountType _DomCheckAmt = DomCheckAmt;
			ReferenceType _Ref = Ref;
			DescriptionType _Description = Description;
			ListYesNoType _TransferCash = TransferCash;
			ArinvTypeType _Type = Type;
			BankCodeType _BankCode = BankCode;
			ExchRateType _ExchRate = ExchRate;
			AmountType _ForCheckAmt = ForCheckAmt;
			DateType _DueDate = DueDate;
			FlagNyType _NoteExistsflag = NoteExistsflag;
			InvNumType _InvNum = InvNum;
			SiteType _Site = Site;
			AmountType _DomAmtApplied = DomAmtApplied;
			AmountType _DomDiscAmt = DomDiscAmt;
			AcctType _DiscAcct = DiscAcct;
			AmountType _DomAllowAmt = DomAllowAmt;
			AcctType _AllowAcct = AllowAcct;
			CustNumType _ApplyCustNum = ApplyCustNum;
			AmountType _ForAmtApplied = ForAmtApplied;
			ListYesNoType _CreateArpmt = CreateArpmt;
			ListYesNoType _CreateArpmtd = CreateArpmtd;
			InfobarType _Infobar = Infobar;
			UnitCode1Type _DiscAcctUnit1 = DiscAcctUnit1;
			UnitCode2Type _DiscAcctUnit2 = DiscAcctUnit2;
			UnitCode3Type _DiscAcctUnit3 = DiscAcctUnit3;
			UnitCode4Type _DiscAcctUnit4 = DiscAcctUnit4;
			AmountType _ForDiscAmt = ForDiscAmt;
			AmountType _PayCheckAmt = PayCheckAmt;
			ExchRateType _PayExchRate = PayExchRate;
			CurrCodeType _CurrCode = CurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateArPmtSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecptDate", _RecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCheckAmt", _DomCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Ref", _Ref, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferCash", _TransferCash, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForCheckAmt", _ForCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteExistsflag", _NoteExistsflag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomAmtApplied", _DomAmtApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomDiscAmt", _DomDiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscAcct", _DiscAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomAllowAmt", _DomAllowAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllowAcct", _AllowAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApplyCustNum", _ApplyCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForAmtApplied", _ForAmtApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateArpmt", _CreateArpmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateArpmtd", _CreateArpmtd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DiscAcctUnit1", _DiscAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscAcctUnit2", _DiscAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscAcctUnit3", _DiscAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscAcctUnit4", _DiscAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForDiscAmt", _ForDiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayCheckAmt", _PayCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayExchRate", _PayExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
