//PROJECT NAME: Logistics
//CLASS NAME: SSSFSTaxCalcOne.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSTaxCalcOne : ISSSFSTaxCalcOne
	{
		readonly IApplicationDB appDB;
		
		public SSSFSTaxCalcOne(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			Guid? pLinePtr = null)
		{
			StringType _iTableName = iTableName;
			FSSRONumType _iSroNum = iSroNum;
			FSSROLineType _iSroLine = iSroLine;
			FSSROOperType _iSroOper = iSroOper;
			FSSROTransNumType _iTransNum = iTransNum;
			TaxCodeType _iHdrTaxCode1 = iHdrTaxCode1;
			TaxCodeType _iHdrTaxCode2 = iHdrTaxCode2;
			DateType _iTransDate = iTransDate;
			CostPrcType _iPrice = iPrice;
			QtyUnitType _iQty = iQty;
			TaxCodeType _iTrnTaxCode1 = iTrnTaxCode1;
			TaxCodeType _iTrnTaxCode2 = iTrnTaxCode2;
			FSPctType _iHdrDisc = iHdrDisc;
			FSPctType _iTrnDisc = iTrnDisc;
			CurrCodeType _iCurrCode = iCurrCode;
			CostPrcType _iFreight = iFreight;
			TaxCodeType _iFrtTaxCode1 = iFrtTaxCode1;
			TaxCodeType _iFrtTaxCode2 = iFrtTaxCode2;
			CostPrcType _iMiscCharges = iMiscCharges;
			TaxCodeType _iMscTaxCode1 = iMscTaxCode1;
			TaxCodeType _iMscTaxCode2 = iMscTaxCode2;
			TermsCodeType _iTermsCode = iTermsCode;
			Infobar _Infobar = Infobar;
			AmountType _oSalesTax = oSalesTax;
			AmountType _oSalesTax2 = oSalesTax2;
			StringType _pRefType = pRefType;
			RowPointer _pHdrPtr = pHdrPtr;
			StringType _pLineRefType = pLineRefType;
			RowPointer _pLinePtr = pLinePtr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSTaxCalcOneSp";
				
				appDB.AddCommandParameter(cmd, "iTableName", _iTableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroNum", _iSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroLine", _iSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroOper", _iSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTransNum", _iTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iHdrTaxCode1", _iHdrTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iHdrTaxCode2", _iHdrTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTransDate", _iTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPrice", _iPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iQty", _iQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTrnTaxCode1", _iTrnTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTrnTaxCode2", _iTrnTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iHdrDisc", _iHdrDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTrnDisc", _iTrnDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCurrCode", _iCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFreight", _iFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFrtTaxCode1", _iFrtTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFrtTaxCode2", _iFrtTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMiscCharges", _iMiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMscTaxCode1", _iMscTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMscTaxCode2", _iMscTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTermsCode", _iTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSalesTax", _oSalesTax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSalesTax2", _oSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pRefType", _pRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pHdrPtr", _pHdrPtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLineRefType", _pLineRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLinePtr", _pLinePtr, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				oSalesTax = _oSalesTax;
				oSalesTax2 = _oSalesTax2;
				
				return (Severity, Infobar, oSalesTax, oSalesTax2);
			}
		}
	}
}
