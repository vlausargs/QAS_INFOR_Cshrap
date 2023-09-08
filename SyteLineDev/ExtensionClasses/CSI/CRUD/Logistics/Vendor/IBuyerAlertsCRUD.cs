//PROJECT NAME: Logistics
//CLASS NAME: IBuyerAlertsCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IBuyerAlertsCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(int? OverDuePOLines, int? rowCount) LoadPOLinesCount(DateTime? Today, string Buyer, int? OverDuePOLines);
		(int? OverDuePOReleases, int? rowCount) LoadPOReleasesCount(DateTime? Today, string Buyer, int? OverDuePOReleases);
		(int? ReturnCode, int? OverDuePOLines, int? OverDuePOReleases, int? NumberOfUserTasks, int? NumberOfEventMessages) AltExtGen_BuyerAlertsSp(string AltExtGenSp, int? OverDuePOLines, int? OverDuePOReleases, int? NumberOfUserTasks, int? NumberOfEventMessages);
	}
}

