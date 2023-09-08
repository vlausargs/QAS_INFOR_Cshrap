//PROJECT NAME: CSIVendor
//CLASS NAME: CheckVendorForConsgnWhse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICheckVendorForConsgnWhse
	{
		int CheckVendorForConsgnWhseSp(string ConsignmentType,
		                               string Whse,
		                               string VendNum,
		                               ref string Infobar);
	}
	
	public class CheckVendorForConsgnWhse : ICheckVendorForConsgnWhse
	{
		readonly IApplicationDB appDB;
		
		public CheckVendorForConsgnWhse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckVendorForConsgnWhseSp(string ConsignmentType,
		                                      string Whse,
		                                      string VendNum,
		                                      ref string Infobar)
		{
			ConsignmentTypeType _ConsignmentType = ConsignmentType;
			WhseType _Whse = Whse;
			VendNumType _VendNum = VendNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckVendorForConsgnWhseSp";
				
				appDB.AddCommandParameter(cmd, "ConsignmentType", _ConsignmentType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
