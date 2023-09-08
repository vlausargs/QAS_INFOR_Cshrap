//PROJECT NAME: Logistics
//CLASS NAME: ISSSTraceStartWrapCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSTraceStartWrapCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(int? ReturnCode, int? oTraceID, string oServerName, string oTraceFile, string Infobar) AltExtGen_SSSTraceStartWrapSp(string AltExtGenSp, long? iMaxTraceSizeMB, int? oTraceID, string oServerName, string oTraceFile, string Infobar, string FilterDatabaseNameLike, string FilterHostNameLike, string FilterLoginNameLike, string FilterTextDataLike, string FilterObjectNameLike, int? FilterSPIDEQ);
	}
}

