//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetItemUMCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetItemUMCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string RefNum, int? RefLine, int? RefRelease, string RefType, int? rowCount) Rs_QcrcvrLoad(int? RcvrNum, string RefNum, int? RefLine, int? RefRelease, string RefType);
		(string NewUM, int? rowCount) RmaitemLoad(string RefNum, int? RefLine, string NewUM);
		(string NewUM, int? rowCount) CoitemLoad(string RefNum, int? RefLine, string NewUM);
		(int? ReturnCode, string NewUM) AltExtGen_RSQC_GetItemUMSp(string AltExtGenSp, int? RcvrNum, string NewUM);
	}
}

