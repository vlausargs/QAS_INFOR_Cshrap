//PROJECT NAME: Data
//CLASS NAME: RepCoitem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RepCoitem : IRepCoitem
	{
		readonly IApplicationDB appDB;
		
		public RepCoitem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RepCoitemSp(
			string ShipSite,
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string Item,
			string CustItem,
			string FeatStr,
			string Stat,
			DateTime? PromiseDate,
			string Pricecode,
			string UM,
			string Description,
			string CoOrigSite,
			decimal? QtyOrdered,
			decimal? Disc,
			decimal? Price,
			DateTime? DueDate,
			int? Reprice,
			string CustNum,
			int? CustSeq,
			DateTime? ReleaseDate,
			string Whse,
			string CommCode,
			string TransNat,
			string ProcessInd,
			string Delterm,
			decimal? SupplQtyConvFactor,
			string Origin,
			int? ConsNum,
			string TaxCode1,
			string TaxCode2,
			decimal? ExportValue,
			string EcCode,
			decimal? QtyOrderedConv,
			decimal? PriceConv,
			string CoCustNum,
			string Transport,
			string RefType,
			DateTime? ProjectedDate,
			decimal? QtyShipped,
			decimal? QtyReturned,
			decimal? QtyRsvd,
			decimal? QtyReady,
			decimal? QtyPacked,
			int? Packed,
			DateTime? ShipDate,
			decimal? QtyInvoiced,
			decimal? UnitWeight,
			string Mode,
			int? SyncReqd,
			string TransNat2,
			int? PlanOnSave,
			int? ApsMode,
			int? EdiInOrderPSp,
			string ConfigId,
			int? AllowOverCreditLimit,
			string NonInvAcct,
			string NonInvAcctUnit1,
			string NonInvAcctUnit2,
			string NonInvAcctUnit3,
			string NonInvAcctUnit4,
			string ManufacturerId,
			string ManufacturerItem,
			decimal? PrgBillTot,
			decimal? PrgBillApp,
			int? RepFromTrigger = 0,
			string UETListPairs = null,
			decimal? QtyPicked = null,
			int? InvoiceHold = 0)
		{
			SiteType _ShipSite = ShipSite;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			ItemType _Item = Item;
			CustItemType _CustItem = CustItem;
			FeatStrType _FeatStr = FeatStr;
			CoStatusType _Stat = Stat;
			DateType _PromiseDate = PromiseDate;
			PriceCodeType _Pricecode = Pricecode;
			UMType _UM = UM;
			DescriptionType _Description = Description;
			SiteType _CoOrigSite = CoOrigSite;
			QtyUnitType _QtyOrdered = QtyOrdered;
			LineDiscType _Disc = Disc;
			AmountType _Price = Price;
			DateType _DueDate = DueDate;
			ListYesNoType _Reprice = Reprice;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			DateType _ReleaseDate = ReleaseDate;
			WhseType _Whse = Whse;
			CommodityCodeType _CommCode = CommCode;
			TransNatType _TransNat = TransNat;
			ProcessIndType _ProcessInd = ProcessInd;
			DeltermType _Delterm = Delterm;
			UMConvFactorType _SupplQtyConvFactor = SupplQtyConvFactor;
			EcCodeType _Origin = Origin;
			ConsignmentsType _ConsNum = ConsNum;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			AmountType _ExportValue = ExportValue;
			EcCodeType _EcCode = EcCode;
			QtyUnitType _QtyOrderedConv = QtyOrderedConv;
			AmountType _PriceConv = PriceConv;
			CustNumType _CoCustNum = CoCustNum;
			TransportType _Transport = Transport;
			RefTypeIJKPRTType _RefType = RefType;
			DateType _ProjectedDate = ProjectedDate;
			QtyUnitNoNegType _QtyShipped = QtyShipped;
			QtyUnitNoNegType _QtyReturned = QtyReturned;
			QtyUnitNoNegType _QtyRsvd = QtyRsvd;
			QtyUnitNoNegType _QtyReady = QtyReady;
			QtyUnitNoNegType _QtyPacked = QtyPacked;
			ListYesNoType _Packed = Packed;
			DateType _ShipDate = ShipDate;
			QtyUnitNoNegType _QtyInvoiced = QtyInvoiced;
			UnitWeightType _UnitWeight = UnitWeight;
			StringType _Mode = Mode;
			ListYesNoType _SyncReqd = SyncReqd;
			TransNat2Type _TransNat2 = TransNat2;
			ListYesNoType _PlanOnSave = PlanOnSave;
			ListYesNoType _ApsMode = ApsMode;
			ListYesNoType _EdiInOrderPSp = EdiInOrderPSp;
			ConfigIdType _ConfigId = ConfigId;
			ListYesNoType _AllowOverCreditLimit = AllowOverCreditLimit;
			AcctType _NonInvAcct = NonInvAcct;
			UnitCode1Type _NonInvAcctUnit1 = NonInvAcctUnit1;
			UnitCode2Type _NonInvAcctUnit2 = NonInvAcctUnit2;
			UnitCode3Type _NonInvAcctUnit3 = NonInvAcctUnit3;
			UnitCode4Type _NonInvAcctUnit4 = NonInvAcctUnit4;
			ManufacturerIdType _ManufacturerId = ManufacturerId;
			ManufacturerItemType _ManufacturerItem = ManufacturerItem;
			AmountType _PrgBillTot = PrgBillTot;
			AmountType _PrgBillApp = PrgBillApp;
			ListYesNoType _RepFromTrigger = RepFromTrigger;
			VeryLongListType _UETListPairs = UETListPairs;
			QtyUnitNoNegType _QtyPicked = QtyPicked;
			ListYesNoType _InvoiceHold = InvoiceHold;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RepCoitemSp";
				
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromiseDate", _PromiseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoOrigSite", _CoOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Disc", _Disc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Price", _Price, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reprice", _Reprice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReleaseDate", _ReleaseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CommCode", _CommCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessInd", _ProcessInd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Delterm", _Delterm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SupplQtyConvFactor", _SupplQtyConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Origin", _Origin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConsNum", _ConsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExportValue", _ExportValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EcCode", _EcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoCustNum", _CoCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Transport", _Transport, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjectedDate", _ProjectedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReturned", _QtyReturned, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyRsvd", _QtyRsvd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReady", _QtyReady, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPacked", _QtyPacked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Packed", _Packed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipDate", _ShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyInvoiced", _QtyInvoiced, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitWeight", _UnitWeight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SyncReqd", _SyncReqd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNat2", _TransNat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanOnSave", _PlanOnSave, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApsMode", _ApsMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EdiInOrderPSp", _EdiInOrderPSp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConfigId", _ConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllowOverCreditLimit", _AllowOverCreditLimit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcct", _NonInvAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit1", _NonInvAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit2", _NonInvAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit3", _NonInvAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit4", _NonInvAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerId", _ManufacturerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerItem", _ManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrgBillTot", _PrgBillTot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrgBillApp", _PrgBillApp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepFromTrigger", _RepFromTrigger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UETListPairs", _UETListPairs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPicked", _QtyPicked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceHold", _InvoiceHold, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
