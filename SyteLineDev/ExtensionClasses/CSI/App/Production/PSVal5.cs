//PROJECT NAME: Production
//CLASS NAME: PSVal5.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IPSVal5
	{
		(int? ReturnCode, string Wc, string Infobar, byte? IsLastOper, string Prompt, string PromptButtons) PSVal5Sp(string PSNum,
		string PSItem,
		int? OperNum,
		byte? Cmpl = (byte)0,
		string Wc = null,
		string Infobar = null,
		byte? IsLastOper = null,
		byte? ValidateCycle = (byte)0,
		DateTime? TransDate = null,
		string Prompt = null,
		string PromptButtons = null);
	}
	
	public class PSVal5 : IPSVal5
	{
		readonly IApplicationDB appDB;
		
		public PSVal5(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Wc, string Infobar, byte? IsLastOper, string Prompt, string PromptButtons) PSVal5Sp(string PSNum,
		string PSItem,
		int? OperNum,
		byte? Cmpl = (byte)0,
		string Wc = null,
		string Infobar = null,
		byte? IsLastOper = null,
		byte? ValidateCycle = (byte)0,
		DateTime? TransDate = null,
		string Prompt = null,
		string PromptButtons = null)
		{
			PsNumType _PSNum = PSNum;
			ItemType _PSItem = PSItem;
			OperNumType _OperNum = OperNum;
			FlagNyType _Cmpl = Cmpl;
			WcType _Wc = Wc;
			InfobarType _Infobar = Infobar;
			ListYesNoType _IsLastOper = IsLastOper;
			ListYesNoType _ValidateCycle = ValidateCycle;
			DateType _TransDate = TransDate;
			InfobarType _Prompt = Prompt;
			InfobarType _PromptButtons = PromptButtons;
           

            using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PSVal5Sp";
				
				appDB.AddCommandParameter(cmd, "PSNum", _PSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSItem", _PSItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cmpl", _Cmpl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsLastOper", _IsLastOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ValidateCycle", _ValidateCycle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				

                var Severity = appDB.ExecuteNonQuery(cmd);
				
				Wc = _Wc;
				Infobar = _Infobar;
				IsLastOper = _IsLastOper;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				
				return (Severity, Wc, Infobar, IsLastOper, Prompt, PromptButtons);
			}
		}
	}
}
