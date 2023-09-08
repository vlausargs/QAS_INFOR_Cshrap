//PROJECT NAME: Finance
//CLASS NAME: SSSVTXGetHeaderInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXGetHeaderInfo : ISSSVTXGetHeaderInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXGetHeaderInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string oVTXInvNo,
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
			string oCustNum,
			int? oCustSeq,
			string oSlsman,
			string oCustPo,
			string Infobar,
			int? oMultiplier,
			string LocationCode) SSSVTXGetHeaderInfoSp(
			string PRefType,
			Guid? pHdrPtr,
			string oVTXInvNo,
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
			string oCustNum,
			int? oCustSeq,
			string oSlsman,
			string oCustPo,
			string Infobar,
			int? oMultiplier = 1,
			string LocationCode = null)
		{
			VTXRefTypeType _PRefType = PRefType;
			RowPointer _pHdrPtr = pHdrPtr;
			VTXInvNoType _oVTXInvNo = oVTXInvNo;
			VTXStJurisInCityType _oSTJurisCd = oSTJurisCd;
			VTXSgeoType _oSTGeo = oSTGeo;
			StateType _oSTState = oSTState;
			CityType _oSTCity = oSTCity;
			PostalCodeType _oSTZip = oSTZip;
			CountyType _oSTCnty = oSTCnty;
			CountryType _oSTCountry = oSTCountry;
			AddressType _oSTAddr1 = oSTAddr1;
			AddressType _oSTAddr2 = oSTAddr2;
			AddressType _oSTAddr3 = oSTAddr3;
			AddressType _oSTAddr4 = oSTAddr4;
			VTXStJurisInCityType _oSFJurisCd = oSFJurisCd;
			VTXSgeoType _oSFGeo = oSFGeo;
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
			CustNumType _oCustNum = oCustNum;
			CustSeqType _oCustSeq = oCustSeq;
			SlsmanType _oSlsman = oSlsman;
			CustPoType _oCustPo = oCustPo;
			InfobarType _Infobar = Infobar;
			IntType _oMultiplier = oMultiplier;
			WhseType _LocationCode = LocationCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXGetHeaderInfoSp";
				
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pHdrPtr", _pHdrPtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oVTXInvNo", _oVTXInvNo, ParameterDirection.InputOutput);
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
				appDB.AddCommandParameter(cmd, "oCustNum", _oCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oCustSeq", _oCustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSlsman", _oSlsman, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oCustPo", _oCustPo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oMultiplier", _oMultiplier, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LocationCode", _LocationCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oVTXInvNo = _oVTXInvNo;
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
				oCustNum = _oCustNum;
				oCustSeq = _oCustSeq;
				oSlsman = _oSlsman;
				oCustPo = _oCustPo;
				Infobar = _Infobar;
				oMultiplier = _oMultiplier;
				LocationCode = _LocationCode;
				
				return (Severity, oVTXInvNo, oSTJurisCd, oSTGeo, oSTState, oSTCity, oSTZip, oSTCnty, oSTCountry, oSTAddr1, oSTAddr2, oSTAddr3, oSTAddr4, oSFJurisCd, oSFGeo, oSFState, oSFCity, oSFZip, oSFCnty, oSFCountry, oSFAddr1, oSFAddr2, oSFAddr3, oSFAddr4, oCurrCode, oCustNum, oCustSeq, oSlsman, oCustPo, Infobar, oMultiplier, LocationCode);
			}
		}
	}
}
