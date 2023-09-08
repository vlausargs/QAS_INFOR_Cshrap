//PROJECT NAME: Logistics
//CLASS NAME: CoitemCalcTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoitemCalcTax : ICoitemCalcTax
	{
		readonly IApplicationDB appDB;
		
		public CoitemCalcTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? CoSalesTax,
			decimal? CoSalesTax2,
			string Infobar) CoitemCalcTaxSp(
			string PCoNum,
			int? PCoLine,
			int? PCoRelease,
			string CoitemShipSite,
			string CoitemUM,
			string CoitemItem,
			decimal? CoitemPriceConv,
			decimal? CoitemPrice,
			decimal? CoitemQtyOrderedConv,
			decimal? CoitemQtyOrdered,
			decimal? CoitemDisc,
			decimal? CoitemQtyInvoiced,
			decimal? CoitemQtyShipped,
			decimal? CoitemPrgBillTot,
			decimal? CoitemPrgBillApp,
			string CoitemTaxCode1,
			string CoitemTaxCode2,
			decimal? CoSalesTax,
			decimal? CoSalesTax2,
			string Infobar)
		{
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			SiteType _CoitemShipSite = CoitemShipSite;
			UMType _CoitemUM = CoitemUM;
			ItemType _CoitemItem = CoitemItem;
			CostPrcType _CoitemPriceConv = CoitemPriceConv;
			CostPrcType _CoitemPrice = CoitemPrice;
			QtyUnitNoNegType _CoitemQtyOrderedConv = CoitemQtyOrderedConv;
			QtyUnitNoNegType _CoitemQtyOrdered = CoitemQtyOrdered;
			LineDiscType _CoitemDisc = CoitemDisc;
			QtyUnitNoNegType _CoitemQtyInvoiced = CoitemQtyInvoiced;
			QtyUnitNoNegType _CoitemQtyShipped = CoitemQtyShipped;
			AmountType _CoitemPrgBillTot = CoitemPrgBillTot;
			AmountType _CoitemPrgBillApp = CoitemPrgBillApp;
			TaxCodeType _CoitemTaxCode1 = CoitemTaxCode1;
			TaxCodeType _CoitemTaxCode2 = CoitemTaxCode2;
			AmountType _CoSalesTax = CoSalesTax;
			AmountType _CoSalesTax2 = CoSalesTax2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoitemCalcTaxSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemShipSite", _CoitemShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemUM", _CoitemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemItem", _CoitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemPriceConv", _CoitemPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemPrice", _CoitemPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemQtyOrderedConv", _CoitemQtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemQtyOrdered", _CoitemQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemDisc", _CoitemDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemQtyInvoiced", _CoitemQtyInvoiced, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemQtyShipped", _CoitemQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemPrgBillTot", _CoitemPrgBillTot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemPrgBillApp", _CoitemPrgBillApp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemTaxCode1", _CoitemTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemTaxCode2", _CoitemTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoSalesTax", _CoSalesTax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoSalesTax2", _CoSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoSalesTax = _CoSalesTax;
				CoSalesTax2 = _CoSalesTax2;
				Infobar = _Infobar;
				
				return (Severity, CoSalesTax, CoSalesTax2, Infobar);
			}
		}
	}
}
