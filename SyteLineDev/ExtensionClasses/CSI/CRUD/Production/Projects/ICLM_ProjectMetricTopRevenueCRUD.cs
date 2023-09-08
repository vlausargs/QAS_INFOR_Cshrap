//PROJECT NAME: Production
//CLASS NAME: ICLM_ProjectMetricTopRevenueCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ICLM_ProjectMetricTopRevenueCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse ProjSelect(int? Count);
		ICollectionLoadResponse Proj1Select();
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_ProjectMetricTopRevenueSp(string AltExtGenSp, int? Count);
	}
}

