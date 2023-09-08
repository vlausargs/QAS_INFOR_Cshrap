//PROJECT NAME: Data
//CLASS NAME: ISarbWrt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISarbWrt
	{
		int? SarbWrtSp(
			string PItem,
			DateTime? PDate,
			decimal? PPrice,
			decimal? PQty);
	}
}

