//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_ToBeShippedValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_ToBeShippedValueCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		string Tv_ALTGEN1Load();
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		string CurrparmsLoad();
		int? CurrencyLoad(string DomCurrCode);
		ICollectionLoadResponse CoitemSelect(int? Severity, DateTime? StartDate, int? CurrentPeriod, string Infobar, string SiteRef, int? PeriodsFiscalYear, DateTime? PerStart, DateTime? PerEnd, string DomCurrCode, int? Places);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Homepage_ToBeShippedValueSp(string AltExtGenSp);
	}
}

