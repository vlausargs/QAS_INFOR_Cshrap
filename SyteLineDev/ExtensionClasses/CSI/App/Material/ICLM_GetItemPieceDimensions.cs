//PROJECT NAME: Material
//CLASS NAME: ICLM_GetItemPieceDimensions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_GetItemPieceDimensions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetItemPieceDimensionsSp(string Item,
		string Whse,
		string Loc,
		string Lot,
		string SiteRef = null,
		string FilterString = null);
	}
}

