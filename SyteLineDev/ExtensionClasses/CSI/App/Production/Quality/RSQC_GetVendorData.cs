//PROJECT NAME: Production
//CLASS NAME: RSQC_GetVendorData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetVendorData : IRSQC_GetVendorData
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetVendorData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RSQC_GetVendorDataSp(string i_vendor,
		string o_stat,
		string o_desc,
		string Infobar)
		{
			VendNumType _i_vendor = i_vendor;
			DescriptionType _o_stat = o_stat;
			DescriptionType _o_desc = o_desc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetVendorDataSp";
				
				appDB.AddCommandParameter(cmd, "i_vendor", _i_vendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_stat", _o_stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_desc", _o_desc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
