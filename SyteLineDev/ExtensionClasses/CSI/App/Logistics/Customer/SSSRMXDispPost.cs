//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXDispPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXDispPost
	{
		(int? ReturnCode, string PromptMsg, string PromptButtons, string Infobar) SSSRMXDispPostSp(string Mode,
		Guid? DispRowPointer,
		string iSroCopyTransFrom,
		string iTemplateSroNum,
		int? iTemplateSROLine,
		string iSelectedOpers,
		string iBillMgr,
		string iSRODesc,
		string iLeadPartner,
		string iCompItem,
		decimal? iCompQtyOrd,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		byte? RewSROCreatedAlready = null,
		string RewSroNum = null,
		int? RewSroLine = null,
		int? RewSroOper = null);
	}
	
	public class SSSRMXDispPost : ISSSRMXDispPost
	{
		readonly IApplicationDB appDB;
		
		public SSSRMXDispPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg, string PromptButtons, string Infobar) SSSRMXDispPostSp(string Mode,
		Guid? DispRowPointer,
		string iSroCopyTransFrom,
		string iTemplateSroNum,
		int? iTemplateSROLine,
		string iSelectedOpers,
		string iBillMgr,
		string iSRODesc,
		string iLeadPartner,
		string iCompItem,
		decimal? iCompQtyOrd,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		byte? RewSROCreatedAlready = null,
		string RewSroNum = null,
		int? RewSroLine = null,
		int? RewSroOper = null)
		{
			StringType _Mode = Mode;
			RowPointerType _DispRowPointer = DispRowPointer;
			StringType _iSroCopyTransFrom = iSroCopyTransFrom;
			FSSRONumType _iTemplateSroNum = iTemplateSroNum;
			FSSROLineType _iTemplateSROLine = iTemplateSROLine;
			LongListType _iSelectedOpers = iSelectedOpers;
			FSPartnerType _iBillMgr = iBillMgr;
			DescriptionType _iSRODesc = iSRODesc;
			FSPartnerType _iLeadPartner = iLeadPartner;
			ItemType _iCompItem = iCompItem;
			QtyUnitType _iCompQtyOrd = iCompQtyOrd;
			Infobar _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			Infobar _Infobar = Infobar;
			FlagNyType _RewSROCreatedAlready = RewSROCreatedAlready;
			FSSRONumType _RewSroNum = RewSroNum;
			FSSROLineType _RewSroLine = RewSroLine;
			FSSROOperType _RewSroOper = RewSroOper;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXDispPostSp";
				
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DispRowPointer", _DispRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyTransFrom", _iSroCopyTransFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTemplateSroNum", _iTemplateSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTemplateSROLine", _iTemplateSROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSelectedOpers", _iSelectedOpers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iBillMgr", _iBillMgr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSRODesc", _iSRODesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLeadPartner", _iLeadPartner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCompItem", _iCompItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCompQtyOrd", _iCompQtyOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RewSROCreatedAlready", _RewSROCreatedAlready, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RewSroNum", _RewSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RewSroLine", _RewSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RewSroOper", _RewSroOper, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
