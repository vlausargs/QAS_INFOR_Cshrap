//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXGetJurisCd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXGetJurisCd
	{
		(int? ReturnCode,
			int? oJurisCd,
			string Infobar) SSSVTXGetJurisCdSp(
			int? pGeo,
			string pState,
			string pCity,
			string pZip,
			string pCnty,
			int? oJurisCd,
			string Infobar);
	}
}

