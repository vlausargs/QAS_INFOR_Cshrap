//PROJECT NAME: Production
//CLASS NAME: IPmatlSumMaterial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IPmatlSumMaterial
	{
		(int? ReturnCode,
			string TItemDesc,
			decimal? TRequired,
			decimal? TIssued,
			decimal? TOnHand,
			string TUM,
			decimal? TRequiredConv,
			decimal? TIssuedConv,
			decimal? TOnHandConv,
			decimal? TQty,
			decimal? TQtyConv,
			string Infobar) PmatlSumMaterialSp(
			string ProjNum,
			int? TaskNum,
			int? Seq,
			string Item,
			string Whse,
			string TItemDesc,
			decimal? TRequired,
			decimal? TIssued,
			decimal? TOnHand,
			string TUM,
			decimal? TRequiredConv,
			decimal? TIssuedConv,
			decimal? TOnHandConv,
			decimal? TQty,
			decimal? TQtyConv,
			string Infobar);
	}
}

