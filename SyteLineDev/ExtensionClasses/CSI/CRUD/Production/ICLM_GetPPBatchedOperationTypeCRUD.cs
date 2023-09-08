//PROJECT NAME: Production
//CLASS NAME: ICLM_GetPPBatchedOperationTypeCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICLM_GetPPBatchedOperationTypeCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse Jrt_Sch1Select(int? BatchId, string BatchDefinition);
		ICollectionLoadResponse PP_OPER_TYPESelect();
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_GetPPBatchedOperationTypeSp(string AltExtGenSp, int? BatchId, string BatchDefinition);
	}
}

