//PROJECT NAME: Material
//CLASS NAME: VendorConsignQtyAvailforItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class VendorConsignQtyAvailforItem : IVendorConsignQtyAvailforItem
	{
		readonly IApplicationDB appDB;
		
		
		public VendorConsignQtyAvailforItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? ConsignQtyRequired,
		string ConsignVdrWhse,
		string ConsignVdrLoc,
		string PromptMsg,
		string PromptButtons,
		string Infobar) VendorConsignQtyAvailforItemSp(string CheckType,
		string CurrentWhse,
		string Item = null,
		string Job = null,
		string Loc = null,
		string Lot = null,
		int? JobSuffix = null,
		int? JobmatlOperNum = null,
		int? JobmatlSequence = null,
		string ProjNum = null,
		int? TaskNum = null,
		int? ProjmatSeq = null,
		decimal? QtyRequired = null,
		decimal? ConsignQtyRequired = null,
		string ConsignVdrWhse = null,
		string ConsignVdrLoc = null,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null)
		{
			LongListType _CheckType = CheckType;
			WhseType _CurrentWhse = CurrentWhse;
			ItemType _Item = Item;
			JobType _Job = Job;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			SuffixType _JobSuffix = JobSuffix;
			OperNumType _JobmatlOperNum = JobmatlOperNum;
			JobmatlSequenceType _JobmatlSequence = JobmatlSequence;
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			ProjmatlSeqType _ProjmatSeq = ProjmatSeq;
			QtyTotlType _QtyRequired = QtyRequired;
			QtyTotlType _ConsignQtyRequired = ConsignQtyRequired;
			WhseType _ConsignVdrWhse = ConsignVdrWhse;
			LocType _ConsignVdrLoc = ConsignVdrLoc;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VendorConsignQtyAvailforItemSp";
				
				appDB.AddCommandParameter(cmd, "CheckType", _CheckType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentWhse", _CurrentWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlOperNum", _JobmatlOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlSequence", _JobmatlSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjmatSeq", _ProjmatSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyRequired", _QtyRequired, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConsignQtyRequired", _ConsignQtyRequired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConsignVdrWhse", _ConsignVdrWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConsignVdrLoc", _ConsignVdrLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ConsignQtyRequired = _ConsignQtyRequired;
				ConsignVdrWhse = _ConsignVdrWhse;
				ConsignVdrLoc = _ConsignVdrLoc;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, ConsignQtyRequired, ConsignVdrWhse, ConsignVdrLoc, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
