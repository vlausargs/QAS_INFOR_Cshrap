//PROJECT NAME: Logistics
//CLASS NAME: ICLM_POBuilderPLNDataCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_POBuilderPLNDataCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse SiteSelect(string SiteGroup);
		ICollectionLoadResponse Site1Select(string Site);
		(string AppDataBase, int? rowCount) Site2Load(string All_Sites, string AppDataBase);
		void Tv_Tt_Tmp_Po_Builder1Insert(int? Severity, string All_Sites, string Infobar, string SQL, string AppDataBase, ICollectionLoadResponse tv_tt_tmp_po_builder1ExecResultLoadResponse, string Where);
		(int? Count, int? rowCount) Tv_Tt_Tmp_Po_Builder11Load(int? Count);
		(string SiteRef,
			 string Item,
			 string Description,
			 Guid? ApsPlanRowpointer,
			 decimal? QtyOrdered,
			 string UM,
			 DateTime? DueDate,
			 DateTime? ReleaseDate,
			 decimal? UnitMatCost,
			 decimal? UnitDutyCost,
			 decimal? UnitFreightCost,
			 decimal? UnitBrokerageCost,
			 decimal? UnitInsuranceCost,
			 decimal? UnitLocalFreight,
			 int? LeadTime,
			 string Reference, int? rowCount) Tv_Tt_Tmp_Po_Builder12Load(int? Index, int? Count, string Reference, string SiteRef, string Item, string Description, Guid? ApsPlanRowpointer, decimal? QtyOrdered, string UM, decimal? UnitMatCost, decimal? UnitDutyCost, decimal? UnitFreightCost, decimal? UnitBrokerageCost, decimal? UnitLocalFreight, decimal? UnitInsuranceCost, DateTime? ReleaseDate, DateTime? DueDate, int? LeadTime);
		ICollectionLoadResponse NontableSelect(string SiteRef, string Item, string Description, Guid? ApsPlanRowpointer, decimal? QtyOrdered, string UM, DateTime? DueDate, DateTime? ReleaseDate, decimal? PlanCost, decimal? UnitMatCost, decimal? UnitDutyCost, decimal? UnitFreightCost, decimal? UnitBrokerageCost, decimal? UnitInsuranceCost, decimal? UnitLocalFreight, int? LeadTime, string Reference, decimal? ExtendedCost);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_POBuilderPLNDataSp(string AltExtGenSp, int? RecordCap, string Site, string SiteGroup, string ItemStarting, string ItemEnding, DateTime? StartingDueDate, DateTime? EndingDueDate, string Planner, string VendorCurrCode);
		ICollectionLoadResponse NontableSelect2();
		void NontableInsert(ICollectionLoadResponse nonTableLoadResponse);
		ICollectionLoadResponse DynamicparametersSelect(string SelectionClause, string FromClause, string WhereClause, string AdditionalClause, string KeyColumns, string FilterString);
		void DynamicparametersInsert(ICollectionLoadResponse DynamicParametersLoadResponse);
	}
}

