//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXFSPGetHeaderInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXFSPGetHeaderInfo
	{
		(int? ReturnCode,
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
			string LocationCode) SSSVTXFSPGetHeaderInfoSp(
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
			string LocationCode);
	}
}

