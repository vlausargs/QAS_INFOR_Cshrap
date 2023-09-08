//PROJECT NAME: Data
//CLASS NAME: CoBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CoBal : ICoBal
	{
		readonly IApplicationDB appDB;
		
		public CoBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? CoBalSp(
			decimal? MiscCharges,
			decimal? Freight,
			decimal? SalesTax,
			decimal? SalesTax2)
		{
			AmountType _MiscCharges = MiscCharges;
			AmountType _Freight = Freight;
			AmountType _SalesTax = SalesTax;
			AmountType _SalesTax2 = SalesTax2;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CoBalSp](@MiscCharges, @Freight, @SalesTax, @SalesTax2)";
				
				appDB.AddCommandParameter(cmd, "MiscCharges", _MiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Freight", _Freight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTax", _SalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTax2", _SalesTax2, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
