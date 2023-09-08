//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXSetShipUsALL.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXSetShipUsALL
	{
		(int? ReturnCode,
			int? oJurisCd,
			int? oGeo,
			string oState,
			string oCity,
			string oZip,
			string oCnty,
			string oCountry,
			string oAddr1,
			string oAddr2,
			string oAddr3,
			string oAddr4,
			string Infobar) SSSVTXSetShipUsALLSp(
			string iWhse,
			int? oJurisCd,
			int? oGeo,
			string oState,
			string oCity,
			string oZip,
			string oCnty,
			string oCountry,
			string oAddr1,
			string oAddr2,
			string oAddr3,
			string oAddr4,
			string Infobar);
	}
}

