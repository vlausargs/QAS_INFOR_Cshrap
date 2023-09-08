//PROJECT NAME: Data
//CLASS NAME: Spec.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Spec : ISpec
	{
		readonly IApplicationDB appDB;
		
		public Spec(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? NextRow,
			int? THadError,
			string Infobar) SpecSp(
			string PItem,
			DateTime? PDueDate,
			decimal? PQtyReq,
			decimal? POrigQty,
			string POrderType,
			string PReference,
			int? PRefLineSuf,
			int? PRefRel,
			string PXrefType,
			string PXrefNum,
			int? PXrefLinSuf,
			int? PXrefRelease,
			int? ReqMday,
			int? TExcAhd,
			int? TExcBhd,
			int? TExcAhdJ,
			int? TExcBhdJ,
			int? NextRow,
			int? THadError,
			string Infobar,
			int? MrpParmDynLead = null,
			int? ItemDockTime = null,
			DateTime? CurrentDate = null,
			int? BufferExcMesg = 0,
			Guid? ProcessId = null,
			int? BgTaskID = null,
			int? MrpParmUseSchedTimesInPlanning = null,
			string ApsParmApsMode = null)
		{
			ItemType _PItem = PItem;
			DateType _PDueDate = PDueDate;
			QtyUnitType _PQtyReq = PQtyReq;
			QtyUnitType _POrigQty = POrigQty;
			MrpOrderTypeType _POrderType = POrderType;
			MrpOrderType _PReference = PReference;
			MrpOrderLineType _PRefLineSuf = PRefLineSuf;
			UnknownRefReleaseType _PRefRel = PRefRel;
			RefTypeIJKPRTType _PXrefType = PXrefType;
			JobPoProjReqTrnNumType _PXrefNum = PXrefNum;
			SuffixPoReqTrnLineType _PXrefLinSuf = PXrefLinSuf;
			PoReleaseType _PXrefRelease = PXrefRelease;
			MdayNumType _ReqMday = ReqMday;
			PlanFenceType _TExcAhd = TExcAhd;
			PlanFenceType _TExcBhd = TExcBhd;
			PlanFenceType _TExcAhdJ = TExcAhdJ;
			PlanFenceType _TExcBhdJ = TExcBhdJ;
			FlagNyType _NextRow = NextRow;
			FlagNyType _THadError = THadError;
			InfobarType _Infobar = Infobar;
			ListYesNoType _MrpParmDynLead = MrpParmDynLead;
			LeadTimeType _ItemDockTime = ItemDockTime;
			DateType _CurrentDate = CurrentDate;
			ListYesNoType _BufferExcMesg = BufferExcMesg;
			RowPointerType _ProcessId = ProcessId;
			GenericNoType _BgTaskID = BgTaskID;
			ListYesNoType _MrpParmUseSchedTimesInPlanning = MrpParmUseSchedTimesInPlanning;
			ApsModeType _ApsParmApsMode = ApsParmApsMode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SpecSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyReq", _PQtyReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrigQty", _POrigQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderType", _POrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReference", _PReference, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRel", _PRefRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PXrefType", _PXrefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PXrefNum", _PXrefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PXrefLinSuf", _PXrefLinSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PXrefRelease", _PXrefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqMday", _ReqMday, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TExcAhd", _TExcAhd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TExcBhd", _TExcBhd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TExcAhdJ", _TExcAhdJ, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TExcBhdJ", _TExcBhdJ, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextRow", _NextRow, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "THadError", _THadError, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MrpParmDynLead", _MrpParmDynLead, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDockTime", _ItemDockTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentDate", _CurrentDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BufferExcMesg", _BufferExcMesg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BgTaskID", _BgTaskID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpParmUseSchedTimesInPlanning", _MrpParmUseSchedTimesInPlanning, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApsParmApsMode", _ApsParmApsMode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextRow = _NextRow;
				THadError = _THadError;
				Infobar = _Infobar;
				
				return (Severity, NextRow, THadError, Infobar);
			}
		}
	}
}
