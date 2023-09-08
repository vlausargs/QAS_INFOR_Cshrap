//PROJECT NAME: Logistics
//CLASS NAME: CoitemUpdateRemote.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoitemUpdateRemote : ICoitemUpdateRemote
	{
		readonly IApplicationDB appDB;
		
		public CoitemUpdateRemote(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CoitemUpdateRemoteSp(
			int? NewRecord,
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string CoType,
			int? CoStatusChanged,
			string CoCustNum,
			decimal? CoDisc,
			string CoitemWhse,
			string OldCoitemWhse,
			string CoitemUM,
			string OldCoitemUM,
			string CoitemItem,
			string OldCoitemItem,
			string CoitemStatus,
			string OldCoitemStatus,
			decimal? CoitemQtyOrdered,
			decimal? OldCoitemQtyOrdered,
			decimal? OldCoitemQtyShipped,
			decimal? CoitemQtyOrderedConv,
			decimal? OldCoitemQtyOrderedConv,
			decimal? OldCoitemQtyRsvd,
			decimal? CoitemPrice,
			decimal? OldCoitemPrice,
			decimal? OldCoitemPriceConv,
			decimal? CoitemDisc,
			decimal? OldCoitemDisc,
			string CoitemShipSite,
			string OldCoitemShipSite,
			string CoitemCoOrigSite,
			DateTime? CoitemDueDate,
			DateTime? OldCoitemDueDate,
			decimal? CoitemLbrCost,
			decimal? CoitemMatlCost,
			decimal? CoitemFovhdCost,
			decimal? CoitemVovhdCost,
			decimal? CoitemOutCost,
			string CoitemRefType,
			string OldCoitemRefType,
			string CoitemRefNum,
			string OldCoitemRefNum,
			int? CoitemRefLineSuf,
			int? OldCoitemRefLineSuf,
			int? CoitemRefRelease,
			int? OldCoitemRefRelease,
			string CoitemTaxCode1,
			string OldCoitemTaxCode1,
			string CoitemTaxCode2,
			string OldCoitemTaxCode2,
			string Infobar)
		{
			FlagNyType _NewRecord = NewRecord;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			CoTypeType _CoType = CoType;
			FlagNyType _CoStatusChanged = CoStatusChanged;
			CustNumType _CoCustNum = CoCustNum;
			OrderDiscType _CoDisc = CoDisc;
			WhseType _CoitemWhse = CoitemWhse;
			WhseType _OldCoitemWhse = OldCoitemWhse;
			UMType _CoitemUM = CoitemUM;
			UMType _OldCoitemUM = OldCoitemUM;
			ItemType _CoitemItem = CoitemItem;
			ItemType _OldCoitemItem = OldCoitemItem;
			CoitemStatusType _CoitemStatus = CoitemStatus;
			CoitemStatusType _OldCoitemStatus = OldCoitemStatus;
			QtyUnitNoNegType _CoitemQtyOrdered = CoitemQtyOrdered;
			QtyUnitNoNegType _OldCoitemQtyOrdered = OldCoitemQtyOrdered;
			QtyUnitNoNegType _OldCoitemQtyShipped = OldCoitemQtyShipped;
			QtyUnitNoNegType _CoitemQtyOrderedConv = CoitemQtyOrderedConv;
			QtyUnitNoNegType _OldCoitemQtyOrderedConv = OldCoitemQtyOrderedConv;
			QtyUnitType _OldCoitemQtyRsvd = OldCoitemQtyRsvd;
			AmountType _CoitemPrice = CoitemPrice;
			AmountType _OldCoitemPrice = OldCoitemPrice;
			CostPrcType _OldCoitemPriceConv = OldCoitemPriceConv;
			LineDiscType _CoitemDisc = CoitemDisc;
			LineDiscType _OldCoitemDisc = OldCoitemDisc;
			SiteType _CoitemShipSite = CoitemShipSite;
			SiteType _OldCoitemShipSite = OldCoitemShipSite;
			SiteType _CoitemCoOrigSite = CoitemCoOrigSite;
			DateType _CoitemDueDate = CoitemDueDate;
			DateType _OldCoitemDueDate = OldCoitemDueDate;
			CostPrcType _CoitemLbrCost = CoitemLbrCost;
			CostPrcType _CoitemMatlCost = CoitemMatlCost;
			CostPrcType _CoitemFovhdCost = CoitemFovhdCost;
			CostPrcType _CoitemVovhdCost = CoitemVovhdCost;
			CostPrcType _CoitemOutCost = CoitemOutCost;
			UnknownRefTypeType _CoitemRefType = CoitemRefType;
			UnknownRefTypeType _OldCoitemRefType = OldCoitemRefType;
			JobPoProjReqTrnNumType _CoitemRefNum = CoitemRefNum;
			JobPoProjReqTrnNumType _OldCoitemRefNum = OldCoitemRefNum;
			SuffixPoLineProjTaskReqTrnLineType _CoitemRefLineSuf = CoitemRefLineSuf;
			SuffixPoLineProjTaskReqTrnLineType _OldCoitemRefLineSuf = OldCoitemRefLineSuf;
			OperNumPoReleaseType _CoitemRefRelease = CoitemRefRelease;
			OperNumPoReleaseType _OldCoitemRefRelease = OldCoitemRefRelease;
			TaxCodeType _CoitemTaxCode1 = CoitemTaxCode1;
			TaxCodeType _OldCoitemTaxCode1 = OldCoitemTaxCode1;
			TaxCodeType _CoitemTaxCode2 = CoitemTaxCode2;
			TaxCodeType _OldCoitemTaxCode2 = OldCoitemTaxCode2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoitemUpdateRemoteSp";
				
				appDB.AddCommandParameter(cmd, "NewRecord", _NewRecord, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoType", _CoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoStatusChanged", _CoStatusChanged, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoCustNum", _CoCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoDisc", _CoDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemWhse", _CoitemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemWhse", _OldCoitemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemUM", _CoitemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemUM", _OldCoitemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemItem", _CoitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemItem", _OldCoitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemStatus", _CoitemStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemStatus", _OldCoitemStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemQtyOrdered", _CoitemQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemQtyOrdered", _OldCoitemQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemQtyShipped", _OldCoitemQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemQtyOrderedConv", _CoitemQtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemQtyOrderedConv", _OldCoitemQtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemQtyRsvd", _OldCoitemQtyRsvd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemPrice", _CoitemPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemPrice", _OldCoitemPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemPriceConv", _OldCoitemPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemDisc", _CoitemDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemDisc", _OldCoitemDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemShipSite", _CoitemShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemShipSite", _OldCoitemShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemCoOrigSite", _CoitemCoOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemDueDate", _CoitemDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemDueDate", _OldCoitemDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemLbrCost", _CoitemLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemMatlCost", _CoitemMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemFovhdCost", _CoitemFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemVovhdCost", _CoitemVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemOutCost", _CoitemOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemRefType", _CoitemRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemRefType", _OldCoitemRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemRefNum", _CoitemRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemRefNum", _OldCoitemRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemRefLineSuf", _CoitemRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemRefLineSuf", _OldCoitemRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemRefRelease", _CoitemRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemRefRelease", _OldCoitemRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemTaxCode1", _CoitemTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemTaxCode1", _OldCoitemTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemTaxCode2", _CoitemTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoitemTaxCode2", _OldCoitemTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
