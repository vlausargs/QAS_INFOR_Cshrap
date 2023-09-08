//PROJECT NAME: Logistics
//CLASS NAME: SSSFSTaxBaseCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSTaxBaseCreate : ISSSFSTaxBaseCreate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSTaxBaseCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSTaxBaseCreateSp(
			string TaxCode1,
			string TaxCode2,
			decimal? PriceDiscExt,
			decimal? PriceExt,
			DateTime? InvDate,
			string CurrCode,
			decimal? ExchRate,
			string Infobar,
			string VTXRefType = null,
			Guid? VTXHdrRowPointer = null,
			string VTXLineType = null,
			Guid? VTXLineRowPointer = null)
		{
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			AmountType _PriceDiscExt = PriceDiscExt;
			AmountType _PriceExt = PriceExt;
			DateType _InvDate = InvDate;
			CurrCodeType _CurrCode = CurrCode;
			ExchRateType _ExchRate = ExchRate;
			Infobar _Infobar = Infobar;
			StringType _VTXRefType = VTXRefType;
			RowPointerType _VTXHdrRowPointer = VTXHdrRowPointer;
			StringType _VTXLineType = VTXLineType;
			RowPointerType _VTXLineRowPointer = VTXLineRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSTaxBaseCreateSp";
				
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceDiscExt", _PriceDiscExt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceExt", _PriceExt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VTXRefType", _VTXRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VTXHdrRowPointer", _VTXHdrRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VTXLineType", _VTXLineType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VTXLineRowPointer", _VTXLineRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
