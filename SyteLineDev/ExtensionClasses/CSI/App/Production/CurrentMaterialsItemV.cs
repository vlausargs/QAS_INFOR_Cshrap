//PROJECT NAME: CSIProduct
//CLASS NAME: CurrentMaterialsItemV.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface ICurrentMaterialsItemV
	{
		(int? ReturnCode, string Item, string Infobar, string Prompt, string PromptButtons, byte? ItemExists, byte? IsOpenNonInvForm, string PPPaperMassBasis) CurrentMaterialsItemVSp(string ItmItem,
		string Job,
		short? Suffix,
		int? OperNum,
		short? Sequence,
		string JobType,
		string Item,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null,
		byte? ItemExists = null,
		byte? IsOpenNonInvForm = (byte)0,
		string PPPaperMassBasis = null);
	}
	
	public class CurrentMaterialsItemV : ICurrentMaterialsItemV
	{
		readonly IApplicationDB appDB;
		
		public CurrentMaterialsItemV(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Item, string Infobar, string Prompt, string PromptButtons, byte? ItemExists, byte? IsOpenNonInvForm, string PPPaperMassBasis) CurrentMaterialsItemVSp(string ItmItem,
		string Job,
		short? Suffix,
		int? OperNum,
		short? Sequence,
		string JobType,
		string Item,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null,
		byte? ItemExists = null,
		byte? IsOpenNonInvForm = (byte)0,
		string PPPaperMassBasis = null)
		{
			ItemType _ItmItem = ItmItem;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			JobmatlSequenceType _Sequence = Sequence;
			JobTypeType _JobType = JobType;
			ItemType _Item = Item;
			Infobar _Infobar = Infobar;
			Infobar _Prompt = Prompt;
			Infobar _PromptButtons = PromptButtons;
			ListYesNoType _ItemExists = ItemExists;
			ListYesNoType _IsOpenNonInvForm = IsOpenNonInvForm;
			PP_PaperMassBasisType _PPPaperMassBasis = PPPaperMassBasis;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CurrentMaterialsItemVSp";
				
				appDB.AddCommandParameter(cmd, "ItmItem", _ItmItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemExists", _ItemExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsOpenNonInvForm", _IsOpenNonInvForm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPPaperMassBasis", _PPPaperMassBasis, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				Infobar = _Infobar;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				ItemExists = _ItemExists;
				IsOpenNonInvForm = _IsOpenNonInvForm;
				PPPaperMassBasis = _PPPaperMassBasis;
				
				return (Severity, Item, Infobar, Prompt, PromptButtons, ItemExists, IsOpenNonInvForm, PPPaperMassBasis);
			}
		}
	}
}
