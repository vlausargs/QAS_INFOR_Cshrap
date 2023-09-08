//PROJECT NAME: Production
//CLASS NAME: ProcessJobMatlTransSetVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ProcessJobMatlTransSetVars : IProcessJobMatlTransSetVars
	{
		readonly IApplicationDB appDB;
		
		
		public ProcessJobMatlTransSetVars(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ProcessJobMatlTransSetVarsSp(string SET,
		string Job,
		int? Suffix,
		int? OperNum,
		int? Sequence,
		int? DeleteTmpSer = 0,
		int? Backflush = 0,
		int? ByProduct = 0,
		string UM = null,
		string Item = null,
		string Description = null,
		string Wc = null,
		string Whse = null,
		string Loc = null,
		string Lot = null,
		DateTime? TransDate = null,
		decimal? MatlCost = null,
		decimal? LbrCost = null,
		decimal? FovhdCost = null,
		decimal? VovhdCost = null,
		decimal? OutCost = null,
		decimal? Cost = null,
		decimal? PlanCost = null,
		decimal? Qty = null,
		string Acct = null,
		string AcctUnit1 = null,
		string AcctUnit2 = null,
		string AcctUnit3 = null,
		string AcctUnit4 = null,
		Guid? RowPointer = null,
		string JobmatlRefType = null,
		string JobmatlRefNum = null,
		int? JobmatlRefLineSuf = null,
		int? JobmatlRefRelease = null,
		string Infobar = null,
		string ImportDocId = null,
		string JobLot = null,
		string JobSerial = null,
		string ContainerNum = null,
		DateTime? RecordDate = null,
		string EmpNum = null,
		string DocumentNum = null)
		{
			ProcessIndType _SET = SET;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			JobmatlSequenceType _Sequence = Sequence;
			ListYesNoType _DeleteTmpSer = DeleteTmpSer;
			ListYesNoType _Backflush = Backflush;
			ListYesNoType _ByProduct = ByProduct;
			UMType _UM = UM;
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			WcType _Wc = Wc;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			DateType _TransDate = TransDate;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovhdCost = FovhdCost;
			CostPrcType _VovhdCost = VovhdCost;
			CostPrcType _OutCost = OutCost;
			CostPrcType _Cost = Cost;
			CostPrcType _PlanCost = PlanCost;
			QtyPerType _Qty = Qty;
			AcctType _Acct = Acct;
			UnitCode1Type _AcctUnit1 = AcctUnit1;
			UnitCode2Type _AcctUnit2 = AcctUnit2;
			UnitCode3Type _AcctUnit3 = AcctUnit3;
			UnitCode4Type _AcctUnit4 = AcctUnit4;
			RowPointerType _RowPointer = RowPointer;
			RefTypeIJKPRTType _JobmatlRefType = JobmatlRefType;
			JobPoProjReqTrnNumType _JobmatlRefNum = JobmatlRefNum;
			SuffixPoLineProjTaskReqTrnLineType _JobmatlRefLineSuf = JobmatlRefLineSuf;
			OperNumPoReleaseType _JobmatlRefRelease = JobmatlRefRelease;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			LotType _JobLot = JobLot;
			SerNumType _JobSerial = JobSerial;
			ContainerNumType _ContainerNum = ContainerNum;
			CurrentDateType _RecordDate = RecordDate;
			EmpNumType _EmpNum = EmpNum;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProcessJobMatlTransSetVarsSp";
				
				appDB.AddCommandParameter(cmd, "SET", _SET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteTmpSer", _DeleteTmpSer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Backflush", _Backflush, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ByProduct", _ByProduct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FovhdCost", _FovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VovhdCost", _VovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cost", _Cost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCost", _PlanCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit1", _AcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit2", _AcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit3", _AcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit4", _AcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlRefType", _JobmatlRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlRefNum", _JobmatlRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlRefLineSuf", _JobmatlRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlRefRelease", _JobmatlRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobLot", _JobLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSerial", _JobSerial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
