//PROJECT NAME: MOIndPack
//CLASS NAME: MO_UpdateCoJobItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.MOIndPack
{
	public class MO_UpdateCoJobItem : IMO_UpdateCoJobItem
	{
		readonly IApplicationDB appDB;
		
		public MO_UpdateCoJobItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MO_UpdateCoJobItemSp(
			string Job,
			int? Suffix,
			int? MOCoJob,
			string Item,
			string MOBomAlternateId,
			decimal? MOQtyPerCycle,
			decimal? QtyReleased,
			string OrdType,
			string OrdNum,
			int? OrdLine,
			int? OrdRelease,
			string RefJob,
			int? RefSuf,
			int? RefOper,
			int? RefSeq,
			string RootJob,
			int? RootSuf,
			string JcbAcct,
			string JcbAcctUnit1,
			string JcbAcctUnit2,
			string JcbAcctUnit3,
			string JcbAcctUnit4,
			string WipAcct,
			string WipAcctUnit1,
			string WipAcctUnit2,
			string WipAcctUnit3,
			string WipAcctUnit4,
			decimal? WipMatlTotal,
			string WipLbrAcct,
			string WipLbrAcctUnit1,
			string WipLbrAcctUnit2,
			string WipLbrAcctUnit3,
			string WipLbrAcctUnit4,
			decimal? WipLbrTotal,
			string WipFovhdAcct,
			string WipFovhdAcctUnit1,
			string WipFovhdAcctUnit2,
			string WipFovhdAcctUnit3,
			string WipFovhdAcctUnit4,
			decimal? WipFovhdTotal,
			string WipVovhdAcct,
			string WipVovhdAcctUnit1,
			string WipVovhdAcctUnit2,
			string WipVovhdAcctUnit3,
			string WipVovhdAcctUnit4,
			decimal? WipVovhdTotal,
			string WipOutAcct,
			string WipOutAcctUnit1,
			string WipOutAcctUnit2,
			string WipOutAcctUnit3,
			string WipOutAcctUnit4,
			decimal? WipOutTotal,
			decimal? WipTotal,
			int? PreassignLots,
			int? PreassignSerials,
			string Description)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ListYesNoType _MOCoJob = MOCoJob;
			ItemType _Item = Item;
			MO_BOMAlternateType _MOBomAlternateId = MOBomAlternateId;
			QtyUnitType _MOQtyPerCycle = MOQtyPerCycle;
			QtyUnitType _QtyReleased = QtyReleased;
			RefTypeIKOTType _OrdType = OrdType;
			CoProjTrnNumType _OrdNum = OrdNum;
			CoProjTaskTrnLineType _OrdLine = OrdLine;
			CoReleaseType _OrdRelease = OrdRelease;
			JobType _RefJob = RefJob;
			SuffixType _RefSuf = RefSuf;
			OperNumType _RefOper = RefOper;
			JobmatlSequenceType _RefSeq = RefSeq;
			JobType _RootJob = RootJob;
			SuffixType _RootSuf = RootSuf;
			AcctType _JcbAcct = JcbAcct;
			UnitCode1Type _JcbAcctUnit1 = JcbAcctUnit1;
			UnitCode2Type _JcbAcctUnit2 = JcbAcctUnit2;
			UnitCode3Type _JcbAcctUnit3 = JcbAcctUnit3;
			UnitCode4Type _JcbAcctUnit4 = JcbAcctUnit4;
			AcctType _WipAcct = WipAcct;
			UnitCode1Type _WipAcctUnit1 = WipAcctUnit1;
			UnitCode2Type _WipAcctUnit2 = WipAcctUnit2;
			UnitCode3Type _WipAcctUnit3 = WipAcctUnit3;
			UnitCode4Type _WipAcctUnit4 = WipAcctUnit4;
			AmountType _WipMatlTotal = WipMatlTotal;
			AcctType _WipLbrAcct = WipLbrAcct;
			UnitCode1Type _WipLbrAcctUnit1 = WipLbrAcctUnit1;
			UnitCode2Type _WipLbrAcctUnit2 = WipLbrAcctUnit2;
			UnitCode3Type _WipLbrAcctUnit3 = WipLbrAcctUnit3;
			UnitCode4Type _WipLbrAcctUnit4 = WipLbrAcctUnit4;
			AmountType _WipLbrTotal = WipLbrTotal;
			AcctType _WipFovhdAcct = WipFovhdAcct;
			UnitCode1Type _WipFovhdAcctUnit1 = WipFovhdAcctUnit1;
			UnitCode2Type _WipFovhdAcctUnit2 = WipFovhdAcctUnit2;
			UnitCode3Type _WipFovhdAcctUnit3 = WipFovhdAcctUnit3;
			UnitCode4Type _WipFovhdAcctUnit4 = WipFovhdAcctUnit4;
			AmountType _WipFovhdTotal = WipFovhdTotal;
			AcctType _WipVovhdAcct = WipVovhdAcct;
			UnitCode1Type _WipVovhdAcctUnit1 = WipVovhdAcctUnit1;
			UnitCode2Type _WipVovhdAcctUnit2 = WipVovhdAcctUnit2;
			UnitCode3Type _WipVovhdAcctUnit3 = WipVovhdAcctUnit3;
			UnitCode4Type _WipVovhdAcctUnit4 = WipVovhdAcctUnit4;
			AmountType _WipVovhdTotal = WipVovhdTotal;
			AcctType _WipOutAcct = WipOutAcct;
			UnitCode1Type _WipOutAcctUnit1 = WipOutAcctUnit1;
			UnitCode2Type _WipOutAcctUnit2 = WipOutAcctUnit2;
			UnitCode3Type _WipOutAcctUnit3 = WipOutAcctUnit3;
			UnitCode4Type _WipOutAcctUnit4 = WipOutAcctUnit4;
			AmountType _WipOutTotal = WipOutTotal;
			AmountType _WipTotal = WipTotal;
			ListYesNoType _PreassignLots = PreassignLots;
			ListYesNoType _PreassignSerials = PreassignSerials;
			DescriptionType _Description = Description;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_UpdateCoJobItemSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MOCoJob", _MOCoJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MOBomAlternateId", _MOBomAlternateId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MOQtyPerCycle", _MOQtyPerCycle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReleased", _QtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdType", _OrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdNum", _OrdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdLine", _OrdLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdRelease", _OrdRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefJob", _RefJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefSuf", _RefSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefOper", _RefOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefSeq", _RefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RootJob", _RootJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RootSuf", _RootSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JcbAcct", _JcbAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JcbAcctUnit1", _JcbAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JcbAcctUnit2", _JcbAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JcbAcctUnit3", _JcbAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JcbAcctUnit4", _JcbAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipAcct", _WipAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipAcctUnit1", _WipAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipAcctUnit2", _WipAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipAcctUnit3", _WipAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipAcctUnit4", _WipAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipMatlTotal", _WipMatlTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipLbrAcct", _WipLbrAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipLbrAcctUnit1", _WipLbrAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipLbrAcctUnit2", _WipLbrAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipLbrAcctUnit3", _WipLbrAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipLbrAcctUnit4", _WipLbrAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipLbrTotal", _WipLbrTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipFovhdAcct", _WipFovhdAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipFovhdAcctUnit1", _WipFovhdAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipFovhdAcctUnit2", _WipFovhdAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipFovhdAcctUnit3", _WipFovhdAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipFovhdAcctUnit4", _WipFovhdAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipFovhdTotal", _WipFovhdTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipVovhdAcct", _WipVovhdAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipVovhdAcctUnit1", _WipVovhdAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipVovhdAcctUnit2", _WipVovhdAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipVovhdAcctUnit3", _WipVovhdAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipVovhdAcctUnit4", _WipVovhdAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipVovhdTotal", _WipVovhdTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipOutAcct", _WipOutAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipOutAcctUnit1", _WipOutAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipOutAcctUnit2", _WipOutAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipOutAcctUnit3", _WipOutAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipOutAcctUnit4", _WipOutAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipOutTotal", _WipOutTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipTotal", _WipTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreassignLots", _PreassignLots, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreassignSerials", _PreassignSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
