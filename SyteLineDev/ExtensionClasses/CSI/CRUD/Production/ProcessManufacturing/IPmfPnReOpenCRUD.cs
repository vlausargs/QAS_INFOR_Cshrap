//PROJECT NAME: Production
//CLASS NAME: IPmfPnReOpenCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnReOpenCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse Pmf_Pn_BatchSelect(Guid? PnRp);
		void Pmf_Pn_BatchUpdate(ICollectionLoadResponse pmf_pn_batchLoadResponse);
		ICollectionLoadResponse JobSelect(Guid? PnRp);
		void JobUpdate(ICollectionLoadResponse jobLoadResponse);
		ICollectionLoadResponse Pmf_FormulaSelect(Guid? PnRp);
		void Pmf_FormulaUpdate(ICollectionLoadResponse pmf_formulaLoadResponse);
		(int? ReturnCode, string InfoBar) AltExtGen_PmfPnReOpenSp(string AltExtGenSp, string InfoBar, Guid? PnRp);
	}
}

