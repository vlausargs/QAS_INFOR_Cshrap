//PROJECT NAME: CSIVendor
//CLASS NAME: GetParmVchrAuthorize.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetParmVchrAuthorize
	{
		int GetParmVchrAuthorizeSp(ref byte? VchrAuthorize);
	}
	
	public class GetParmVchrAuthorize : IGetParmVchrAuthorize
	{
		readonly IApplicationDB appDB;
		
		public GetParmVchrAuthorize(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetParmVchrAuthorizeSp(ref byte? VchrAuthorize)
		{
			ListYesNoType _VchrAuthorize = VchrAuthorize;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetParmVchrAuthorizeSp";
				
				appDB.AddCommandParameter(cmd, "VchrAuthorize", _VchrAuthorize, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				VchrAuthorize = _VchrAuthorize;
				
				return Severity;
			}
		}
	}
}
