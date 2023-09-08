//PROJECT NAME: Admin
//CLASS NAME: ICLM_ProductCodeMarginCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICLM_ProductCodeMarginCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		string Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		int? PeriodsallviewaspvLoad(string SiteRef, int? StartPeriod);
		int? Periodsallviewaspv1Load(string SiteRef, int? EndPeriod);
		DateTime? Periodsallviewaspv2Load(int? StartYear, int? StartPeriod, string SiteRef, DateTime? StartDate);
		DateTime? Periodsallviewaspv3Load(int? EndYear, int? EndPeriod, string SiteRef, DateTime? EndDate);
		ICollectionLoadResponse Tv_PoductcodeamountsSelect(int? TotalPages, string SiteRef, DateTime? StartDate, DateTime? EndDate);
		void Tv_PoductcodeamountsInsert(ICollectionLoadResponse tv_PoductCodeAmountsLoadResponse);
		(decimal? GrossExpenseAmount, decimal? GrossRevenueAmount, decimal? GrossNetAmount) Tv_Poductcodeamounts1Load(decimal? GrossExpenseAmount, decimal? GrossRevenueAmount, decimal? GrossNetAmount);
		ICollectionLoadResponse Tv_Poductcodeamounts2Select(string ProductCode);
		void Tv_Poductcodeamounts2Update(decimal? GrossNetAmount, ICollectionLoadResponse tv_PoductCodeAmounts2LoadResponse);
		ICollectionLoadResponse Tv_Poductcodeamounts3Select(string ProductCode, int? EntriesPerPage);
		ICollectionLoadResponse Tv_Poductcodeamounts4Select(string ProductCode);
		void Tv_Poductcodeamounts4Update(int? TotalPages, ICollectionLoadResponse tv_PoductCodeAmounts4LoadResponse);
		ICollectionLoadResponse Tv_Poductcodeamounts5Select(int? EntriesPerPage, int? PageNum, string ProductCode);
		void Tv_Poductcodeamounts5Delete(ICollectionLoadResponse tv_PoductCodeAmounts5LoadResponse);
		ICollectionLoadResponse Tv_Poductcodeamounts6Select(string ProductCode, int? EntriesPerPage);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_ProductCodeMarginSp(string AltExtGenSp, string ProductCode, int? StartYear, int? EndYear, int? StartPeriod, int? EndPeriod, int? PageNum, int? EntriesPerPage, string SiteRef);
	}
}

