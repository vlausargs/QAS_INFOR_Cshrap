//PROJECT NAME: Logistics
//CLASS NAME: ICLM_CustomerTop5SalesCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_CustomerTop5SalesCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string, int? rowCount) CurrparmsLoad(string DomCurrCode);
		ICollectionLoadResponse Tv_Top1duedateSelect();
		void Tv_Top1duedateInsert(ICollectionLoadResponse tv_Top1DueDateLoadResponse);
		ICollectionLoadResponse Tv_Top5salesSelect(string DomCurrCode);
		void Tv_Top5salesInsert(ICollectionLoadResponse tv_Top5SalesLoadResponse);
		ICollectionLoadResponse Tv_Top5sales1Select(DateTime? SiteDate);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_CustomerTop5SalesSp(string AltExtGenSp);
	}
}

