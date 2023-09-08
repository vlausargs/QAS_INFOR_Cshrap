//PROJECT NAME: Production
//CLASS NAME: ProjTran.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjTran : IProjTran
	{
		readonly IApplicationDB appDB;
		
		public ProjTran(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			decimal? ProjTransNum) ProjTranSp(
			string PProjNum,
			int? PTaskNum,
			int? PSeq,
			string PType,
			string PCostCode,
			decimal? PTransNum,
			DateTime? PTransDate,
			decimal? PAmount,
			string PTransType,
			string PItem,
			decimal? PQty,
			decimal? PTotCost,
			decimal? PTotMatlCost,
			decimal? PTotLbrCost,
			decimal? PTotFovhdCost,
			decimal? PTotVovhdCost,
			decimal? PTotOutCost,
			string PEmpNum,
			string PPayType,
			string PShift,
			decimal? PAHrs,
			decimal? PPrRate,
			decimal? PProjRate,
			string PRefType,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PRefStr,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			string Infobar = null,
			string PJobCostCode = null,
			Guid? RowPointer = null,
			string FromNoteObject = null,
			Guid? FromNoteRowPointer = null,
			string DocumentNum = null,
			decimal? ProjTransNum = null)
		{
			ProjNumType _PProjNum = PProjNum;
			TaskNumType _PTaskNum = PTaskNum;
			ProjmatlSeqType _PSeq = PSeq;
			ProjCostTypeType _PType = PType;
			CostCodeType _PCostCode = PCostCode;
			ProjTransNumType _PTransNum = PTransNum;
			DateType _PTransDate = PTransDate;
			AmountType _PAmount = PAmount;
			ProjtranTypeType _PTransType = PTransType;
			ItemType _PItem = PItem;
			QtyUnitType _PQty = PQty;
			CostPrcType _PTotCost = PTotCost;
			CostPrcType _PTotMatlCost = PTotMatlCost;
			CostPrcType _PTotLbrCost = PTotLbrCost;
			CostPrcType _PTotFovhdCost = PTotFovhdCost;
			CostPrcType _PTotVovhdCost = PTotVovhdCost;
			CostPrcType _PTotOutCost = PTotOutCost;
			EmpNumType _PEmpNum = PEmpNum;
			PayBasisType _PPayType = PPayType;
			ShiftType _PShift = PShift;
			TotalHoursType _PAHrs = PAHrs;
			PayRateType _PPrRate = PPrRate;
			PayRateType _PProjRate = PProjRate;
			UnknownRefTypeType _PRefType = PRefType;
			UnknownRefNumVoucherType _PRefNum = PRefNum;
			UnknownRefLineType _PRefLineSuf = PRefLineSuf;
			UnknownRefReleaseType _PRefRelease = PRefRelease;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			ReferenceType _PRefStr = PRefStr;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			InfobarType _Infobar = Infobar;
			CostCodeType _PJobCostCode = PJobCostCode;
			RowPointerType _RowPointer = RowPointer;
			StringType _FromNoteObject = FromNoteObject;
			RowPointerType _FromNoteRowPointer = FromNoteRowPointer;
			DocumentNumType _DocumentNum = DocumentNum;
			ProjTransNumType _ProjTransNum = ProjTransNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjTranSp";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCostCode", _PCostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDate", _PTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAmount", _PAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransType", _PTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTotCost", _PTotCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTotMatlCost", _PTotMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTotLbrCost", _PTotLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTotFovhdCost", _PTotFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTotVovhdCost", _PTotVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTotOutCost", _PTotOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmpNum", _PEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayType", _PPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShift", _PShift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAHrs", _PAHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrRate", _PPrRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProjRate", _PProjRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefStr", _PRefStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PJobCostCode", _PJobCostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromNoteObject", _FromNoteObject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromNoteRowPointer", _FromNoteRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjTransNum", _ProjTransNum, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				ProjTransNum = _ProjTransNum;
				
				return (Severity, Infobar, ProjTransNum);
			}
		}
	}
}
