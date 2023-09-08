//PROJECT NAME: Finance
//CLASS NAME: ICHSCLM_ListVouchersCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSCLM_ListVouchersCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse CN_Journal1Select(string FilterString);
		ICollectionLoadResponse CN_Journal3Select();
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CHSCLM_ListVouchersSp(string AltExtGenSp, string FilterString);
	}
}

