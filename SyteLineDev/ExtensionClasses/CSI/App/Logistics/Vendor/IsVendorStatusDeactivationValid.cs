//PROJECT NAME: Logistics
//CLASS NAME: IsVendorStatusDeactivationValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class IsVendorStatusDeactivationValid : IIsVendorStatusDeactivationValid
	{
		readonly IApplicationDB appDB;
		
		
		public IsVendorStatusDeactivationValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) IsVendorStatusDeactivationValidSp(string Stat,
		int? Active = 1,
		string Infobar = null)
		{
			VendorStatusType _Stat = Stat;
			ListYesNoType _Active = Active;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IsVendorStatusDeactivationValidSp";
				
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
