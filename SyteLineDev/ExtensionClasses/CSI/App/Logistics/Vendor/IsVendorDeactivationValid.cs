//PROJECT NAME: Logistics
//CLASS NAME: IsVendorDeactivationValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class IsVendorDeactivationValid : IIsVendorDeactivationValid
	{
		readonly IApplicationDB appDB;
		
		
		public IsVendorDeactivationValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) IsVendorDeactivationValidSp(string VendNum,
		int? Active = 1,
		int? FromMethod = 1,
		string Infobar = null)
		{
			VendNumType _VendNum = VendNum;
			ListYesNoType _Active = Active;
			ListYesNoType _FromMethod = FromMethod;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IsVendorDeactivationValidSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Active", _Active, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromMethod", _FromMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
