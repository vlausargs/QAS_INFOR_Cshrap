//PROJECT NAME: Finance
//CLASS NAME: ICLM_SitesWithSameBaseCurrCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_SitesWithSameBaseCurrCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string CurrCode, int? rowCount) CurrparmsLoad(string CurrCode);
		ICollectionLoadResponse SiteSelect(string CurrCode);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_SitesWithSameBaseCurrSp(string AltExtGenSp);
	}
}

