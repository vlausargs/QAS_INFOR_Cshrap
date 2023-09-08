//PROJECT NAME: Material
//CLASS NAME: ICoResValidateQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICoResValidateQty
	{
		(int? ReturnCode,
		string PUM,
		string Infobar) CoResValidateQtySp(
			string PItem,
			decimal? PQtyRsvd,
			decimal? PQtyRsvdOld = 0,
			string PUM = null,
			string PCoNum = null,
			int? PLotTracked = null,
			string PCurWhse = null,
			string PLot = null,
			string PLoc = null,
			string Infobar = null,
			string PImportDocId = null,
			int? PTaxFreeMatl = null);
	}
}

