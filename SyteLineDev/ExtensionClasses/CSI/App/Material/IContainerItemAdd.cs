//PROJECT NAME: Material
//CLASS NAME: IContainerItemAdd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IContainerItemAdd
	{
		(ICollectionLoadResponse Data, int? ReturnCode,
			Guid? RowPointer,
			string Infobar) ContainerItemAddSp(
			string Whse,
			string Loc,
			string Item,
			string Lot,
			decimal? QtyContained,
			string ContainerNum,
			Guid? RowPointer,
			string Infobar);
	}
}

