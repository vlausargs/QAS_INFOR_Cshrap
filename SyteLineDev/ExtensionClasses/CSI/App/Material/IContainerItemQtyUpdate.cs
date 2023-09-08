//PROJECT NAME: Material
//CLASS NAME: IContainerItemQtyUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IContainerItemQtyUpdate
	{
		(int? ReturnCode,
			string Infobar) ContainerItemQtyUpdateSp(
			string Whse,
			string Loc,
			string Item,
			string Lot,
			decimal? QtyContained,
			string Infobar);
	}
}

