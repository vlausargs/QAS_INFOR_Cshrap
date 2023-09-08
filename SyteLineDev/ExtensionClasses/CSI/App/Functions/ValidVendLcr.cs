//PROJECT NAME: Data
//CLASS NAME: ValidVendLcr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValidVendLcr : IValidVendLcr
	{
		readonly IApplicationDB appDB;
		
		public ValidVendLcr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ValidVendLcrSp(
			string PoNum,
			string VendLcrNum,
			string VendNum,
			decimal? ExchangeRate,
			decimal? MiscCharges,
			decimal? MChargesT,
			decimal? SalesTax,
			decimal? SalesTaxT,
			decimal? SalesTax2,
			decimal? SalesTaxT2,
			decimal? Freight,
			decimal? FreightT,
			string Infobar)
		{
			PoNumType _PoNum = PoNum;
			VendLcrNumType _VendLcrNum = VendLcrNum;
			VendNumType _VendNum = VendNum;
			ExchRateType _ExchangeRate = ExchangeRate;
			AmountType _MiscCharges = MiscCharges;
			AmountType _MChargesT = MChargesT;
			AmountType _SalesTax = SalesTax;
			AmountType _SalesTaxT = SalesTaxT;
			AmountType _SalesTax2 = SalesTax2;
			AmountType _SalesTaxT2 = SalesTaxT2;
			AmountType _Freight = Freight;
			AmountType _FreightT = FreightT;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidVendLcrSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendLcrNum", _VendLcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchangeRate", _ExchangeRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscCharges", _MiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MChargesT", _MChargesT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTax", _SalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTaxT", _SalesTaxT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTax2", _SalesTax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTaxT2", _SalesTaxT2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Freight", _Freight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FreightT", _FreightT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
