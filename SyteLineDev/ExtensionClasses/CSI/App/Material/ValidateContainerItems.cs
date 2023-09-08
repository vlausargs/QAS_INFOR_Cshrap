//PROJECT NAME: Material
//CLASS NAME: ValidateContainerItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IValidateContainerItems
	{
		(int? ReturnCode, string PromptMsg, string PromptButtons, string Infobar) ValidateContainerItemsSp(string ContainerNum,
		string CurWhse,
		string RefType,
		string RefNum = null,
		short? RefLineSuf = null,
		short? RefRelease = null,
		byte? MessageContentFlg = (byte)0,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null,
		byte? VerifyQtyFlag = (byte)0,
		byte? ExtScrap = (byte)0,
		string TransType = null);
	}
	
	public class ValidateContainerItems : IValidateContainerItems
	{
		readonly IApplicationDB appDB;
		
		public ValidateContainerItems(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg, string PromptButtons, string Infobar) ValidateContainerItemsSp(string ContainerNum,
		string CurWhse,
		string RefType,
		string RefNum = null,
		short? RefLineSuf = null,
		short? RefRelease = null,
		byte? MessageContentFlg = (byte)0,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null,
		byte? VerifyQtyFlag = (byte)0,
		byte? ExtScrap = (byte)0,
		string TransType = null)
		{
			ContainerNumType _ContainerNum = ContainerNum;
			WhseType _CurWhse = CurWhse;
			RefTypeIJKO _RefType = RefType;
			CoJobPrjType _RefNum = RefNum;
			CoLineSuffixProjTaskType _RefLineSuf = RefLineSuf;
			CoReleaseOperNumType _RefRelease = RefRelease;
			FlagNyType _MessageContentFlg = MessageContentFlg;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			FlagNyType _VerifyQtyFlag = VerifyQtyFlag;
			ListYesNoType _ExtScrap = ExtScrap;
			MatlTransTypeType _TransType = TransType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateContainerItemsSp";
				
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MessageContentFlg", _MessageContentFlg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VerifyQtyFlag", _VerifyQtyFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExtScrap", _ExtScrap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
