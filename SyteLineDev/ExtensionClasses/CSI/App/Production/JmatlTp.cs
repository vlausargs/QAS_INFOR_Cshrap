//PROJECT NAME: Production
//CLASS NAME: JmatlTp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JmatlTp : IJmatlTp
	{
		readonly IApplicationDB appDB;
		
		
		public JmatlTp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) JmatlTpSp(string CallFrom,
		int? DeleteTmpSer,
		int? Backflush,
		string Workkey,
		int? ByProduct,
		string TransClass,
		string JobJob,
		int? JobSuffix,
		int? JobmatlOperNum,
		decimal? JobmatlSequence,
		string ChildItem,
		string Wc,
		string EmpNum,
		string Whse,
		string Loc,
		string Lot,
		DateTime? TransDate,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? Cost,
		decimal? Qty,
		string Acct,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		string ImportDocId = null,
		string Infobar = null,
		string JobLot = null,
		string JobSerial = null,
		string ContainerNum = null,
		string DocumentNum = null)
		{
			StringType _CallFrom = CallFrom;
			ListYesNoType _DeleteTmpSer = DeleteTmpSer;
			ListYesNoType _Backflush = Backflush;
			StringType _Workkey = Workkey;
			ListYesNoType _ByProduct = ByProduct;
			JobtranClassType _TransClass = TransClass;
			JobType _JobJob = JobJob;
			SuffixType _JobSuffix = JobSuffix;
			OperNumType _JobmatlOperNum = JobmatlOperNum;
			SequenceType _JobmatlSequence = JobmatlSequence;
			ItemType _ChildItem = ChildItem;
			WcType _Wc = Wc;
			EmpNumType _EmpNum = EmpNum;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			DateType _TransDate = TransDate;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovhdCost = FovhdCost;
			CostPrcType _VovhdCost = VovhdCost;
			CostPrcType _OutCost = OutCost;
			AmountType _Cost = Cost;
			QtyUnitType _Qty = Qty;
			AcctType _Acct = Acct;
			UnitCode1Type _AcctUnit1 = AcctUnit1;
			UnitCode2Type _AcctUnit2 = AcctUnit2;
			UnitCode3Type _AcctUnit3 = AcctUnit3;
			UnitCode4Type _AcctUnit4 = AcctUnit4;
			ImportDocIdType _ImportDocId = ImportDocId;
			InfobarType _Infobar = Infobar;
			LotType _JobLot = JobLot;
			SerNumType _JobSerial = JobSerial;
			ContainerNumType _ContainerNum = ContainerNum;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JmatlTpSp";
				
				appDB.AddCommandParameter(cmd, "CallFrom", _CallFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteTmpSer", _DeleteTmpSer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Backflush", _Backflush, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Workkey", _Workkey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ByProduct", _ByProduct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransClass", _TransClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobJob", _JobJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlOperNum", _JobmatlOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlSequence", _JobmatlSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChildItem", _ChildItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit1", _AcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit2", _AcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit3", _AcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit4", _AcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobLot", _JobLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSerial", _JobSerial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
