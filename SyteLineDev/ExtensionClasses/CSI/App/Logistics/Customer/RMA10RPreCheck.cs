//PROJECT NAME: CSICustomer
//CLASS NAME: RMA10RPreCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IRMA10RPreCheck
	{
		int RMA10RPreCheckSp(string BRmaNum,
		                     string ERmaNum,
		                     short? BRmaLine,
		                     short? ERmaLine,
		                     string BCustNum,
		                     string ECustNum,
		                     DateTime? BLastReturnDate,
		                     DateTime? ELastReturnDate,
		                     ref string PromptMsg,
		                     ref string PromptButtons);
	}
	
	public class RMA10RPreCheck : IRMA10RPreCheck
	{
		readonly IApplicationDB appDB;
		
		public RMA10RPreCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int RMA10RPreCheckSp(string BRmaNum,
		                            string ERmaNum,
		                            short? BRmaLine,
		                            short? ERmaLine,
		                            string BCustNum,
		                            string ECustNum,
		                            DateTime? BLastReturnDate,
		                            DateTime? ELastReturnDate,
		                            ref string PromptMsg,
		                            ref string PromptButtons)
		{
			RmaNumType _BRmaNum = BRmaNum;
			RmaNumType _ERmaNum = ERmaNum;
			RmaLineType _BRmaLine = BRmaLine;
			RmaLineType _ERmaLine = ERmaLine;
			CustNumType _BCustNum = BCustNum;
			CustNumType _ECustNum = ECustNum;
			DateType _BLastReturnDate = BLastReturnDate;
			DateType _ELastReturnDate = ELastReturnDate;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RMA10RPreCheckSp";
				
				appDB.AddCommandParameter(cmd, "BRmaNum", _BRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ERmaNum", _ERmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BRmaLine", _BRmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ERmaLine", _ERmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BCustNum", _BCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECustNum", _ECustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BLastReturnDate", _BLastReturnDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ELastReturnDate", _ELastReturnDate, ParameterDirection.Input);
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
