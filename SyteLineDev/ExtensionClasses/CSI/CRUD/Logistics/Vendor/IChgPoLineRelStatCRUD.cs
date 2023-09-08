//PROJECT NAME: Logistics
//CLASS NAME: IChgPoLineRelStatCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IChgPoLineRelStatCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		string Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		int? PoparmsLoad(int? PoParmsVendorReq);
		ICollectionLoadResponse PoSelect(string IPoStat, string IPoType, string SPoNum, string EPoNum, string SPoVendNum, string EPoVendNum, DateTime? SPoOrderDate, DateTime? EPoOrderDate);
		ICollectionLoadResponse PoitemSelect(int? SPoLine, int? EPoLine, int? SPoRelease, int? EPoRelease, DateTime? SPoitemDueDate, DateTime? EPoitemDueDate, DateTime? SPoitemRelDate, DateTime? EPoitemRelDate, string PoType, string PoPoNum);
		(Guid? ItemRowPointer, string ItemItem) ItemLoad(string PoitemItem, Guid? ItemRowPointer, string ItemItem);
		string Poitem1Load(Guid? PoitemRowPointer, string PoitemStat);
		ICollectionLoadResponse Poitem2Select(Guid? PoitemRowPointer);
		void Poitem2Update(string PoitemStat, ICollectionLoadResponse poitem2LoadResponse);
		string Po1Load(int? Severity, string PoitemPoNum, int? PoitemPoLine, int? PoitemPoRelease, string PoitemItem, string PoitemUM, decimal? PoitemQtyOrdered, decimal? PoitemItemCost, decimal? PoitemMaterialCost, decimal? PoitemFreightCost, decimal? PoitemDutyCost, decimal? PoitemBrokerageCost, decimal? PoitemInsuranceCost, decimal? PoitemLocalFreightCost, decimal? PoitemPlanCost, DateTime? PoitemDueDate, DateTime? PoitemPromiseDate, decimal? PoitemConvFactor, string Infobar, Guid? PoRowPointer, string PoStat);
		ICollectionLoadResponse Po2Select(Guid? PoRowPointer);
		void Po2Update(ICollectionLoadResponse po2LoadResponse);
		(Guid? PoBlnRowPointer, string PoBlnStat) Po_BlnLoad(string PoitemPoNum, int? PoitemPoLine, Guid? PoBlnRowPointer, string PoBlnStat);
		ICollectionLoadResponse Poitem3Select(Guid? PoitemRowPointer);
		void Poitem3Update(ICollectionLoadResponse poitem3LoadResponse);
		ICollectionLoadResponse Po_Bln1Select(Guid? PoBlnRowPointer);
		void Po_Bln1Update(ICollectionLoadResponse po_bln1LoadResponse);
		ICollectionLoadResponse NontableSelect(string PoitemPoNum, int? PoitemPoLine, int? PoitemPoRelease, string TOldPoitemStat, string TNewPoitemStat, string TMsg);
		void NontableInsert(ICollectionLoadResponse nonTableLoadResponse);
		ICollectionLoadResponse DynamicparametersSelect(string SelectionClause, string FromClause, string WhereClause, string AdditionalClause, string KeyColumns, string FilterString);
		void DynamicparametersInsert(ICollectionLoadResponse DynamicParametersLoadResponse);
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) AltExtGen_ChgPoLineRelStatSp(string AltExtGenSp, string ProcSel, string IPoStat, string IPoType, string SPoNum, string EPoNum, int? SPoLine, int? EPoLine, int? SPoRelease, int? EPoRelease, string SPoVendNum, string EPoVendNum, DateTime? SPoOrderDate, DateTime? EPoOrderDate, DateTime? SPoitemDueDate, DateTime? EPoitemDueDate, DateTime? SPoitemRelDate, DateTime? EPoitemRelDate, string Infobar, int? StartOrderDateOffset, int? EndOrderDateOffset, int? StartDueDateOffset, int? EndDueDateOffset, int? StartRelDateOffset, int? EndRelDateOffset);
	}
}

