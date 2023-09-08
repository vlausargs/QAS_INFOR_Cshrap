//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_CustomerProductCodeBacklogCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_CustomerProductCodeBacklogCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		string Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse Coitem_AllSelect(string CustNum, string SiteRef, DateTime? num90Date, DateTime? EndDate);
		ICollectionLoadResponse ProdcodeSelect(string ProductCode, string SiteRef, DateTime? num90Date, DateTime? EndDate);
		ICollectionLoadResponse DynamicparametersSelect(string SelectionClause, string FromClause, string WhereClause, string AdditionalClause, string KeyColumns, string FilterString);
		void DynamicparametersInsert(ICollectionLoadResponse DynamicParametersLoadResponse);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Homepage_CustomerProductCodeBacklogSp(string AltExtGenSp, string CustNum, string ProductCode, string SiteRef, string FilterString);
	}
}

