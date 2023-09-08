//PROJECT NAME: CSIVendor
//CLASS NAME: POReceivingListPreProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPOReceivingListPreProcess
	{
		(int? ReturnCode, string Infobar, string PromptMsg, string PromptButtons) POReceivingListPreProcessSp(string Whse,
		string PoNum,
		DateTime? PDate,
		string DateFieldLabel,
		byte? MatlRcptPosting,
		string FunctionLabel,
		string Infobar = null,
		string PromptMsg = null,
		string PromptButtons = null);
	}
	
	public class POReceivingListPreProcess : IPOReceivingListPreProcess
	{
		readonly IApplicationDB appDB;
		
		public POReceivingListPreProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, string PromptMsg, string PromptButtons) POReceivingListPreProcessSp(string Whse,
		string PoNum,
		DateTime? PDate,
		string DateFieldLabel,
		byte? MatlRcptPosting,
		string FunctionLabel,
		string Infobar = null,
		string PromptMsg = null,
		string PromptButtons = null)
		{
			WhseType _Whse = Whse;
			PoNumType _PoNum = PoNum;
			DateType _PDate = PDate;
			LangLabelType _DateFieldLabel = DateFieldLabel;
			ListYesNoType _MatlRcptPosting = MatlRcptPosting;
			FormNameOrCaptionType _FunctionLabel = FunctionLabel;
			InfobarType _Infobar = Infobar;
			InfobarType _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "POReceivingListPreProcessSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateFieldLabel", _DateFieldLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlRcptPosting", _MatlRcptPosting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FunctionLabel", _FunctionLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, Infobar, PromptMsg, PromptButtons);
			}
		}
	}
}
