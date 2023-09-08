//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetXrefItemDataCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetXrefItemDataCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string o_desc, int? rowCount) ItemLoad(string i_item, string o_desc);
		ICollectionLoadResponse NontableSelect(string o_desc);
		(int? ReturnCode, string o_desc,string Infobar) AltExtGen_RSQC_GetXrefItemDataSp(string AltExtGenSp, string i_item, string o_desc, string Infobar);
	}
}

