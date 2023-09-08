//PROJECT NAME: CSIVendor
//CLASS NAME: GetAPTaxInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetAPTaxInfo
	{
		int GetAPTaxInfoSp(ref byte? EnableTax1,
		                   ref byte? EnableTax2);
	}
	
	public class GetAPTaxInfo : IGetAPTaxInfo
	{
		readonly IApplicationDB appDB;
		
		public GetAPTaxInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetAPTaxInfoSp(ref byte? EnableTax1,
		                          ref byte? EnableTax2)
		{
			ListYesNoType _EnableTax1 = EnableTax1;
			ListYesNoType _EnableTax2 = EnableTax2;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAPTaxInfoSp";
				
				appDB.AddCommandParameter(cmd, "EnableTax1", _EnableTax1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EnableTax2", _EnableTax2, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EnableTax1 = _EnableTax1;
				EnableTax2 = _EnableTax2;
				
				return Severity;
			}
		}
	}
}
