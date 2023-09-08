//PROJECT NAME: Data
//CLASS NAME: Prtrxs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Prtrxs : IPrtrxs
	{
		readonly IApplicationDB appDB;
		
		public Prtrxs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PrtrxFwt,
			string PrtrxStateCode,
			string PrtrxCityCode,
			string PrtrxDept,
			decimal? PrtrxSwt,
			decimal? PrtrxSui,
			decimal? PrtrxOst,
			decimal? PrtrxWComp,
			decimal? PrtrxSupplBen,
			decimal? PrtrxSwtG,
			decimal? PrtrxSuiG,
			decimal? PrtrxOstG,
			decimal? PrtrxWCompG,
			decimal? PrtrxSupplBenG,
			decimal? PrtrxCwt,
			decimal? PrtrxCwtG,
			decimal? PrtrxLoan,
			string PrtrxPayFreqs,
			decimal? PrtrxGarn,
			decimal? PrtrxNetPay,
			decimal? PrtrxDepAmt,
			string PrtrxDeCode__1,
			string PrtrxDeCode__2,
			string PrtrxDeCode__3,
			string PrtrxDeCode__4,
			string PrtrxDeCode__5,
			string PrtrxDeCode__6,
			string PrtrxDeCode__7,
			string PrtrxDeCode__8,
			string PrtrxDeCode__9,
			string PrtrxDeCode__10,
			string PrtrxDeCode__11,
			string PrtrxDeCode__12,
			string PrtrxDeCode__13,
			string PrtrxDeCode__14,
			string PrtrxDeCode__15,
			string PrtrxDeCode__16,
			string PrtrxDeCode__17,
			string PrtrxDeCode__18,
			decimal? PrtrxDeAmt__1,
			decimal? PrtrxDeAmt__2,
			decimal? PrtrxDeAmt__3,
			decimal? PrtrxDeAmt__4,
			decimal? PrtrxDeAmt__5,
			decimal? PrtrxDeAmt__6,
			decimal? PrtrxDeAmt__7,
			decimal? PrtrxDeAmt__8,
			decimal? PrtrxDeAmt__9,
			decimal? PrtrxDeAmt__10,
			decimal? PrtrxDeAmt__11,
			decimal? PrtrxDeAmt__12,
			decimal? PrtrxDeAmt__13,
			decimal? PrtrxDeAmt__14,
			decimal? PrtrxDeAmt__15,
			decimal? PrtrxDeAmt__16,
			decimal? PrtrxDeAmt__17,
			decimal? PrtrxDeAmt__18,
			decimal? TDeBal__1,
			decimal? TDeBal__2,
			decimal? TDeBal__3,
			decimal? TDeBal__4,
			decimal? TDeBal__5,
			decimal? TDeBal__6,
			decimal? TDeBal__7,
			decimal? TDeBal__8,
			decimal? TDeBal__9,
			decimal? TDeBal__10,
			decimal? TDeBal__11,
			decimal? TDeBal__12,
			decimal? TDeBal__13,
			decimal? TDeBal__14,
			decimal? TDeBal__15,
			string Infobar,
			int? SchedDirDepExceedNetPay,
			decimal? PrtrxEmprCon,
			decimal? PrtrxEmprConG) PrtrxsSp(
			decimal? TFreqMult,
			decimal? TYtdSuiGrs,
			decimal? TYtdFica,
			decimal? TYtdMed,
			decimal? TYtdOstGrs,
			decimal? TYtdSbGrs,
			decimal? TYtdWcGrs,
			decimal? TLoanBal,
			decimal? TGarnBal,
			string PrtrxEmpNum,
			int? PrtrxDepDtlSeq,
			string PrtrxWCompCode,
			decimal? PrtrxEFica,
			decimal? PrtrxEMed,
			decimal? PrtrxFwt,
			decimal? PrtrxGrossPay,
			decimal? PrtrxSupplEarn,
			decimal? PrtrxWorkUnits,
			decimal? PrtrxEic,
			decimal? PrtrxUnionDed,
			string PrtrxType,
			int? PrtrxCheckNum,
			decimal? NetEmployeeAddFwtAmt,
			string PrtrxStateCode,
			string PrtrxCityCode,
			string PrtrxDept,
			decimal? PrtrxSwt,
			decimal? PrtrxSui,
			decimal? PrtrxOst,
			decimal? PrtrxWComp,
			decimal? PrtrxSupplBen,
			decimal? PrtrxSwtG,
			decimal? PrtrxSuiG,
			decimal? PrtrxOstG,
			decimal? PrtrxWCompG,
			decimal? PrtrxSupplBenG,
			decimal? PrtrxCwt,
			decimal? PrtrxCwtG,
			decimal? PrtrxLoan,
			string PrtrxPayFreqs,
			decimal? PrtrxGarn,
			decimal? PrtrxNetPay,
			decimal? PrtrxDepAmt,
			string PrtrxDeCode__1,
			string PrtrxDeCode__2,
			string PrtrxDeCode__3,
			string PrtrxDeCode__4,
			string PrtrxDeCode__5,
			string PrtrxDeCode__6,
			string PrtrxDeCode__7,
			string PrtrxDeCode__8,
			string PrtrxDeCode__9,
			string PrtrxDeCode__10,
			string PrtrxDeCode__11,
			string PrtrxDeCode__12,
			string PrtrxDeCode__13,
			string PrtrxDeCode__14,
			string PrtrxDeCode__15,
			string PrtrxDeCode__16,
			string PrtrxDeCode__17,
			string PrtrxDeCode__18,
			decimal? PrtrxDeAmt__1,
			decimal? PrtrxDeAmt__2,
			decimal? PrtrxDeAmt__3,
			decimal? PrtrxDeAmt__4,
			decimal? PrtrxDeAmt__5,
			decimal? PrtrxDeAmt__6,
			decimal? PrtrxDeAmt__7,
			decimal? PrtrxDeAmt__8,
			decimal? PrtrxDeAmt__9,
			decimal? PrtrxDeAmt__10,
			decimal? PrtrxDeAmt__11,
			decimal? PrtrxDeAmt__12,
			decimal? PrtrxDeAmt__13,
			decimal? PrtrxDeAmt__14,
			decimal? PrtrxDeAmt__15,
			decimal? PrtrxDeAmt__16,
			decimal? PrtrxDeAmt__17,
			decimal? PrtrxDeAmt__18,
			decimal? TDeBal__1,
			decimal? TDeBal__2,
			decimal? TDeBal__3,
			decimal? TDeBal__4,
			decimal? TDeBal__5,
			decimal? TDeBal__6,
			decimal? TDeBal__7,
			decimal? TDeBal__8,
			decimal? TDeBal__9,
			decimal? TDeBal__10,
			decimal? TDeBal__11,
			decimal? TDeBal__12,
			decimal? TDeBal__13,
			decimal? TDeBal__14,
			decimal? TDeBal__15,
			string Infobar,
			int? SchedDirDepExceedNetPay,
			decimal? TEmpTot,
			decimal? TYtdEmprCon,
			decimal? TYrPay,
			decimal? TYtdEmpCon,
			decimal? PrparmsMaxEmprPct,
			decimal? PrparmsMaxEmprAmt,
			string PrparmsRetType,
			int? PrparmsRetLimit,
			decimal? PrtrxEmprCon,
			decimal? PrtrxEmprConG)
		{
			GenericDecimalType _TFreqMult = TFreqMult;
			PrYtdAmountType _TYtdSuiGrs = TYtdSuiGrs;
			PrYtdAmountType _TYtdFica = TYtdFica;
			PrYtdAmountType _TYtdMed = TYtdMed;
			PrYtdAmountType _TYtdOstGrs = TYtdOstGrs;
			PrYtdAmountType _TYtdSbGrs = TYtdSbGrs;
			PrYtdAmountType _TYtdWcGrs = TYtdWcGrs;
			PrAmountType _TLoanBal = TLoanBal;
			PrAmountType _TGarnBal = TGarnBal;
			EmpNumType _PrtrxEmpNum = PrtrxEmpNum;
			PrtrxSeqType _PrtrxDepDtlSeq = PrtrxDepDtlSeq;
			DeCodeType _PrtrxWCompCode = PrtrxWCompCode;
			PrAmountType _PrtrxEFica = PrtrxEFica;
			PrAmountType _PrtrxEMed = PrtrxEMed;
			PrAmountType _PrtrxFwt = PrtrxFwt;
			PrAmountType _PrtrxGrossPay = PrtrxGrossPay;
			PrAmountType _PrtrxSupplEarn = PrtrxSupplEarn;
			PrAmountType _PrtrxWorkUnits = PrtrxWorkUnits;
			PrAmountType _PrtrxEic = PrtrxEic;
			PrAmountType _PrtrxUnionDed = PrtrxUnionDed;
			PrtrxTypeType _PrtrxType = PrtrxType;
			PrCheckNumType _PrtrxCheckNum = PrtrxCheckNum;
			PrDeductionType _NetEmployeeAddFwtAmt = NetEmployeeAddFwtAmt;
			PrTaxCodeType _PrtrxStateCode = PrtrxStateCode;
			PrTaxCodeType _PrtrxCityCode = PrtrxCityCode;
			DeptType _PrtrxDept = PrtrxDept;
			PrAmountType _PrtrxSwt = PrtrxSwt;
			PrAmountType _PrtrxSui = PrtrxSui;
			PrAmountType _PrtrxOst = PrtrxOst;
			PrAmountType _PrtrxWComp = PrtrxWComp;
			PrAmountType _PrtrxSupplBen = PrtrxSupplBen;
			PrAmountType _PrtrxSwtG = PrtrxSwtG;
			PrAmountType _PrtrxSuiG = PrtrxSuiG;
			PrAmountType _PrtrxOstG = PrtrxOstG;
			PrAmountType _PrtrxWCompG = PrtrxWCompG;
			PrAmountType _PrtrxSupplBenG = PrtrxSupplBenG;
			PrAmountType _PrtrxCwt = PrtrxCwt;
			PrAmountType _PrtrxCwtG = PrtrxCwtG;
			PrAmountType _PrtrxLoan = PrtrxLoan;
			PrPayFreqsType _PrtrxPayFreqs = PrtrxPayFreqs;
			PrAmountType _PrtrxGarn = PrtrxGarn;
			PrAmountType _PrtrxNetPay = PrtrxNetPay;
			PrAmountType _PrtrxDepAmt = PrtrxDepAmt;
			DeCodeType _PrtrxDeCode__1 = PrtrxDeCode__1;
			DeCodeType _PrtrxDeCode__2 = PrtrxDeCode__2;
			DeCodeType _PrtrxDeCode__3 = PrtrxDeCode__3;
			DeCodeType _PrtrxDeCode__4 = PrtrxDeCode__4;
			DeCodeType _PrtrxDeCode__5 = PrtrxDeCode__5;
			DeCodeType _PrtrxDeCode__6 = PrtrxDeCode__6;
			DeCodeType _PrtrxDeCode__7 = PrtrxDeCode__7;
			DeCodeType _PrtrxDeCode__8 = PrtrxDeCode__8;
			DeCodeType _PrtrxDeCode__9 = PrtrxDeCode__9;
			DeCodeType _PrtrxDeCode__10 = PrtrxDeCode__10;
			DeCodeType _PrtrxDeCode__11 = PrtrxDeCode__11;
			DeCodeType _PrtrxDeCode__12 = PrtrxDeCode__12;
			DeCodeType _PrtrxDeCode__13 = PrtrxDeCode__13;
			DeCodeType _PrtrxDeCode__14 = PrtrxDeCode__14;
			DeCodeType _PrtrxDeCode__15 = PrtrxDeCode__15;
			DeCodeType _PrtrxDeCode__16 = PrtrxDeCode__16;
			DeCodeType _PrtrxDeCode__17 = PrtrxDeCode__17;
			DeCodeType _PrtrxDeCode__18 = PrtrxDeCode__18;
			PrAmountType _PrtrxDeAmt__1 = PrtrxDeAmt__1;
			PrAmountType _PrtrxDeAmt__2 = PrtrxDeAmt__2;
			PrAmountType _PrtrxDeAmt__3 = PrtrxDeAmt__3;
			PrAmountType _PrtrxDeAmt__4 = PrtrxDeAmt__4;
			PrAmountType _PrtrxDeAmt__5 = PrtrxDeAmt__5;
			PrAmountType _PrtrxDeAmt__6 = PrtrxDeAmt__6;
			PrAmountType _PrtrxDeAmt__7 = PrtrxDeAmt__7;
			PrAmountType _PrtrxDeAmt__8 = PrtrxDeAmt__8;
			PrAmountType _PrtrxDeAmt__9 = PrtrxDeAmt__9;
			PrAmountType _PrtrxDeAmt__10 = PrtrxDeAmt__10;
			PrAmountType _PrtrxDeAmt__11 = PrtrxDeAmt__11;
			PrAmountType _PrtrxDeAmt__12 = PrtrxDeAmt__12;
			PrAmountType _PrtrxDeAmt__13 = PrtrxDeAmt__13;
			PrAmountType _PrtrxDeAmt__14 = PrtrxDeAmt__14;
			PrAmountType _PrtrxDeAmt__15 = PrtrxDeAmt__15;
			PrAmountType _PrtrxDeAmt__16 = PrtrxDeAmt__16;
			PrAmountType _PrtrxDeAmt__17 = PrtrxDeAmt__17;
			PrAmountType _PrtrxDeAmt__18 = PrtrxDeAmt__18;
			PrAmountType _TDeBal__1 = TDeBal__1;
			PrAmountType _TDeBal__2 = TDeBal__2;
			PrAmountType _TDeBal__3 = TDeBal__3;
			PrAmountType _TDeBal__4 = TDeBal__4;
			PrAmountType _TDeBal__5 = TDeBal__5;
			PrAmountType _TDeBal__6 = TDeBal__6;
			PrAmountType _TDeBal__7 = TDeBal__7;
			PrAmountType _TDeBal__8 = TDeBal__8;
			PrAmountType _TDeBal__9 = TDeBal__9;
			PrAmountType _TDeBal__10 = TDeBal__10;
			PrAmountType _TDeBal__11 = TDeBal__11;
			PrAmountType _TDeBal__12 = TDeBal__12;
			PrAmountType _TDeBal__13 = TDeBal__13;
			PrAmountType _TDeBal__14 = TDeBal__14;
			PrAmountType _TDeBal__15 = TDeBal__15;
			InfobarType _Infobar = Infobar;
			ListYesNoType _SchedDirDepExceedNetPay = SchedDirDepExceedNetPay;
			PrAmountType _TEmpTot = TEmpTot;
			AnnualSalaryType _TYtdEmprCon = TYtdEmprCon;
			GenericDecimalType _TYrPay = TYrPay;
			AnnualSalaryType _TYtdEmpCon = TYtdEmpCon;
			RetirePercentType _PrparmsMaxEmprPct = PrparmsMaxEmprPct;
			RetireAmountType _PrparmsMaxEmprAmt = PrparmsMaxEmprAmt;
			RetireBasisType _PrparmsRetType = PrparmsRetType;
			ListYesNoType _PrparmsRetLimit = PrparmsRetLimit;
			PrAmountType _PrtrxEmprCon = PrtrxEmprCon;
			PrAmountType _PrtrxEmprConG = PrtrxEmprConG;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrtrxsSp";
				
				appDB.AddCommandParameter(cmd, "TFreqMult", _TFreqMult, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TYtdSuiGrs", _TYtdSuiGrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TYtdFica", _TYtdFica, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TYtdMed", _TYtdMed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TYtdOstGrs", _TYtdOstGrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TYtdSbGrs", _TYtdSbGrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TYtdWcGrs", _TYtdWcGrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLoanBal", _TLoanBal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TGarnBal", _TGarnBal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxEmpNum", _PrtrxEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDepDtlSeq", _PrtrxDepDtlSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxWCompCode", _PrtrxWCompCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxEFica", _PrtrxEFica, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxEMed", _PrtrxEMed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxFwt", _PrtrxFwt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxGrossPay", _PrtrxGrossPay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxSupplEarn", _PrtrxSupplEarn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxWorkUnits", _PrtrxWorkUnits, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxEic", _PrtrxEic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxUnionDed", _PrtrxUnionDed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxType", _PrtrxType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxCheckNum", _PrtrxCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NetEmployeeAddFwtAmt", _NetEmployeeAddFwtAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxStateCode", _PrtrxStateCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxCityCode", _PrtrxCityCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDept", _PrtrxDept, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxSwt", _PrtrxSwt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxSui", _PrtrxSui, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxOst", _PrtrxOst, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxWComp", _PrtrxWComp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxSupplBen", _PrtrxSupplBen, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxSwtG", _PrtrxSwtG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxSuiG", _PrtrxSuiG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxOstG", _PrtrxOstG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxWCompG", _PrtrxWCompG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxSupplBenG", _PrtrxSupplBenG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxCwt", _PrtrxCwt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxCwtG", _PrtrxCwtG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxLoan", _PrtrxLoan, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxPayFreqs", _PrtrxPayFreqs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxGarn", _PrtrxGarn, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxNetPay", _PrtrxNetPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDepAmt", _PrtrxDepAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##1", _PrtrxDeCode__1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##2", _PrtrxDeCode__2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##3", _PrtrxDeCode__3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##4", _PrtrxDeCode__4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##5", _PrtrxDeCode__5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##6", _PrtrxDeCode__6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##7", _PrtrxDeCode__7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##8", _PrtrxDeCode__8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##9", _PrtrxDeCode__9, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##10", _PrtrxDeCode__10, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##11", _PrtrxDeCode__11, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##12", _PrtrxDeCode__12, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##13", _PrtrxDeCode__13, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##14", _PrtrxDeCode__14, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##15", _PrtrxDeCode__15, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##16", _PrtrxDeCode__16, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##17", _PrtrxDeCode__17, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##18", _PrtrxDeCode__18, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##1", _PrtrxDeAmt__1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##2", _PrtrxDeAmt__2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##3", _PrtrxDeAmt__3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##4", _PrtrxDeAmt__4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##5", _PrtrxDeAmt__5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##6", _PrtrxDeAmt__6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##7", _PrtrxDeAmt__7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##8", _PrtrxDeAmt__8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##9", _PrtrxDeAmt__9, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##10", _PrtrxDeAmt__10, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##11", _PrtrxDeAmt__11, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##12", _PrtrxDeAmt__12, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##13", _PrtrxDeAmt__13, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##14", _PrtrxDeAmt__14, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##15", _PrtrxDeAmt__15, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##16", _PrtrxDeAmt__16, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##17", _PrtrxDeAmt__17, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##18", _PrtrxDeAmt__18, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDeBal##1", _TDeBal__1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDeBal##2", _TDeBal__2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDeBal##3", _TDeBal__3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDeBal##4", _TDeBal__4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDeBal##5", _TDeBal__5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDeBal##6", _TDeBal__6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDeBal##7", _TDeBal__7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDeBal##8", _TDeBal__8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDeBal##9", _TDeBal__9, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDeBal##10", _TDeBal__10, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDeBal##11", _TDeBal__11, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDeBal##12", _TDeBal__12, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDeBal##13", _TDeBal__13, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDeBal##14", _TDeBal__14, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDeBal##15", _TDeBal__15, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SchedDirDepExceedNetPay", _SchedDirDepExceedNetPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TEmpTot", _TEmpTot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TYtdEmprCon", _TYtdEmprCon, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TYrPay", _TYrPay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TYtdEmpCon", _TYtdEmpCon, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrparmsMaxEmprPct", _PrparmsMaxEmprPct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrparmsMaxEmprAmt", _PrparmsMaxEmprAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrparmsRetType", _PrparmsRetType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrparmsRetLimit", _PrparmsRetLimit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxEmprCon", _PrtrxEmprCon, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxEmprConG", _PrtrxEmprConG, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PrtrxFwt = _PrtrxFwt;
				PrtrxStateCode = _PrtrxStateCode;
				PrtrxCityCode = _PrtrxCityCode;
				PrtrxDept = _PrtrxDept;
				PrtrxSwt = _PrtrxSwt;
				PrtrxSui = _PrtrxSui;
				PrtrxOst = _PrtrxOst;
				PrtrxWComp = _PrtrxWComp;
				PrtrxSupplBen = _PrtrxSupplBen;
				PrtrxSwtG = _PrtrxSwtG;
				PrtrxSuiG = _PrtrxSuiG;
				PrtrxOstG = _PrtrxOstG;
				PrtrxWCompG = _PrtrxWCompG;
				PrtrxSupplBenG = _PrtrxSupplBenG;
				PrtrxCwt = _PrtrxCwt;
				PrtrxCwtG = _PrtrxCwtG;
				PrtrxLoan = _PrtrxLoan;
				PrtrxPayFreqs = _PrtrxPayFreqs;
				PrtrxGarn = _PrtrxGarn;
				PrtrxNetPay = _PrtrxNetPay;
				PrtrxDepAmt = _PrtrxDepAmt;
				PrtrxDeCode__1 = _PrtrxDeCode__1;
				PrtrxDeCode__2 = _PrtrxDeCode__2;
				PrtrxDeCode__3 = _PrtrxDeCode__3;
				PrtrxDeCode__4 = _PrtrxDeCode__4;
				PrtrxDeCode__5 = _PrtrxDeCode__5;
				PrtrxDeCode__6 = _PrtrxDeCode__6;
				PrtrxDeCode__7 = _PrtrxDeCode__7;
				PrtrxDeCode__8 = _PrtrxDeCode__8;
				PrtrxDeCode__9 = _PrtrxDeCode__9;
				PrtrxDeCode__10 = _PrtrxDeCode__10;
				PrtrxDeCode__11 = _PrtrxDeCode__11;
				PrtrxDeCode__12 = _PrtrxDeCode__12;
				PrtrxDeCode__13 = _PrtrxDeCode__13;
				PrtrxDeCode__14 = _PrtrxDeCode__14;
				PrtrxDeCode__15 = _PrtrxDeCode__15;
				PrtrxDeCode__16 = _PrtrxDeCode__16;
				PrtrxDeCode__17 = _PrtrxDeCode__17;
				PrtrxDeCode__18 = _PrtrxDeCode__18;
				PrtrxDeAmt__1 = _PrtrxDeAmt__1;
				PrtrxDeAmt__2 = _PrtrxDeAmt__2;
				PrtrxDeAmt__3 = _PrtrxDeAmt__3;
				PrtrxDeAmt__4 = _PrtrxDeAmt__4;
				PrtrxDeAmt__5 = _PrtrxDeAmt__5;
				PrtrxDeAmt__6 = _PrtrxDeAmt__6;
				PrtrxDeAmt__7 = _PrtrxDeAmt__7;
				PrtrxDeAmt__8 = _PrtrxDeAmt__8;
				PrtrxDeAmt__9 = _PrtrxDeAmt__9;
				PrtrxDeAmt__10 = _PrtrxDeAmt__10;
				PrtrxDeAmt__11 = _PrtrxDeAmt__11;
				PrtrxDeAmt__12 = _PrtrxDeAmt__12;
				PrtrxDeAmt__13 = _PrtrxDeAmt__13;
				PrtrxDeAmt__14 = _PrtrxDeAmt__14;
				PrtrxDeAmt__15 = _PrtrxDeAmt__15;
				PrtrxDeAmt__16 = _PrtrxDeAmt__16;
				PrtrxDeAmt__17 = _PrtrxDeAmt__17;
				PrtrxDeAmt__18 = _PrtrxDeAmt__18;
				TDeBal__1 = _TDeBal__1;
				TDeBal__2 = _TDeBal__2;
				TDeBal__3 = _TDeBal__3;
				TDeBal__4 = _TDeBal__4;
				TDeBal__5 = _TDeBal__5;
				TDeBal__6 = _TDeBal__6;
				TDeBal__7 = _TDeBal__7;
				TDeBal__8 = _TDeBal__8;
				TDeBal__9 = _TDeBal__9;
				TDeBal__10 = _TDeBal__10;
				TDeBal__11 = _TDeBal__11;
				TDeBal__12 = _TDeBal__12;
				TDeBal__13 = _TDeBal__13;
				TDeBal__14 = _TDeBal__14;
				TDeBal__15 = _TDeBal__15;
				Infobar = _Infobar;
				SchedDirDepExceedNetPay = _SchedDirDepExceedNetPay;
				PrtrxEmprCon = _PrtrxEmprCon;
				PrtrxEmprConG = _PrtrxEmprConG;
				
				return (Severity, PrtrxFwt, PrtrxStateCode, PrtrxCityCode, PrtrxDept, PrtrxSwt, PrtrxSui, PrtrxOst, PrtrxWComp, PrtrxSupplBen, PrtrxSwtG, PrtrxSuiG, PrtrxOstG, PrtrxWCompG, PrtrxSupplBenG, PrtrxCwt, PrtrxCwtG, PrtrxLoan, PrtrxPayFreqs, PrtrxGarn, PrtrxNetPay, PrtrxDepAmt, PrtrxDeCode__1, PrtrxDeCode__2, PrtrxDeCode__3, PrtrxDeCode__4, PrtrxDeCode__5, PrtrxDeCode__6, PrtrxDeCode__7, PrtrxDeCode__8, PrtrxDeCode__9, PrtrxDeCode__10, PrtrxDeCode__11, PrtrxDeCode__12, PrtrxDeCode__13, PrtrxDeCode__14, PrtrxDeCode__15, PrtrxDeCode__16, PrtrxDeCode__17, PrtrxDeCode__18, PrtrxDeAmt__1, PrtrxDeAmt__2, PrtrxDeAmt__3, PrtrxDeAmt__4, PrtrxDeAmt__5, PrtrxDeAmt__6, PrtrxDeAmt__7, PrtrxDeAmt__8, PrtrxDeAmt__9, PrtrxDeAmt__10, PrtrxDeAmt__11, PrtrxDeAmt__12, PrtrxDeAmt__13, PrtrxDeAmt__14, PrtrxDeAmt__15, PrtrxDeAmt__16, PrtrxDeAmt__17, PrtrxDeAmt__18, TDeBal__1, TDeBal__2, TDeBal__3, TDeBal__4, TDeBal__5, TDeBal__6, TDeBal__7, TDeBal__8, TDeBal__9, TDeBal__10, TDeBal__11, TDeBal__12, TDeBal__13, TDeBal__14, TDeBal__15, Infobar, SchedDirDepExceedNetPay, PrtrxEmprCon, PrtrxEmprConG);
			}
		}
	}
}
