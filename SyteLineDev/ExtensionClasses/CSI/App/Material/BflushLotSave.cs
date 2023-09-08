//PROJECT NAME: Material
//CLASS NAME: BflushLotSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class BflushLotSave : IBflushLotSave
	{
		readonly IApplicationDB appDB;
		
		
		public BflushLotSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) BflushLotSaveSp(decimal? TransNum,
		string Whse,
		string Lot,
		int? Selected,
		string Job,
		int? Suffix,
		int? OperNum,
		int? Sequence,
		string EmpNum,
		string JobMatlItem,
		string Loc,
		decimal? QtyNeeded,
		decimal? QtyRequired,
		string JobRouteWc,
		string UM,
		string TransClass,
		int? TransSeq = null,
		string Infobar = null,
		Guid? SessionId = null)
		{
			HugeTransNumType _TransNum = TransNum;
			WhseType _Whse = Whse;
			LotType _Lot = Lot;
			ListYesNoType _Selected = Selected;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			JobmatlSequenceType _Sequence = Sequence;
			EmpNumType _EmpNum = EmpNum;
			ItemType _JobMatlItem = JobMatlItem;
			LocType _Loc = Loc;
			QtyPerType _QtyNeeded = QtyNeeded;
			QtyPerType _QtyRequired = QtyRequired;
			WcType _JobRouteWc = JobRouteWc;
			UMType _UM = UM;
			JobtranClassType _TransClass = TransClass;
			JobtranTransSeqType _TransSeq = TransSeq;
			InfobarType _Infobar = Infobar;
			RowPointerType _SessionId = SessionId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BflushLotSaveSp";
				
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobMatlItem", _JobMatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyNeeded", _QtyNeeded, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyRequired", _QtyRequired, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRouteWc", _JobRouteWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransClass", _TransClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransSeq", _TransSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
