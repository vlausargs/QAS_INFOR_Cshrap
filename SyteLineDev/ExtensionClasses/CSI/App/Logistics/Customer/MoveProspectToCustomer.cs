//PROJECT NAME: Logistics
//CLASS NAME: MoveProspectToCustomer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class MoveProspectToCustomer : IMoveProspectToCustomer
	{
		readonly IApplicationDB appDB;
		
		
		public MoveProspectToCustomer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string OutCustNum,
		string Infobar) MoveProspectToCustomerSp(string ProspectId,
		string NewCustNum,
		string BankCode,
		string OutCustNum,
		string Infobar)
		{
			ProspectIDType _ProspectId = ProspectId;
			CustNumType _NewCustNum = NewCustNum;
			BankCodeType _BankCode = BankCode;
			CustNumType _OutCustNum = OutCustNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MoveProspectToCustomerSp";
				
				appDB.AddCommandParameter(cmd, "ProspectId", _ProspectId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewCustNum", _NewCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutCustNum", _OutCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutCustNum = _OutCustNum;
				Infobar = _Infobar;
				
				return (Severity, OutCustNum, Infobar);
			}
		}
	}
}
