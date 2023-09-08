//PROJECT NAME: Logistics
//CLASS NAME: IsCustomerStatusDeactivationValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class IsCustomerStatusDeactivationValid : IIsCustomerStatusDeactivationValid
	{
		readonly IApplicationDB appDB;
		
		
		public IsCustomerStatusDeactivationValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) IsCustomerStatusDeactivationValidSp(string Stat,
		int? Active = 1,
		string Infobar = null)
		{
			CustomerStatusType _Stat = Stat;
			ListYesNoType _Active = Active;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IsCustomerStatusDeactivationValidSp";
				
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Active", _Active, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
