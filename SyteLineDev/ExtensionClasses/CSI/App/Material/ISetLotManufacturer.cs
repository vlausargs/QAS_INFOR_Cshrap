//PROJECT NAME: Material
//CLASS NAME: ISetLotManufacturer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ISetLotManufacturer
	{
		int? SetLotManufacturerSp(string Item = null,
		string Lot = null,
		string Manufacturer = null,
		string ManufacturerItem = null,
		int? SetAllowFlag = 1);
	}
}

