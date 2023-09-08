//PROJECT NAME: CSICustomer
//CLASS NAME: CoPriceIncludeTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICoPriceIncludeTax
	{
		int CoPriceIncludeTaxSp(string CoNum,
		                        ref byte? CoIncludePrice);
	}
	
	public class CoPriceIncludeTax : ICoPriceIncludeTax
	{
		readonly IApplicationDB appDB;
		
		public CoPriceIncludeTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CoPriceIncludeTaxSp(string CoNum,
		                               ref byte? CoIncludePrice)
		{
			CoNumType _CoNum = CoNum;
			ListYesNoType _CoIncludePrice = CoIncludePrice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoPriceIncludeTaxSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoIncludePrice", _CoIncludePrice, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoIncludePrice = _CoIncludePrice;
				
				return Severity;
			}
		}
	}
}
