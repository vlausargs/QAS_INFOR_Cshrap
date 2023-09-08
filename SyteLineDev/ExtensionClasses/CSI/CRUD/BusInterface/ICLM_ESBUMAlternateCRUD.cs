//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBUMAlternateCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBUMAlternateCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string baseISOUM, int? rowCount) LoadItem(string item, string baseISOUM);
		ICollectionLoadResponse SelectEsbumconvview(string item, string baseISOUM);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_ESBUMAlternateSp(string AltExtGenSp, string item);
	}
}

