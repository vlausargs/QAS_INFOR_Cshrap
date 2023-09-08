//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXChangeAddr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXChangeAddr
	{
		(int? ReturnCode,
			int? ioGeo,
			string ioState,
			string ioCity,
			string ioZip,
			string ioCnty,
			string ioCountry,
			string Infobar) SSSVTXChangeAddrSp(
			int? ioGeo,
			string ioState,
			string ioCity,
			string ioZip,
			string ioCnty,
			string ioCountry,
			string Infobar);
	}
}

