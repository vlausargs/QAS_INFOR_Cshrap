//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXSetDropShip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXSetDropShip
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
			string Infobar) SSSVTXSetDropShipSp(
			string DropType,
			string DropNum,
			int? DropSeq,
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

