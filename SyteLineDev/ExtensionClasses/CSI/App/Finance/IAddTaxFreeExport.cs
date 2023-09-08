//PROJECT NAME: Finance
//CLASS NAME: IAddTaxFreeExport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IAddTaxFreeExport
	{
		(int? ReturnCode,
			string Infobar) AddTaxFreeExportSp(
			string pRefType,
			string pRefNum,
			int? pRefLineSuf,
			int? pRefRelease,
			DateTime? pShipDate,
			decimal? pShipQty,
			string pExportDocId,
			string pItem,
			string pExportType,
			string Infobar);
	}
}

