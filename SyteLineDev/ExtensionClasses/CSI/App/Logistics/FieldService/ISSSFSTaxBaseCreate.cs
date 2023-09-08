//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSTaxBaseCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSTaxBaseCreate
	{
		(int? ReturnCode,
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
			Guid? VTXLineRowPointer = null);
	}
}

