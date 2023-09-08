//PROJECT NAME: Data
//CLASS NAME: IValidateSerialonShipment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidateSerialonShipment
	{
		(int? ReturnCode,
			int? HadAddedToShip,
			string InfoBar) ValidateSerialonShipmentSp(
			decimal? picklist,
			int? PickListRefSeq,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Serial,
			int? HadAddedToShip,
			string InfoBar);
	}
}

