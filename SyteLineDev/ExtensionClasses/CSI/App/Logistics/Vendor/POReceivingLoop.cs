//PROJECT NAME: CSIVendor
//CLASS NAME: POReceivingLoop.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPOReceivingLoop
	{
		(int? ReturnCode, int? FirstSequenceWithError, string Infobar, string PromptButtons) POReceivingLoopSp(int? FirstSequenceWithError,
		string Infobar,
		string PromptButtons = null,
		string DocumentNum = null,
		byte? ParentWantsReturnCode = (byte)0);
	}
	
	public class POReceivingLoop : IPOReceivingLoop
	{
		readonly IApplicationDB appDB;
		
		public POReceivingLoop(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? FirstSequenceWithError, string Infobar, string PromptButtons) POReceivingLoopSp(int? FirstSequenceWithError,
		string Infobar,
		string PromptButtons = null,
		string DocumentNum = null,
		byte? ParentWantsReturnCode = (byte)0)
		{
			IntType _FirstSequenceWithError = FirstSequenceWithError;
			InfobarType _Infobar = Infobar;
			InfobarType _PromptButtons = PromptButtons;
			DocumentNumType _DocumentNum = DocumentNum;
			ListYesNoType _ParentWantsReturnCode = ParentWantsReturnCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "POReceivingLoopSp";
				
				appDB.AddCommandParameter(cmd, "FirstSequenceWithError", _FirstSequenceWithError, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentWantsReturnCode", _ParentWantsReturnCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FirstSequenceWithError = _FirstSequenceWithError;
				Infobar = _Infobar;
				PromptButtons = _PromptButtons;
				
				return (Severity, FirstSequenceWithError, Infobar, PromptButtons);
			}
		}
	}
}
