//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSTaxCalcCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSTaxCalcCreate
	{
		(int? ReturnCode,
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
			Guid? VtxHdrRowPointer = null);
	}
}

