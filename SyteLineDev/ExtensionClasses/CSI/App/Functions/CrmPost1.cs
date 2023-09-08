//PROJECT NAME: Data
//CLASS NAME: CrmPost1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CrmPost1 : ICrmPost1
	{
		readonly IApplicationDB appDB;
		
		public CrmPost1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? BalAdj,
			decimal? DAmt,
			int? TDistSeq,
			decimal? TSubTotal,
			string TInvNum,
			decimal? TAccRestTaxBasis,
			decimal? TAccRestTax1,
			decimal? TAccRestTax2,
			string Infobar,
			decimal? TolAmtTax1,
			decimal? TolAmtTax2,
			int? CommDueUpdateFlag) CrmPost1Sp(
			DateTime? TCrmDate,
			int? BRmaLine,
			int? ERmaLine,
			DateTime? BLastReturnDate,
			DateTime? ELastReturnDate,
			Guid? RmaRec,
			Guid? ArinvRec,
			Guid? InvHdrRec,
			Guid? RestockFeeTaxProcessId,
			decimal? BalAdj,
			decimal? DAmt,
			int? TDistSeq,
			decimal? TSubTotal,
			string TInvNum,
			decimal? TAccRestTaxBasis,
			decimal? TAccRestTax1,
			decimal? TAccRestTax2,
			int? LinesPerDoc,
			string Infobar,
			decimal? TolAmtTax1,
			decimal? TolAmtTax2,
			int? CommDueUpdateFlag)
		{
			DateType _TCrmDate = TCrmDate;
			RmaLineType _BRmaLine = BRmaLine;
			RmaLineType _ERmaLine = ERmaLine;
			DateType _BLastReturnDate = BLastReturnDate;
			DateType _ELastReturnDate = ELastReturnDate;
			RowPointerType _RmaRec = RmaRec;
			RowPointerType _ArinvRec = ArinvRec;
			RowPointerType _InvHdrRec = InvHdrRec;
			RowPointerType _RestockFeeTaxProcessId = RestockFeeTaxProcessId;
			AmountType _BalAdj = BalAdj;
			AmountType _DAmt = DAmt;
			GenericNoType _TDistSeq = TDistSeq;
			AmountType _TSubTotal = TSubTotal;
			InvNumType _TInvNum = TInvNum;
			AmountType _TAccRestTaxBasis = TAccRestTaxBasis;
			AmountType _TAccRestTax1 = TAccRestTax1;
			AmountType _TAccRestTax2 = TAccRestTax2;
			IntType _LinesPerDoc = LinesPerDoc;
			InfobarType _Infobar = Infobar;
			AmountType _TolAmtTax1 = TolAmtTax1;
			AmountType _TolAmtTax2 = TolAmtTax2;
			ListYesNoType _CommDueUpdateFlag = CommDueUpdateFlag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CrmPost1Sp";
				
				appDB.AddCommandParameter(cmd, "TCrmDate", _TCrmDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BRmaLine", _BRmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ERmaLine", _ERmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BLastReturnDate", _BLastReturnDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ELastReturnDate", _ELastReturnDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaRec", _RmaRec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArinvRec", _ArinvRec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvHdrRec", _InvHdrRec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RestockFeeTaxProcessId", _RestockFeeTaxProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BalAdj", _BalAdj, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DAmt", _DAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDistSeq", _TDistSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TSubTotal", _TSubTotal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TInvNum", _TInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TAccRestTaxBasis", _TAccRestTaxBasis, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TAccRestTax1", _TAccRestTax1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TAccRestTax2", _TAccRestTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LinesPerDoc", _LinesPerDoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TolAmtTax1", _TolAmtTax1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TolAmtTax2", _TolAmtTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CommDueUpdateFlag", _CommDueUpdateFlag, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BalAdj = _BalAdj;
				DAmt = _DAmt;
				TDistSeq = _TDistSeq;
				TSubTotal = _TSubTotal;
				TInvNum = _TInvNum;
				TAccRestTaxBasis = _TAccRestTaxBasis;
				TAccRestTax1 = _TAccRestTax1;
				TAccRestTax2 = _TAccRestTax2;
				Infobar = _Infobar;
				TolAmtTax1 = _TolAmtTax1;
				TolAmtTax2 = _TolAmtTax2;
				CommDueUpdateFlag = _CommDueUpdateFlag;
				
				return (Severity, BalAdj, DAmt, TDistSeq, TSubTotal, TInvNum, TAccRestTaxBasis, TAccRestTax1, TAccRestTax2, Infobar, TolAmtTax1, TolAmtTax2, CommDueUpdateFlag);
			}
		}
	}
}
