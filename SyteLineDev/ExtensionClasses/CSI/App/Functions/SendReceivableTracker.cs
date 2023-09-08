//PROJECT NAME: Data
//CLASS NAME: SendReceivableTracker.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SendReceivableTracker : ISendReceivableTracker
	{
		readonly IApplicationDB appDB;
		
		public SendReceivableTracker(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SendReceivableTrackerSp(
			string CustomerPartyID = null,
			string CheckNum = null,
			string BankCode = null,
			string Type = null,
			string CreditMemoNum = null,
			Guid? SessionID = null,
			string Infobar = null)
		{
			CustNumType _CustomerPartyID = CustomerPartyID;
			StringType _CheckNum = CheckNum;
			BankCodeType _BankCode = BankCode;
			CustPayTypeType _Type = Type;
			InvNumType _CreditMemoNum = CreditMemoNum;
			RowPointerType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SendReceivableTrackerSp";
				
				appDB.AddCommandParameter(cmd, "CustomerPartyID", _CustomerPartyID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditMemoNum", _CreditMemoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
