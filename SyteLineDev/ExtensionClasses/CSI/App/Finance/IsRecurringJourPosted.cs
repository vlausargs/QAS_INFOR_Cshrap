//PROJECT NAME: CSIFinance
//CLASS NAME: IsRecurringJourPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IIsRecurringJourPost
	{
		(int? ReturnCode, string PromptButtons, string PromptMessage, string Infobar) IsRecurringJourPosted(string JourId,
		DateTime? TransactionDate,
		byte? SingleDate,
		string StartingGLVoucher = null,
		string EndingGLVoucher = null,
		string PromptButtons = null,
		string PromptMessage = null,
		string Infobar = null);
	}
	
	public class IsRecurringJourPost : IIsRecurringJourPost
	{
		readonly IApplicationDB appDB;
		
		public IsRecurringJourPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptButtons, string PromptMessage, string Infobar) IsRecurringJourPosted(string JourId,
		DateTime? TransactionDate,
		byte? SingleDate,
		string StartingGLVoucher = null,
		string EndingGLVoucher = null,
		string PromptButtons = null,
		string PromptMessage = null,
		string Infobar = null)
		{
			JournalIdType _JourId = JourId;
			DateType _TransactionDate = TransactionDate;
			ListYesNoType _SingleDate = SingleDate;
			InvNumVoucherType _StartingGLVoucher = StartingGLVoucher;
			InvNumVoucherType _EndingGLVoucher = EndingGLVoucher;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _PromptMessage = PromptMessage;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IsRecurringJourPosted";
				
				appDB.AddCommandParameter(cmd, "JourId", _JourId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransactionDate", _TransactionDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SingleDate", _SingleDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingGLVoucher", _StartingGLVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingGLVoucher", _EndingGLVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMessage", _PromptMessage, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptButtons = _PromptButtons;
				PromptMessage = _PromptMessage;
				Infobar = _Infobar;
				
				return (Severity, PromptButtons, PromptMessage, Infobar);
			}
		}
	}
}
