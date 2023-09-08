//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetUnitPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetUnitPrice
	{
		(int? ReturnCode,
			decimal? FsSaleAmount,
			decimal? FsListAmount) SSSFSGetUnitPriceSp(
			string FsUnitConsCoNum,
			int? FsUnitConsCoLine,
			string InItem,
			decimal? FsSaleAmount,
			decimal? FsListAmount);
	}
}

