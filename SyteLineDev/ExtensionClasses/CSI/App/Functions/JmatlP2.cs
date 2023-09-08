//PROJECT NAME: Data
//CLASS NAME: JmatlP2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JmatlP2 : IJmatlP2
	{
		readonly IApplicationDB appDB;
		
		public JmatlP2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TransNum,
			decimal? TotPost,
			Guid? MatltranAmtRowPointer,
			string Infobar) JmatlP2Sp(
			string CallFrom,
			Guid? ItemRowPointer,
			Guid? ItemwhseRowPointer,
			Guid? ItemlocRowPointer,
			Guid? MatltranRowPointer,
			Guid? WcRowPointer,
			Guid? JobmatlRowPointer,
			Guid? JobrouteRowPointer,
			Guid? JobItemRowPointer,
			Guid? JobRowPointer,
			Guid? ProdcodeRowPointer,
			Guid? ProdvarRowPointer,
			string TransType,
			decimal? Qty,
			decimal? AdjQty,
			DateTime? TransDate,
			string TransClass,
			int? ByProduct,
			string CostCode,
			string Loc,
			string Lot,
			string CurUserCode,
			int? CoBy,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			string ImportDocId = null,
			decimal? TransNum = null,
			decimal? TotPost = null,
			Guid? MatltranAmtRowPointer = null,
			string Infobar = null)
		{
			StringType _CallFrom = CallFrom;
			RowPointerType _ItemRowPointer = ItemRowPointer;
			RowPointerType _ItemwhseRowPointer = ItemwhseRowPointer;
			RowPointerType _ItemlocRowPointer = ItemlocRowPointer;
			RowPointerType _MatltranRowPointer = MatltranRowPointer;
			RowPointerType _WcRowPointer = WcRowPointer;
			RowPointerType _JobmatlRowPointer = JobmatlRowPointer;
			RowPointerType _JobrouteRowPointer = JobrouteRowPointer;
			RowPointerType _JobItemRowPointer = JobItemRowPointer;
			RowPointerType _JobRowPointer = JobRowPointer;
			RowPointerType _ProdcodeRowPointer = ProdcodeRowPointer;
			RowPointerType _ProdvarRowPointer = ProdvarRowPointer;
			MatlTransTypeType _TransType = TransType;
			QtyPerType _Qty = Qty;
			QtyPerType _AdjQty = AdjQty;
			DateType _TransDate = TransDate;
			JobtranClassType _TransClass = TransClass;
			ListYesNoType _ByProduct = ByProduct;
			CostCodeType _CostCode = CostCode;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			UserCodeType _CurUserCode = CurUserCode;
			ListYesNoType _CoBy = CoBy;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			ImportDocIdType _ImportDocId = ImportDocId;
			MatlTransNumType _TransNum = TransNum;
			CostPrcType _TotPost = TotPost;
			RowPointerType _MatltranAmtRowPointer = MatltranAmtRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JmatlP2Sp";
				
				appDB.AddCommandParameter(cmd, "CallFrom", _CallFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemRowPointer", _ItemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemwhseRowPointer", _ItemwhseRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocRowPointer", _ItemlocRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatltranRowPointer", _MatltranRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WcRowPointer", _WcRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlRowPointer", _JobmatlRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteRowPointer", _JobrouteRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobItemRowPointer", _JobItemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRowPointer", _JobRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdcodeRowPointer", _ProdcodeRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdvarRowPointer", _ProdvarRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AdjQty", _AdjQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransClass", _TransClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ByProduct", _ByProduct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCode", _CostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurUserCode", _CurUserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoBy", _CoBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotPost", _TotPost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatltranAmtRowPointer", _MatltranAmtRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TransNum = _TransNum;
				TotPost = _TotPost;
				MatltranAmtRowPointer = _MatltranAmtRowPointer;
				Infobar = _Infobar;
				
				return (Severity, TransNum, TotPost, MatltranAmtRowPointer, Infobar);
			}
		}
	}
}
