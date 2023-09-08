//PROJECT NAME: Logistics
//CLASS NAME: SequencePreSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SequencePreSave : ISequencePreSave
	{
		readonly IApplicationDB appDB;
		
		
		public SequencePreSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) SequencePreSaveSp(string PType,
		string PCategory,
		int? PClosed,
		string PStartInv,
		string PEndInv,
		int? Action,
		Guid? PRowPointer = null,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null)
		{
			ArinvTypeType _PType = PType;
			InvCategoryType _PCategory = PCategory;
			ListYesNoType _PClosed = PClosed;
			InvNumType _PStartInv = PStartInv;
			InvNumType _PEndInv = PEndInv;
			IntType _Action = Action;
			RowPointerType _PRowPointer = PRowPointer;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SequencePreSaveSp";
				
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCategory", _PCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PClosed", _PClosed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartInv", _PStartInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndInv", _PEndInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRowPointer", _PRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
