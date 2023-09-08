//PROJECT NAME: Logistics
//CLASS NAME: CustomerRevDay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CustomerRevDay : ICustomerRevDay
	{
		readonly IApplicationDB appDB;
		
		
		public CustomerRevDay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? RevDayExist,
		string Infobar) CustomerRevDaySp(string CustNum,
		int? RevDayExist,
		string Infobar)
		{
			CustNumType _CustNum = CustNum;
			ListYesNoType _RevDayExist = RevDayExist;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustomerRevDaySp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevDayExist", _RevDayExist, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RevDayExist = _RevDayExist;
				Infobar = _Infobar;
				
				return (Severity, RevDayExist, Infobar);
			}
		}
	}
}
