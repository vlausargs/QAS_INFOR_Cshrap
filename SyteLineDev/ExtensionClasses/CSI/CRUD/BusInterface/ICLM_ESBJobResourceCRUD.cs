//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBJobResourceCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBJobResourceCRUD
	{
		bool CheckOptional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_Module();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool CheckTv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGEN(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse SelectEsbjobresourceview(string Job, int? Suffix, int? OperNum);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_ESBJobResourceSP(string AltExtGenSp, string Job, int? Suffix, int? OperNum);
	}
}

