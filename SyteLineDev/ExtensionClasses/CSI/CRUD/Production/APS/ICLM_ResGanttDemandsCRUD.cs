//PROJECT NAME: Production
//CLASS NAME: ICLM_ResGanttDemandsCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ResGanttDemandsCRUD
	{
		bool CheckOptional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_Module();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool CheckTv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGEN(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_ResGanttDemandsSp(string AltExtGenSp, int? AltNum, int? PlannerFg);
	}
}

