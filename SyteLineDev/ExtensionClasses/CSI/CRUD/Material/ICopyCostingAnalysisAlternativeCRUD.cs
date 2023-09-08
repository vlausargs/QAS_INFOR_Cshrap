//PROJECT NAME: Material
//CLASS NAME: ICopyCostingAnalysisAlternativeCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICopyCostingAnalysisAlternativeCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse RouteSelect(string Item, string FromJob, string ToJob, int? FromSuffix, int? NewJobFlag);
		void RouteInsert(ICollectionLoadResponse routeLoadResponse);
		(int? CostItemAtWhse, string DefaultWhse, int? rowCount) InvparmsLoad(int? CostItemAtWhse, string DefaultWhse);
		(string JobPrefix, int? rowCount) Invparms1Load(string JobPrefix);
		bool Costing_AltForExists(string CostingAlt);
		(string CostType, int? CopyRoutingFlag, int? rowCount) Costing_Alt1Load(string CostingAltFrom, int? CopyRoutingFlag, string CostType);
		ICollectionLoadResponse NontableSelect(string CostingAlt, string CostingAltDescription, string BOMType, string CostType, string Whse, string DefaultWhse, int? CopyRouting);
		void NontableInsert(ICollectionLoadResponse nonTableLoadResponse);
		ICollectionLoadResponse ItemSelect(string PMTCode, string ABCCode, string CostMethod, string MatlType, string ProductCodeStarting, string ProductCodeEnding, string ItemStarting, string ItemEnding, string Whse, int? Suffix);
		void ItemInsert(ICollectionLoadResponse itemLoadResponse);
		ICollectionLoadResponse Item1Select(string PMTCode, string ABCCode, string CostMethod, string MatlType, string ProductCodeStarting, string ProductCodeEnding, string ItemStarting, string ItemEnding, int? Suffix);
		void Item1Insert(ICollectionLoadResponse item1LoadResponse);
		ICollectionLoadResponse Cai1Select(string CostingAltFrom, string PMTCode, string ABCCode, string CostMethod, string MatlType, string ProductCodeStarting, string ProductCodeEnding, string ItemStarting, string ItemEnding);
		void Cai1Insert(ICollectionLoadResponse cai1LoadResponse);
		ICollectionLoadResponse Costing_Alt_ItemSelect(string CostingAlt);
		void Costing_Alt_ItemInsert(ICollectionLoadResponse costing_alt_itemLoadResponse);
		(string CostType, int? CopyRoutingFlag, int? rowCount) Costing_Alt2Load(string CostingAlt, int? CopyRoutingFlag, string CostType);
		bool Costing_Alt_Item1ForExists(string CostingAltFrom);
		ICollectionLoadResponse Cai2Select(string CostingAlt, string CostingAltFrom, int? Suffix);
		ICollectionLoadResponse Cai3Select(int? Suffix, string CostingAlt);
		ICollectionLoadResponse Nontable1Select(string Item, string FromJob, string ToJob, int? NewJobFlag, int? FromSuffix);
		void Nontable1Insert(ICollectionLoadResponse nonTable1LoadResponse);
		ICollectionLoadResponse JrtresourcegroupSelect(int? CopyRoutingFlag);
		void JrtresourcegroupDelete(ICollectionLoadResponse jrtresourcegroupLoadResponse);
		ICollectionLoadResponse JobmatlSelect(int? CopyRoutingFlag);
		void JobmatlDelete(ICollectionLoadResponse jobmatlLoadResponse);
		ICollectionLoadResponse Jrt_SchSelect(int? CopyRoutingFlag);
		void Jrt_SchDelete(ICollectionLoadResponse jrt_schLoadResponse);
		ICollectionLoadResponse JobrouteSelect(int? CopyRoutingFlag);
		void JobrouteDelete(ICollectionLoadResponse jobrouteLoadResponse);
		ICollectionLoadResponse Job_SchSelect(int? CopyRoutingFlag);
		void Job_SchDelete(ICollectionLoadResponse job_schLoadResponse);
		ICollectionLoadResponse JobSelect(int? CopyRoutingFlag);
		void JobDelete(ICollectionLoadResponse jobLoadResponse);
		ICollectionLoadResponse Costing_Alt_Item2Select(string CostingAlt);
		void Costing_Alt_Item2Update(ICollectionLoadResponse costing_alt_item2LoadResponse);
		ICollectionLoadResponse Job1Select(int? CopyRoutingFlag);
		void Job1Insert(ICollectionLoadResponse job1LoadResponse);
		ICollectionLoadResponse Job_Sch1Select(int? CopyRoutingFlag);
		void Job_Sch1Insert(ICollectionLoadResponse job_sch1LoadResponse);
		ICollectionLoadResponse Jobroute1Select(int? CopyRoutingFlag);
		void Jobroute1Insert(ICollectionLoadResponse jobroute1LoadResponse);
		ICollectionLoadResponse Jrt_Sch1Select(int? CopyRoutingFlag);
		void Jrt_Sch1Insert(ICollectionLoadResponse jrt_sch1LoadResponse);
		ICollectionLoadResponse Jobmatl1Select(int? CopyRoutingFlag);
		void Jobmatl1Insert(ICollectionLoadResponse jobmatl1LoadResponse);
		ICollectionLoadResponse Jrtresourcegroup1Select(int? CopyRoutingFlag);
		void Jrtresourcegroup1Insert(ICollectionLoadResponse jrtresourcegroup1LoadResponse);
		ICollectionLoadResponse Costing_Alt_WcSelect(string CostingAlt);
		void Costing_Alt_WcInsert(ICollectionLoadResponse costing_alt_wcLoadResponse);
		ICollectionLoadResponse Costing_Alt_DeptSelect(string CostingAlt);
		void Costing_Alt_DeptInsert(ICollectionLoadResponse costing_alt_deptLoadResponse);
		ICollectionLoadResponse Costing_Alt_MaterialSelect(string CostingAlt, string Whse);
		void Costing_Alt_MaterialInsert(ICollectionLoadResponse costing_alt_materialLoadResponse);
		ICollectionLoadResponse Costing_Alt_Product_CodeSelect(string CostingAlt);
		void Costing_Alt_Product_CodeInsert(ICollectionLoadResponse costing_alt_product_codeLoadResponse);
		ICollectionLoadResponse Costing_Alt_Product_Code1Select(string CostingAlt, string CostingAltFrom);
		void Costing_Alt_Product_Code1Insert(ICollectionLoadResponse costing_alt_product_code1LoadResponse);
		ICollectionLoadResponse Costing_Alt_Wc1Select(string CostingAlt, string CostingAltFrom);
		void Costing_Alt_Wc1Insert(ICollectionLoadResponse costing_alt_wc1LoadResponse);
		ICollectionLoadResponse Costing_Alt_Dept1Select(string CostingAlt, string CostingAltFrom);
		void Costing_Alt_Dept1Insert(ICollectionLoadResponse costing_alt_dept1LoadResponse);
		ICollectionLoadResponse Costing_Alt_Material1Select(string CostingAlt, string CostingAltFrom);
		void Costing_Alt_Material1Insert(ICollectionLoadResponse costing_alt_material1LoadResponse);
		(int? ReturnCode, string Infobar) AltExtGen_CopyCostingAnalysisAlternativeSp(string AltExtGenSp, string CostingAlt, string CostingAltDescription, string BOMType, string Whse, string CostingAltFrom, int? CopyRouting, string PMTCode, string ABCCode, string CostMethod, string MatlType, string ProductCodeStarting, string ProductCodeEnding, string ItemStarting, string ItemEnding, string Infobar);
	}
}

