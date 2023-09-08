//PROJECT NAME: Finance
//CLASS NAME: ICLM_ExecutiveShipmentRevenueCRUD.cs

using System;
using System.Collections.Generic;
using System.Data;
using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_ExecutiveShipmentRevenueCRUD
	{
		void DeclareAltgenTable();
		bool Optional_ModuleForExists();
		void InsertOptional_Module();
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		void SetIsolationLevel();
		void DeleteTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectSite_Group(string SiteGroup);
		IList<string> InsertSite_Group(ICollectionLoadResponse loadResponse);
		(string DomCurrCode, int? rowCount) LoadCurrparms_All(string Site, string DomCurrCode);
		(int? DomCurrencyPlaces, int? DomCurrencyPlacesCp, int? rowCount) LoadCurrency(string DomCurrCode, int? DomCurrencyPlaces, int? DomCurrencyPlacesCp);
		(int? InvparmsPlacesQtyUnit, int? rowCount) LoadInvparms(int? InvparmsPlacesQtyUnit);
		void CreateTempCoitem();
		void CreateTempCoitemSum();
		void CreateTempTableTv_um();
		void InsertTempCoitem(IList<string> SiteList, DateTime? DateStarting, DateTime? DateEnding, string DomCurrCode);
		IRecordStream SelectTempCoitem(string DomCurrCode, LoadType loadType = LoadType.First, CachePageSize pageSize = CachePageSize.XLarge);
		void UpdateTempCoitemByCoitemPriceConv(int? seq, decimal? coitem_price_conv);
		void UpdateDiscountPriceForTempCoitem(int? DomCurrencyPlacesCp);
		void InsertTempTvUm();
		IRecordStream SelectTempTvUm(LoadType loadType = LoadType.First, CachePageSize pageSize = CachePageSize.XLarge);
		void UpdateTempTvUm(decimal? UomConvFactor, string coitem_ship_site, string coitem_item, string coitem_u_m, string co_cust_num);
		ICollectionLoadResponse SelectTempCoitemForUpdate();
		void UpdateTempCoitem(int? DomCurrencyPlacesCp, int? InvparmsPlacesQtyUnit, ICollectionLoadResponse Coitem3LoadResponse);
		void UpdateTempCoitemByDomCurrencyPlaces(int? DomCurrencyPlaces);
		void UpdateTempCoitem();
		void InsertTempCoitemsumForViewS();
		void InsertTempCoitemsumForViewP();
		void InsertTempCoitemsumForViewI();
		void UpdateTempCoitemsumByDomCurrCode(string DomCurrCode);
		void CreateTempCoitem2();
		ICollectionLoadResponse GetResultFromTempCoitemSum(LoadType loadType = LoadType.First, int recordCap = 5000);
		ICollectionLoadResponse GetResultFromTempCoitem2(LoadType loadType = LoadType.First, int recordCap = 5000);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_ExecutiveShipmentRevenueSp(string AltExtGenSp, string View, string SiteGroup, DateTime? DateStarting, DateTime? DateEnding, string FilterString);
	}
}

