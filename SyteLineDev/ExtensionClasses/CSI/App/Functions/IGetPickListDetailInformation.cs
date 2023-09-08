//PROJECT NAME: Data
//CLASS NAME: IGetPickListDetailInformation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPickListDetailInformation
	{
		(int? ReturnCode,
			decimal? QtyToShip,
			string InfoBar) GetPickListDetailInformationSp(
			decimal? picklist,
			string RefNum,
			int? RefLine,
			int? RefRelease,
			string fromlot,
			string fromloc,
			int? PickListRefSeq,
			decimal? PickLocQtyPicked,
			decimal? QtyToShip,
			string InfoBar);
	}
}

