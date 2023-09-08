//PROJECT NAME: Codes
//CLASS NAME: ICLM_LoadDimAttributeOverrideCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_LoadDimAttributeOverrideCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse SelectChart(string Acct, string SubscriberObjectName, Guid? SubscriberObjectRowPointer);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_LoadDimAttributeOverrideSp(string AltExtGenSp, string Acct, string SubscriberObjectName, Guid? SubscriberObjectRowPointer);
	}
}

