//PROJECT NAME: Logistics
//CLASS NAME: RSQC_CustomerLicense.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RSQC_CustomerLicense : IRSQC_CustomerLicense
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CustomerLicense(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? IsQCLicensed) RSQC_CustomerLicenseSp(int? IsQCLicensed)
		{
			ListYesNoType _IsQCLicensed = IsQCLicensed;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CustomerLicenseSp";
				
				appDB.AddCommandParameter(cmd, "IsQCLicensed", _IsQCLicensed, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				IsQCLicensed = _IsQCLicensed;
				
				return (Severity, IsQCLicensed);
			}
		}
	}
}
