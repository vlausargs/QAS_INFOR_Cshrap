//PROJECT NAME: Finance
//CLASS NAME: SSSVTXCalcTmpTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXCalcTmpTax : ISSSVTXCalcTmpTax
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXCalcTmpTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? oSalesTax,
			decimal? oSalesTax2,
			string Infobar) SSSVTXCalcTmpTaxSp(
			Guid? RowPointer,
			decimal? oSalesTax,
			decimal? oSalesTax2,
			string Infobar)
		{
			RowPointer _RowPointer = RowPointer;
			AmountType _oSalesTax = oSalesTax;
			AmountType _oSalesTax2 = oSalesTax2;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXCalcTmpTaxSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oSalesTax", _oSalesTax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSalesTax2", _oSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oSalesTax = _oSalesTax;
				oSalesTax2 = _oSalesTax2;
				Infobar = _Infobar;
				
				return (Severity, oSalesTax, oSalesTax2, Infobar);
			}
		}
	}
}
