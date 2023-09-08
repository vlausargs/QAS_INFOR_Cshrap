//PROJECT NAME: Material
//CLASS NAME: IWhseQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IWhseQty
	{
		(int? ReturnCode,
			decimal? PReorder,
			decimal? POnHand,
			string Infobar) WhseQtySp(
			string PItem,
			decimal? PReorder,
			decimal? POnHand,
			string Infobar);
	}
}

