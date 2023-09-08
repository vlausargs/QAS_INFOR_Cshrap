//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranJobValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IJobtranJobValid
	{
		(int? ReturnCode, short? InSuffix, byte? JobCoProdMix, string JobOrdType, string JobItem, byte? ItemLotTracked, byte? ItemSerialTracked, string ItemDesc, string ItemUm, string JobWhse, string JobRootJob, short? JobRootSuf, string JobRefJob, string JobStat, string JobJobType, byte? CntrlPoint, string Wc, string WcDesc, int? OperNum, int? NextOper, string NextWc, string NextWcDesc, byte? OperComplete, string Location, string LocDesc, byte? PIssueParent, string PProjNum, int? PTaskNum, int? PSeq, string PromptMsg, string PromptButtons, string Infobar, byte? JobPreassignLots, byte? JobPreassignSerials, string ItemLotPrefix, string ItemSerialPrefix, byte? Rework, short? JobRefSuf, byte? JobpPreassignLots, byte? JobpPreassignSerials, string NewOldJob) JobtranJobValidSp(string TransType,
		string InJob,
		string OldJob,
		short? InSuffix,
		short? OldSuffix,
		int? InOperNum,
		string JobOfPreviousRecord,
		byte? JobCoProdMix,
		string JobOrdType,
		string JobItem,
		byte? ItemLotTracked,
		byte? ItemSerialTracked,
		string ItemDesc,
		string ItemUm,
		string JobWhse,
		string JobRootJob,
		short? JobRootSuf,
		string JobRefJob,
		string JobStat,
		string JobJobType,
		byte? CntrlPoint,
		string Wc,
		string WcDesc,
		int? OperNum,
		int? NextOper,
		string NextWc,
		string NextWcDesc,
		byte? OperComplete,
		string Location,
		string LocDesc,
		byte? PIssueParent,
		string PProjNum,
		int? PTaskNum,
		int? PSeq,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		byte? JobPreassignLots,
		byte? JobPreassignSerials,
		string ItemLotPrefix,
		string ItemSerialPrefix,
		byte? Rework,
		short? JobRefSuf = null,
		byte? JobpPreassignLots = null,
		byte? JobpPreassignSerials = null,
		byte? AllOperComplete = (byte)0,
		string OldTransType = null,
		string NewOldJob = null);
	}
	
	public class JobtranJobValid : IJobtranJobValid
	{
		readonly IApplicationDB appDB;
		
		public JobtranJobValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, short? InSuffix, byte? JobCoProdMix, string JobOrdType, string JobItem, byte? ItemLotTracked, byte? ItemSerialTracked, string ItemDesc, string ItemUm, string JobWhse, string JobRootJob, short? JobRootSuf, string JobRefJob, string JobStat, string JobJobType, byte? CntrlPoint, string Wc, string WcDesc, int? OperNum, int? NextOper, string NextWc, string NextWcDesc, byte? OperComplete, string Location, string LocDesc, byte? PIssueParent, string PProjNum, int? PTaskNum, int? PSeq, string PromptMsg, string PromptButtons, string Infobar, byte? JobPreassignLots, byte? JobPreassignSerials, string ItemLotPrefix, string ItemSerialPrefix, byte? Rework, short? JobRefSuf, byte? JobpPreassignLots, byte? JobpPreassignSerials, string NewOldJob) JobtranJobValidSp(string TransType,
		string InJob,
		string OldJob,
		short? InSuffix,
		short? OldSuffix,
		int? InOperNum,
		string JobOfPreviousRecord,
		byte? JobCoProdMix,
		string JobOrdType,
		string JobItem,
		byte? ItemLotTracked,
		byte? ItemSerialTracked,
		string ItemDesc,
		string ItemUm,
		string JobWhse,
		string JobRootJob,
		short? JobRootSuf,
		string JobRefJob,
		string JobStat,
		string JobJobType,
		byte? CntrlPoint,
		string Wc,
		string WcDesc,
		int? OperNum,
		int? NextOper,
		string NextWc,
		string NextWcDesc,
		byte? OperComplete,
		string Location,
		string LocDesc,
		byte? PIssueParent,
		string PProjNum,
		int? PTaskNum,
		int? PSeq,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		byte? JobPreassignLots,
		byte? JobPreassignSerials,
		string ItemLotPrefix,
		string ItemSerialPrefix,
		byte? Rework,
		short? JobRefSuf = null,
		byte? JobpPreassignLots = null,
		byte? JobpPreassignSerials = null,
		byte? AllOperComplete = (byte)0,
		string OldTransType = null,
		string NewOldJob = null)
		{
			JobtranTypeType _TransType = TransType;
			JobType _InJob = InJob;
			JobType _OldJob = OldJob;
			SuffixType _InSuffix = InSuffix;
			SuffixType _OldSuffix = OldSuffix;
			OperNumType _InOperNum = InOperNum;
			JobType _JobOfPreviousRecord = JobOfPreviousRecord;
			ListYesNoType _JobCoProdMix = JobCoProdMix;
			RefTypeIKOTType _JobOrdType = JobOrdType;
			ItemType _JobItem = JobItem;
			ListYesNoType _ItemLotTracked = ItemLotTracked;
			ListYesNoType _ItemSerialTracked = ItemSerialTracked;
			DescriptionType _ItemDesc = ItemDesc;
			UMType _ItemUm = ItemUm;
			WhseType _JobWhse = JobWhse;
			JobType _JobRootJob = JobRootJob;
			SuffixType _JobRootSuf = JobRootSuf;
			JobType _JobRefJob = JobRefJob;
			JobStatusType _JobStat = JobStat;
			JobTypeType _JobJobType = JobJobType;
			ListYesNoType _CntrlPoint = CntrlPoint;
			WcType _Wc = Wc;
			DescriptionType _WcDesc = WcDesc;
			OperNumType _OperNum = OperNum;
			OperNumType _NextOper = NextOper;
			WcType _NextWc = NextWc;
			DescriptionType _NextWcDesc = NextWcDesc;
			ListYesNoType _OperComplete = OperComplete;
			LocType _Location = Location;
			DescriptionType _LocDesc = LocDesc;
			ListYesNoType _PIssueParent = PIssueParent;
			ProjNumType _PProjNum = PProjNum;
			TaskNumType _PTaskNum = PTaskNum;
			ProjmatlSeqType _PSeq = PSeq;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			ListYesNoType _JobPreassignLots = JobPreassignLots;
			ListYesNoType _JobPreassignSerials = JobPreassignSerials;
			LotPrefixType _ItemLotPrefix = ItemLotPrefix;
			SerialPrefixType _ItemSerialPrefix = ItemSerialPrefix;
			ListYesNoType _Rework = Rework;
			SuffixType _JobRefSuf = JobRefSuf;
			ListYesNoType _JobpPreassignLots = JobpPreassignLots;
			ListYesNoType _JobpPreassignSerials = JobpPreassignSerials;
			ListYesNoType _AllOperComplete = AllOperComplete;
			JobtranTypeType _OldTransType = OldTransType;
			JobType _NewOldJob = NewOldJob;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobtranJobValidSp";
				
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InJob", _InJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldJob", _OldJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSuffix", _InSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OldSuffix", _OldSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InOperNum", _InOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobOfPreviousRecord", _JobOfPreviousRecord, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobCoProdMix", _JobCoProdMix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobOrdType", _JobOrdType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobItem", _JobItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemLotTracked", _ItemLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemSerialTracked", _ItemSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUm", _ItemUm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobWhse", _JobWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobRootJob", _JobRootJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobRootSuf", _JobRootSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobRefJob", _JobRefJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobStat", _JobStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobJobType", _JobJobType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CntrlPoint", _CntrlPoint, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WcDesc", _WcDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NextOper", _NextOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NextWc", _NextWc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NextWcDesc", _NextWcDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperComplete", _OperComplete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Location", _Location, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LocDesc", _LocDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PIssueParent", _PIssueParent, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobPreassignLots", _JobPreassignLots, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobPreassignSerials", _JobPreassignSerials, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemLotPrefix", _ItemLotPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemSerialPrefix", _ItemSerialPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Rework", _Rework, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobRefSuf", _JobRefSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobpPreassignLots", _JobpPreassignLots, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobpPreassignSerials", _JobpPreassignSerials, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AllOperComplete", _AllOperComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldTransType", _OldTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewOldJob", _NewOldJob, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InSuffix = _InSuffix;
				JobCoProdMix = _JobCoProdMix;
				JobOrdType = _JobOrdType;
				JobItem = _JobItem;
				ItemLotTracked = _ItemLotTracked;
				ItemSerialTracked = _ItemSerialTracked;
				ItemDesc = _ItemDesc;
				ItemUm = _ItemUm;
				JobWhse = _JobWhse;
				JobRootJob = _JobRootJob;
				JobRootSuf = _JobRootSuf;
				JobRefJob = _JobRefJob;
				JobStat = _JobStat;
				JobJobType = _JobJobType;
				CntrlPoint = _CntrlPoint;
				Wc = _Wc;
				WcDesc = _WcDesc;
				OperNum = _OperNum;
				NextOper = _NextOper;
				NextWc = _NextWc;
				NextWcDesc = _NextWcDesc;
				OperComplete = _OperComplete;
				Location = _Location;
				LocDesc = _LocDesc;
				PIssueParent = _PIssueParent;
				PProjNum = _PProjNum;
				PTaskNum = _PTaskNum;
				PSeq = _PSeq;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				JobPreassignLots = _JobPreassignLots;
				JobPreassignSerials = _JobPreassignSerials;
				ItemLotPrefix = _ItemLotPrefix;
				ItemSerialPrefix = _ItemSerialPrefix;
				Rework = _Rework;
				JobRefSuf = _JobRefSuf;
				JobpPreassignLots = _JobpPreassignLots;
				JobpPreassignSerials = _JobpPreassignSerials;
				NewOldJob = _NewOldJob;
				
				return (Severity, InSuffix, JobCoProdMix, JobOrdType, JobItem, ItemLotTracked, ItemSerialTracked, ItemDesc, ItemUm, JobWhse, JobRootJob, JobRootSuf, JobRefJob, JobStat, JobJobType, CntrlPoint, Wc, WcDesc, OperNum, NextOper, NextWc, NextWcDesc, OperComplete, Location, LocDesc, PIssueParent, PProjNum, PTaskNum, PSeq, PromptMsg, PromptButtons, Infobar, JobPreassignLots, JobPreassignSerials, ItemLotPrefix, ItemSerialPrefix, Rework, JobRefSuf, JobpPreassignLots, JobpPreassignSerials, NewOldJob);
			}
		}
	}
}
