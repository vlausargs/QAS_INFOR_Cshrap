//PROJECT NAME: Finance
//CLASS NAME: ArBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArBal : IArBal
	{
		readonly IApplicationDB appDB;
		
		public ArBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ArBalSp(
			string Type,
			decimal? MiscCharges,
			decimal? Freight,
			decimal? SalesTax,
			decimal? Amount,
			decimal? SalesTax2)
		{
			ArinvTypeType _Type = Type;
			AmountType _MiscCharges = MiscCharges;
			AmountType _Freight = Freight;
			AmountType _SalesTax = SalesTax;
			AmountType _Amount = Amount;
			AmountType _SalesTax2 = SalesTax2;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ArBalSp](@Type, @MiscCharges, @Freight, @SalesTax, @Amount, @SalesTax2)";
				
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscCharges", _MiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Freight", _Freight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTax", _SalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTax2", _SalesTax2, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
