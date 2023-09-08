//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROQtyConvert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROQtyConvert
	{
		int? SSSFSSROQtyConvertSP(
			string PSite = null,
			string PUM = null,
			string PItem = null,
			decimal? PQtyOnHand = null,
			decimal? PQtyRsvdCo = null);
	}
}

