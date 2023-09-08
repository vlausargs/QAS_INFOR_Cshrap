//PROJECT NAME: Data
//CLASS NAME: IItemPhantom.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemPhantom
	{
		int? ItemPhantomSp(
			string Item,
			string Component,
			decimal? Actual_Qty);
	}
}

