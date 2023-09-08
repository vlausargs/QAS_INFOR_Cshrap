//PROJECT NAME: Codes
//CLASS NAME: ICLM_GetInvProceduralMarkingsCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_GetInvProceduralMarkingsCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse SelectVat_Procedural_Marking_All(string SiteRef, string InvNum, int? InvSeq);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_GetInvProceduralMarkingsSp(string AltExtGenSp, string InvNum, int? InvSeq, string SiteRef);
	}
}

