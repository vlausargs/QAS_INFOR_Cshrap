//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSTaxCalcOne.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSTaxCalcOne
	{
		(int? ReturnCode,
			string Infobar,
			decimal? oSalesTax,
			decimal? oSalesTax2) SSSFSTaxCalcOneSp(
			string iTableName,
			string iSroNum,
			int? iSroLine = null,
			int? iSroOper = null,
			int? iTransNum = null,
			string iHdrTaxCode1 = null,
			string iHdrTaxCode2 = null,
			DateTime? iTransDate = null,
			decimal? iPrice = 0,
			decimal? iQty = 0,
			string iTrnTaxCode1 = null,
			string iTrnTaxCode2 = null,
			decimal? iHdrDisc = null,
			decimal? iTrnDisc = 0,
			string iCurrCode = null,
			decimal? iFreight = 0,
			string iFrtTaxCode1 = null,
			string iFrtTaxCode2 = null,
			decimal? iMiscCharges = 0,
			string iMscTaxCode1 = null,
			string iMscTaxCode2 = null,
			string iTermsCode = null,
			string Infobar = null,
			decimal? oSalesTax = null,
			decimal? oSalesTax2 = null,
			string pRefType = null,
			Guid? pHdrPtr = null,
			string pLineRefType = null,
			Guid? pLinePtr = null);
	}
}

