//PROJECT NAME: Logistics
//CLASS NAME: ValidateArtranInvNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateArtranInvNum : IValidateArtranInvNum
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateArtranInvNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string DerInvNum,
		string PromptMsg,
		string PromptButtons,
		string Infobar) ValidateArtranInvNumSp(Guid? RowPointer,
		int? Filter,
		string ArtranType,
		string CustNum,
		string InvNum,
		int? InvSeq,
		int? CheckSeq,
		string PayType,
		string DerInvNum,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string ApplyToInvNum)
		{
			RowPointerType _RowPointer = RowPointer;
			ListYesNoType _Filter = Filter;
			ArtranTypeType _ArtranType = ArtranType;
			CustNumType _CustNum = CustNum;
			InvNumType _InvNum = InvNum;
			ArInvSeqType _InvSeq = InvSeq;
			ArCheckNumType _CheckSeq = CheckSeq;
			CustPayTypeType _PayType = PayType;
			StringType _DerInvNum = DerInvNum;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			InvNumType _ApplyToInvNum = ApplyToInvNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateArtranInvNumSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Filter", _Filter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArtranType", _ArtranType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckSeq", _CheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerInvNum", _DerInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ApplyToInvNum", _ApplyToInvNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DerInvNum = _DerInvNum;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, DerInvNum, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
