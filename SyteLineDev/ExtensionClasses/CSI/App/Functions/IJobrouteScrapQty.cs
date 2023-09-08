//PROJECT NAME: Data
//CLASS NAME: IJobrouteScrapQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobrouteScrapQty
	{
		decimal? JobrouteScrapQtyFn(
			string Job,
			int? Suffix,
			int? OperNum);
	}
}

