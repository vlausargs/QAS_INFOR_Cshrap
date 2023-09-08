//PROJECT NAME: Data
//CLASS NAME: ITaxFreeImportItemAdd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITaxFreeImportItemAdd
	{
		(int? ReturnCode,
			string Infobar) TaxFreeImportItemAddSp(
			string ImportDocId,
			string Item,
			string Whse,
			string Loc,
			string Lot,
			decimal? Qty,
			string Infobar);
	}
}

