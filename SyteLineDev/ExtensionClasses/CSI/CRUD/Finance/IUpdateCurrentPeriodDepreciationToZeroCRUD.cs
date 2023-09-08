//PROJECT NAME: Finance
//CLASS NAME: IUpdateCurrentPeriodDepreciationToZeroCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IUpdateCurrentPeriodDepreciationToZeroCRUD
	{
		bool CheckOptional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_Module();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool CheckTv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGEN(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse SelectFadepr(string pFaNum);
		void UpdateFadepr(ICollectionLoadResponse fadeprLoadResponse);
		(int? ReturnCode, int? pNeedToUpdateCurPerDepr) AltExtGen_UpdateCurrentPeriodDepreciationToZeroSp(string AltExtGenSp, string pFaNum, int? pNeedToUpdateCurPerDepr);
	}
}

