//PROJECT NAME: CSICustomer
//CLASS NAME: PmtpckSetTransferCash.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPmtpckSetTransferCash
	{
		int PmtpckSetTransferCashSp(Guid? PArpmtRowPointer,
		                            byte? SetTransferFlag,
		                            ref string PromptMsg,
		                            ref string PromptButtons);
	}
	
	public class PmtpckSetTransferCash : IPmtpckSetTransferCash
	{
		readonly IApplicationDB appDB;
		
		public PmtpckSetTransferCash(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PmtpckSetTransferCashSp(Guid? PArpmtRowPointer,
		                                   byte? SetTransferFlag,
		                                   ref string PromptMsg,
		                                   ref string PromptButtons)
		{
			RowPointerType _PArpmtRowPointer = PArpmtRowPointer;
			ListYesNoType _SetTransferFlag = SetTransferFlag;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmtpckSetTransferCashSp";
				
				appDB.AddCommandParameter(cmd, "PArpmtRowPointer", _PArpmtRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetTransferFlag", _SetTransferFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return Severity;
			}
		}
	}
}
