//PROJECT NAME: Material
//CLASS NAME: ICheckLotManufacturerCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICheckLotManufacturerCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		string Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string LotManufacturer, string LotManufacturerName, string LotManufacturerItem, string LotManItemDescription) LotasltLoad(string Item, string Lot, string LotManufacturer, string LotManufacturerName, string LotManufacturerItem, string LotManItemDescription);
		(int? ReturnCode, string LotManufacturer,string LotManufacturerName,string LotManufacturerItem,string LotManItemDescription,string PromptMsg,string PromptButtons,int? DisplayMessage) AltExtGen_CheckLotManufacturerSp(string AltExtGenSp, string Item, string Lot, string Type, string Manufacturer, string ManufacturerItem, string LotManufacturer, string LotManufacturerName, string LotManufacturerItem, string LotManItemDescription, string PromptMsg, string PromptButtons, int? DisplayMessage);
	}
}

