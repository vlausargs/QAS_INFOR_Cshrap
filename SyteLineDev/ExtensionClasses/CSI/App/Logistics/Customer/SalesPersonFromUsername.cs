//PROJECT NAME: Logistics
//CLASS NAME: SalesPersonFromUsername.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ISalesPersonFromUsername
	{
		(int? ReturnCode, string SalesPerson) SalesPersonFromUsernameSp(string UserName,
		                                                                string SalesPerson);
	}
	
	public class SalesPersonFromUsername : ISalesPersonFromUsername
	{
		readonly IApplicationDB appDB;
		
		public SalesPersonFromUsername(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string SalesPerson) SalesPersonFromUsernameSp(string UserName,
		                                                                       string SalesPerson)
		{
			UsernameType _UserName = UserName;
			SlsmanType _SalesPerson = SalesPerson;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SalesPersonFromUsernameSp";
				
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesPerson", _SalesPerson, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SalesPerson = _SalesPerson;
				
				return (Severity, SalesPerson);
			}
		}
	}
}
