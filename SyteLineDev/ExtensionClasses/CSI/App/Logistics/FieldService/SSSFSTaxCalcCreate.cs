//PROJECT NAME: Logistics
//CLASS NAME: SSSFSTaxCalcCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSTaxCalcCreate : ISSSFSTaxCalcCreate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSTaxCalcCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TaxAmt1,
			decimal? TaxAmt2,
			string Infobar) SSSFSTaxCalcCreateSp(
			string TaxCode1,
			string TaxCode2,
			DateTime? InvDate,
			string CurrCode,
			decimal? TaxAmt1,
			decimal? TaxAmt2,
			string Infobar,
			string VtxRefType = null,
			Guid? VtxHdrRowPointer = null)
		{
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			DateType _InvDate = InvDate;
			CurrCodeType _CurrCode = CurrCode;
			AmountType _TaxAmt1 = TaxAmt1;
			AmountType _TaxAmt2 = TaxAmt2;
			Infobar _Infobar = Infobar;
			StringType _VtxRefType = VtxRefType;
			RowPointerType _VtxHdrRowPointer = VtxHdrRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSTaxCalcCreateSp";
				
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxAmt1", _TaxAmt1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxAmt2", _TaxAmt2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VtxRefType", _VtxRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VtxHdrRowPointer", _VtxHdrRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TaxAmt1 = _TaxAmt1;
				TaxAmt2 = _TaxAmt2;
				Infobar = _Infobar;
				
				return (Severity, TaxAmt1, TaxAmt2, Infobar);
			}
		}
	}
}
