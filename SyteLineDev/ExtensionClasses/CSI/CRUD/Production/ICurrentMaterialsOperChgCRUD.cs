//PROJECT NAME: Production
//CLASS NAME: ICurrentMaterialsOperChgCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICurrentMaterialsOperChgCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(int? MOShared, decimal? MOSecondsPerCycle, decimal? MOFormulaMatlWeight, string MOFormulaMatlWeightUnits, int? rowCount) LoadJobroute(string Job, int? Suffix, int? OperNum, int? MOShared, decimal? MOSecondsPerCycle, decimal? MOFormulaMatlWeight, string MOFormulaMatlWeightUnits);
		(int? ReturnCode, int? MOShared, decimal? MOSecondsPerCycle, decimal? MOFormulaMatlWeight, string MOFormulaMatlWeightUnits, string InfoBar) AltExtGen_CurrentMaterialsOperChgSp(string AltExtGenSp, string Job, int? Suffix, int? OperNum, int? MOShared, decimal? MOSecondsPerCycle, decimal? MOFormulaMatlWeight, string MOFormulaMatlWeightUnits, string InfoBar);
	}
}

