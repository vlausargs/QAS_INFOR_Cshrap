//PROJECT NAME: Data
//CLASS NAME: InvPostA.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InvPostA : IInvPostA
	{
		readonly IApplicationDB appDB;
		
		public InvPostA(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PInvNum,
			int? PPrintFlag,
			int? TAcctError,
			string Infobar) InvPostASp(
			string PRecIdCo,
			decimal? PMiscCharges,
			decimal? PSalesTax,
			decimal? PFreight,
			string PDest,
			string PInvOrCm,
			int? PNonDraftCust,
			int? PProgBillText,
			string PLineRelText,
			int? PPlanItemMtls,
			int? PLCR,
			int? PSerNums,
			string PConfDets,
			int? PPRTVals,
			int? POrdNums,
			int? PTransToDomCur,
			int? PEuroTotal,
			string PInvNum,
			DateTime? PInvDate,
			string PCustNumStart,
			string PCustNumEnd,
			string PCoNumStart,
			string PCoNumEnd,
			DateTime? PLastShipDateStart,
			DateTime? PLastShipDateEnd,
			string PDoNumStart,
			string PDoNumEnd,
			string PCustPOStart,
			string PCustPOEnd,
			string PInvNumRepStart,
			string PInvNumRepEnd,
			DateTime? PInvDateRepStart,
			DateTime? PInvDateRepEnd,
			int? PItemTypeItem,
			int? PItemTypeCust,
			int? PTextOrd,
			int? PTextStandOrd,
			int? PTextCustMast,
			int? PTextBillTo,
			int? PTextNone,
			string TOpt,
			int? TDispFLine,
			int? TDispFInv,
			string TCustPT,
			string TInvStart,
			string TInvEnd,
			int? PPrintFlag,
			int? TAcctError,
			string Infobar,
			Guid? pProcessId = null,
			string PApplyToInvNum = null)
		{
			CoNumType _PRecIdCo = PRecIdCo;
			AmountType _PMiscCharges = PMiscCharges;
			AmountType _PSalesTax = PSalesTax;
			AmountType _PFreight = PFreight;
			StringType _PDest = PDest;
			StringType _PInvOrCm = PInvOrCm;
			ListYesNoType _PNonDraftCust = PNonDraftCust;
			ListYesNoType _PProgBillText = PProgBillText;
			StringType _PLineRelText = PLineRelText;
			ListYesNoType _PPlanItemMtls = PPlanItemMtls;
			ListYesNoType _PLCR = PLCR;
			ListYesNoType _PSerNums = PSerNums;
			StringType _PConfDets = PConfDets;
			ListYesNoType _PPRTVals = PPRTVals;
			ListYesNoType _POrdNums = POrdNums;
			ListYesNoType _PTransToDomCur = PTransToDomCur;
			ListYesNoType _PEuroTotal = PEuroTotal;
			InvNumType _PInvNum = PInvNum;
			DateType _PInvDate = PInvDate;
			CustNumType _PCustNumStart = PCustNumStart;
			CustNumType _PCustNumEnd = PCustNumEnd;
			CoNumType _PCoNumStart = PCoNumStart;
			CoNumType _PCoNumEnd = PCoNumEnd;
			DateType _PLastShipDateStart = PLastShipDateStart;
			DateType _PLastShipDateEnd = PLastShipDateEnd;
			DoNumType _PDoNumStart = PDoNumStart;
			DoNumType _PDoNumEnd = PDoNumEnd;
			CustPoType _PCustPOStart = PCustPOStart;
			CustPoType _PCustPOEnd = PCustPOEnd;
			InvNumType _PInvNumRepStart = PInvNumRepStart;
			InvNumType _PInvNumRepEnd = PInvNumRepEnd;
			DateType _PInvDateRepStart = PInvDateRepStart;
			DateType _PInvDateRepEnd = PInvDateRepEnd;
			ListYesNoType _PItemTypeItem = PItemTypeItem;
			ListYesNoType _PItemTypeCust = PItemTypeCust;
			ListYesNoType _PTextOrd = PTextOrd;
			ListYesNoType _PTextStandOrd = PTextStandOrd;
			ListYesNoType _PTextCustMast = PTextCustMast;
			ListYesNoType _PTextBillTo = PTextBillTo;
			ListYesNoType _PTextNone = PTextNone;
			StringType _TOpt = TOpt;
			ListYesNoType _TDispFLine = TDispFLine;
			ListYesNoType _TDispFInv = TDispFInv;
			CustPayTypeType _TCustPT = TCustPT;
			InvNumType _TInvStart = TInvStart;
			InvNumType _TInvEnd = TInvEnd;
			ListYesNoType _PPrintFlag = PPrintFlag;
			ListYesNoType _TAcctError = TAcctError;
			InfobarType _Infobar = Infobar;
			RowPointerType _pProcessId = pProcessId;
			InvNumType _PApplyToInvNum = PApplyToInvNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvPostASp";
				
				appDB.AddCommandParameter(cmd, "PRecIdCo", _PRecIdCo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMiscCharges", _PMiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax", _PSalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFreight", _PFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDest", _PDest, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvOrCm", _PInvOrCm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNonDraftCust", _PNonDraftCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProgBillText", _PProgBillText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLineRelText", _PLineRelText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPlanItemMtls", _PPlanItemMtls, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLCR", _PLCR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSerNums", _PSerNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PConfDets", _PConfDets, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPRTVals", _PPRTVals, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrdNums", _POrdNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransToDomCur", _PTransToDomCur, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEuroTotal", _PEuroTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNumStart", _PCustNumStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNumEnd", _PCustNumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNumStart", _PCoNumStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNumEnd", _PCoNumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLastShipDateStart", _PLastShipDateStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLastShipDateEnd", _PLastShipDateEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDoNumStart", _PDoNumStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDoNumEnd", _PDoNumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustPOStart", _PCustPOStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustPOEnd", _PCustPOEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNumRepStart", _PInvNumRepStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNumRepEnd", _PInvNumRepEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDateRepStart", _PInvDateRepStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDateRepEnd", _PInvDateRepEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemTypeItem", _PItemTypeItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemTypeCust", _PItemTypeCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTextOrd", _PTextOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTextStandOrd", _PTextStandOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTextCustMast", _PTextCustMast, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTextBillTo", _PTextBillTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTextNone", _PTextNone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOpt", _TOpt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDispFLine", _TDispFLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDispFInv", _TDispFInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCustPT", _TCustPT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TInvStart", _TInvStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TInvEnd", _TInvEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrintFlag", _PPrintFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TAcctError", _TAcctError, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pProcessId", _pProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PApplyToInvNum", _PApplyToInvNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PInvNum = _PInvNum;
				PPrintFlag = _PPrintFlag;
				TAcctError = _TAcctError;
				Infobar = _Infobar;
				
				return (Severity, PInvNum, PPrintFlag, TAcctError, Infobar);
			}
		}
	}
}
