//PROJECT NAME: Data
//CLASS NAME: GetCommTaxRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetCommTaxRate : IGetCommTaxRate
	{
		readonly IApplicationDB appDB;
		
		public GetCommTaxRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? GetCommTaxRateSp(
			string Slsman)
		{
			SlsmanType _Slsman = Slsman;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetCommTaxRateSp](@Slsman)";
				
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
