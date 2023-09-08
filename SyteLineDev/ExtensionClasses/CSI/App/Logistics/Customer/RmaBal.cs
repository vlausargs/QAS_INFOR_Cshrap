//PROJECT NAME: Logistics
//CLASS NAME: RmaBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaBal : IRmaBal
	{
		readonly IApplicationDB appDB;
		
		public RmaBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? RmaBalSp(
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
				cmd.CommandText = "SELECT  dbo.[RmaBalSp](@MiscCharges, @Freight, @SalesTax, @SalesTax2)";
				
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
