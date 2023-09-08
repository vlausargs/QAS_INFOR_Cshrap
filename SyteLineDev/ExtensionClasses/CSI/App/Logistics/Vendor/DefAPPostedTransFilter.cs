//PROJECT NAME: CSIVendor
//CLASS NAME: DefAPPostedTransFilter.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IDefAPPostedTransFilter
	{
		int DefAPPostedTransFilterSp(ref string SiteFilterVar,
		                             ref string Infobar);
	}
	
	public class DefAPPostedTransFilter : IDefAPPostedTransFilter
	{
		readonly IApplicationDB appDB;
		
		public DefAPPostedTransFilter(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int DefAPPostedTransFilterSp(ref string SiteFilterVar,
		                                    ref string Infobar)
		{
			StringType _SiteFilterVar = SiteFilterVar;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DefAPPostedTransFilterSp";
				
				appDB.AddCommandParameter(cmd, "SiteFilterVar", _SiteFilterVar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SiteFilterVar = _SiteFilterVar;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
