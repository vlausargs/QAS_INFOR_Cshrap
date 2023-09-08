//PROJECT NAME: Logistics
//CLASS NAME: CalcSalesTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CalcSalesTax : ICalcSalesTax
	{
		readonly IApplicationDB appDB;
		
		
		public CalcSalesTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PSalesTax) CalcSalesTaxSp(int? PTaxSystem,
		string PTaxCode,
		decimal? PTaxBasis,
		string PVendNum,
		decimal? PSalesTax)
		{
			TaxSystemType _PTaxSystem = PTaxSystem;
			TaxCodeType _PTaxCode = PTaxCode;
			AmountType _PTaxBasis = PTaxBasis;
			VendNumType _PVendNum = PVendNum;
			AmountType _PSalesTax = PSalesTax;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcSalesTaxSp";
				
				appDB.AddCommandParameter(cmd, "PTaxSystem", _PTaxSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode", _PTaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxBasis", _PTaxBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax", _PSalesTax, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSalesTax = _PSalesTax;
				
				return (Severity, PSalesTax);
			}
		}
	}
}
