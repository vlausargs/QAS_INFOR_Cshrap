//PROJECT NAME: Material
//CLASS NAME: ICheckLotManufacturer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICheckLotManufacturer
	{
		(int? ReturnCode,
		string LotManufacturer,
		string LotManufacturerName,
		string LotManufacturerItem,
		string LotManItemDescription,
		string PromptMsg,
		string PromptButtons,
		int? DisplayMessage) CheckLotManufacturerSp(
			string Item,
			string Lot,
			string Type,
			string Manufacturer,
			string ManufacturerItem,
			string LotManufacturer,
			string LotManufacturerName,
			string LotManufacturerItem,
			string LotManItemDescription,
			string PromptMsg,
			string PromptButtons,
			int? DisplayMessage = 0);
	}
}

