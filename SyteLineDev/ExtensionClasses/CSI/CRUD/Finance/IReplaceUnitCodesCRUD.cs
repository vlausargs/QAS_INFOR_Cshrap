//PROJECT NAME: Finance
//CLASS NAME: IReplaceUnitCodesCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IReplaceUnitCodesCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		string Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse ParmsSelect();
		ICollectionLoadResponse Tv_Updatetablecolumnrange1Select(int? UnitNumber);
		void Tv_Updatetablecolumnrange1Insert(ICollectionLoadResponse tv_UpdateTableColumnRange1LoadResponse);
		ICollectionLoadResponse Tv_Updatetablecolumnrange2Select(int? UnitNumber);
		void Tv_Updatetablecolumnrange2Insert(ICollectionLoadResponse tv_UpdateTableColumnRange2LoadResponse);
		void UniontableresultInsert(ICollectionLoadResponse unionTableResultLoadResponse);
		string Tv_Updatetablecolumnrange3Load(string SqlWhereSub01, string SqlWhereSub02, string SqlWhereSub03, string SqlWhereSub04, string SqlWhereSub05, string SqlWhereSub06, string SqlSelect, string SqlUpdate, string ParmsSite, string SqlSet);
		bool Chart_Unitcd1ForExists(string BegAcct, string EndAcct, string NewUnitCode);
		bool Chart_Unitcd2ForExists(string BegAcct, string EndAcct, string NewUnitCode);
		bool Chart_Unitcd3ForExists(string BegAcct, string EndAcct, string NewUnitCode);
		bool Chart_Unitcd4ForExists(string BegAcct, string EndAcct, string NewUnitCode);
		(int? ReturnCode, string Infobar) AltExtGen_ReplaceUnitCodesSp(string AltExtGenSp, string BegAcct, string EndAcct, int? UnitNumber, string OldUnitCode, string NewUnitCode, string Infobar);
	}
}

