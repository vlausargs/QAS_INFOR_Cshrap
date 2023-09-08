//PROJECT NAME: Logistics
//CLASS NAME: IsVendorDeactivationValidAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class IsVendorDeactivationValidAll : IIsVendorDeactivationValidAll
	{
		readonly IApplicationDB appDB;
		
		
		public IsVendorDeactivationValidAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) IsVendorDeactivationValidAllSp(string VendNum,
		int? Active = 1,
		string SiteRef = null,
		string Infobar = null)
		{
			VendNumType _VendNum = VendNum;
			ListYesNoType _Active = Active;
			SiteType _SiteRef = SiteRef;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IsVendorDeactivationValidAllSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Active", _Active, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
