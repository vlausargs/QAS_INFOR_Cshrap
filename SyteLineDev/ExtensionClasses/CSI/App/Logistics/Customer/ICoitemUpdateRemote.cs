//PROJECT NAME: Logistics
//CLASS NAME: ICoitemUpdateRemote.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoitemUpdateRemote
	{
		(int? ReturnCode,
			string Infobar) CoitemUpdateRemoteSp(
			int? NewRecord,
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string CoType,
			int? CoStatusChanged,
			string CoCustNum,
			decimal? CoDisc,
			string CoitemWhse,
			string OldCoitemWhse,
			string CoitemUM,
			string OldCoitemUM,
			string CoitemItem,
			string OldCoitemItem,
			string CoitemStatus,
			string OldCoitemStatus,
			decimal? CoitemQtyOrdered,
			decimal? OldCoitemQtyOrdered,
			decimal? OldCoitemQtyShipped,
			decimal? CoitemQtyOrderedConv,
			decimal? OldCoitemQtyOrderedConv,
			decimal? OldCoitemQtyRsvd,
			decimal? CoitemPrice,
			decimal? OldCoitemPrice,
			decimal? OldCoitemPriceConv,
			decimal? CoitemDisc,
			decimal? OldCoitemDisc,
			string CoitemShipSite,
			string OldCoitemShipSite,
			string CoitemCoOrigSite,
			DateTime? CoitemDueDate,
			DateTime? OldCoitemDueDate,
			decimal? CoitemLbrCost,
			decimal? CoitemMatlCost,
			decimal? CoitemFovhdCost,
			decimal? CoitemVovhdCost,
			decimal? CoitemOutCost,
			string CoitemRefType,
			string OldCoitemRefType,
			string CoitemRefNum,
			string OldCoitemRefNum,
			int? CoitemRefLineSuf,
			int? OldCoitemRefLineSuf,
			int? CoitemRefRelease,
			int? OldCoitemRefRelease,
			string CoitemTaxCode1,
			string OldCoitemTaxCode1,
			string CoitemTaxCode2,
			string OldCoitemTaxCode2,
			string Infobar);
	}
}

