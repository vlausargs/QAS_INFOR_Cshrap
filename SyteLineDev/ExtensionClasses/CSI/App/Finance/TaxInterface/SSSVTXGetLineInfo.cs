//PROJECT NAME: Finance
//CLASS NAME: SSSVTXGetLineInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXGetLineInfo : ISSSVTXGetLineInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXGetLineInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? oSTJurisCd,
			int? oSTGeo,
			string oSTState,
			string oSTCity,
			string oSTZip,
			string oSTCnty,
			string oSTCountry,
			string oSTAddr1,
			string oSTAddr2,
			string oSTAddr3,
			string oSTAddr4,
			int? oSFJurisCd,
			int? oSFGeo,
			string oSFState,
			string oSFCity,
			string oSFZip,
			string oSFCnty,
			string oSFCountry,
			string oSFAddr1,
			string oSFAddr2,
			string oSFAddr3,
			string oSFAddr4,
			string oCurrCode,
			DateTime? oTaxDate,
			string oTaxCreditFlag,
			string oUM,
			string oDescription,
			decimal? oDiscount,
			string oCustNum,
			int? oCustSeq,
			string oItem,
			string oProdCode,
			string oTransRefType,
			string Infobar,
			string LocationCode) SSSVTXGetLineInfoSp(
			string pRefType,
			Guid? pHdrPtr,
			string pLineRefType,
			Guid? pLinePtr,
			int? oSTJurisCd,
			int? oSTGeo,
			string oSTState,
			string oSTCity,
			string oSTZip,
			string oSTCnty,
			string oSTCountry,
			string oSTAddr1,
			string oSTAddr2,
			string oSTAddr3,
			string oSTAddr4,
			int? oSFJurisCd,
			int? oSFGeo,
			string oSFState,
			string oSFCity,
			string oSFZip,
			string oSFCnty,
			string oSFCountry,
			string oSFAddr1,
			string oSFAddr2,
			string oSFAddr3,
			string oSFAddr4,
			string oCurrCode,
			DateTime? oTaxDate,
			string oTaxCreditFlag,
			string oUM,
			string oDescription,
			decimal? oDiscount,
			string oCustNum,
			int? oCustSeq,
			string oItem,
			string oProdCode,
			string oTransRefType,
			string Infobar,
			string LocationCode)
		{
			VTXRefTypeType _pRefType = pRefType;
			RowPointer _pHdrPtr = pHdrPtr;
			VTXLineRefType _pLineRefType = pLineRefType;
			RowPointer _pLinePtr = pLinePtr;
			IntType _oSTJurisCd = oSTJurisCd;
			IntType _oSTGeo = oSTGeo;
			StateType _oSTState = oSTState;
			CityType _oSTCity = oSTCity;
			PostalCodeType _oSTZip = oSTZip;
			CountyType _oSTCnty = oSTCnty;
			CountryType _oSTCountry = oSTCountry;
			AddressType _oSTAddr1 = oSTAddr1;
			AddressType _oSTAddr2 = oSTAddr2;
			AddressType _oSTAddr3 = oSTAddr3;
			AddressType _oSTAddr4 = oSTAddr4;
			IntType _oSFJurisCd = oSFJurisCd;
			IntType _oSFGeo = oSFGeo;
			StateType _oSFState = oSFState;
			CityType _oSFCity = oSFCity;
			PostalCodeType _oSFZip = oSFZip;
			CountyType _oSFCnty = oSFCnty;
			CountryType _oSFCountry = oSFCountry;
			AddressType _oSFAddr1 = oSFAddr1;
			AddressType _oSFAddr2 = oSFAddr2;
			AddressType _oSFAddr3 = oSFAddr3;
			AddressType _oSFAddr4 = oSFAddr4;
			CurrCodeType _oCurrCode = oCurrCode;
			DateTimeType _oTaxDate = oTaxDate;
			StringType _oTaxCreditFlag = oTaxCreditFlag;
			UMType _oUM = oUM;
			DescriptionType _oDescription = oDescription;
			LineDiscType _oDiscount = oDiscount;
			CustNumType _oCustNum = oCustNum;
			CustSeqType _oCustSeq = oCustSeq;
			ItemType _oItem = oItem;
			ProductCodeType _oProdCode = oProdCode;
			VTXTransTypeRefType _oTransRefType = oTransRefType;
			InfobarType _Infobar = Infobar;
			WhseType _LocationCode = LocationCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXGetLineInfoSp";
				
				appDB.AddCommandParameter(cmd, "pRefType", _pRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pHdrPtr", _pHdrPtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLineRefType", _pLineRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLinePtr", _pLinePtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oSTJurisCd", _oSTJurisCd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSTGeo", _oSTGeo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSTState", _oSTState, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSTCity", _oSTCity, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSTZip", _oSTZip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSTCnty", _oSTCnty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSTCountry", _oSTCountry, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSTAddr1", _oSTAddr1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSTAddr2", _oSTAddr2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSTAddr3", _oSTAddr3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSTAddr4", _oSTAddr4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSFJurisCd", _oSFJurisCd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSFGeo", _oSFGeo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSFState", _oSFState, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSFCity", _oSFCity, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSFZip", _oSFZip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSFCnty", _oSFCnty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSFCountry", _oSFCountry, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSFAddr1", _oSFAddr1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSFAddr2", _oSFAddr2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSFAddr3", _oSFAddr3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSFAddr4", _oSFAddr4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oCurrCode", _oCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oTaxDate", _oTaxDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oTaxCreditFlag", _oTaxCreditFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oUM", _oUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oDescription", _oDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oDiscount", _oDiscount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oCustNum", _oCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oCustSeq", _oCustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oItem", _oItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oProdCode", _oProdCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oTransRefType", _oTransRefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LocationCode", _LocationCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oSTJurisCd = _oSTJurisCd;
				oSTGeo = _oSTGeo;
				oSTState = _oSTState;
				oSTCity = _oSTCity;
				oSTZip = _oSTZip;
				oSTCnty = _oSTCnty;
				oSTCountry = _oSTCountry;
				oSTAddr1 = _oSTAddr1;
				oSTAddr2 = _oSTAddr2;
				oSTAddr3 = _oSTAddr3;
				oSTAddr4 = _oSTAddr4;
				oSFJurisCd = _oSFJurisCd;
				oSFGeo = _oSFGeo;
				oSFState = _oSFState;
				oSFCity = _oSFCity;
				oSFZip = _oSFZip;
				oSFCnty = _oSFCnty;
				oSFCountry = _oSFCountry;
				oSFAddr1 = _oSFAddr1;
				oSFAddr2 = _oSFAddr2;
				oSFAddr3 = _oSFAddr3;
				oSFAddr4 = _oSFAddr4;
				oCurrCode = _oCurrCode;
				oTaxDate = _oTaxDate;
				oTaxCreditFlag = _oTaxCreditFlag;
				oUM = _oUM;
				oDescription = _oDescription;
				oDiscount = _oDiscount;
				oCustNum = _oCustNum;
				oCustSeq = _oCustSeq;
				oItem = _oItem;
				oProdCode = _oProdCode;
				oTransRefType = _oTransRefType;
				Infobar = _Infobar;
				LocationCode = _LocationCode;
				
				return (Severity, oSTJurisCd, oSTGeo, oSTState, oSTCity, oSTZip, oSTCnty, oSTCountry, oSTAddr1, oSTAddr2, oSTAddr3, oSTAddr4, oSFJurisCd, oSFGeo, oSFState, oSFCity, oSFZip, oSFCnty, oSFCountry, oSFAddr1, oSFAddr2, oSFAddr3, oSFAddr4, oCurrCode, oTaxDate, oTaxCreditFlag, oUM, oDescription, oDiscount, oCustNum, oCustSeq, oItem, oProdCode, oTransRefType, Infobar, LocationCode);
			}
		}
	}
}
