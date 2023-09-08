//PROJECT NAME: Data
//CLASS NAME: GetCoitemLinePrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetCoitemLinePrice : IGetCoitemLinePrice
	{
		readonly IApplicationDB appDB;
		
		public GetCoitemLinePrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? CoitemLinePrice,
			string Infobar,
			decimal? LineTaxAmount) GetCoitemLinePriceSp(
			string PCoNum,
			decimal? CoitemPrice,
			decimal? CoitemDisc,
			decimal? CoitemQtyOrdered,
			decimal? CoitemLbrCost,
			decimal? CoitemMatlCost,
			decimal? CoitemFovhdCost,
			decimal? CoitemVovhdCost,
			decimal? CoitemOutCost,
			decimal? CoitemQtyInvoiced,
			decimal? CoitemQtyShipped,
			decimal? CoitemPrgBillTot,
			decimal? CoitemPrgBillApp,
			int? CoitemCoLine,
			int? CoitemCoRelease,
			string CoitemItem,
			string CoitemTaxCode1,
			string CoitemTaxCode2,
			decimal? CoitemLinePrice,
			string Infobar,
			decimal? LineTaxAmount = null,
			Guid? CoitemRowPointer = null)
		{
			CoNumType _PCoNum = PCoNum;
			CostPrcType _CoitemPrice = CoitemPrice;
			LineDiscType _CoitemDisc = CoitemDisc;
			CostPrcType _CoitemQtyOrdered = CoitemQtyOrdered;
			CostPrcType _CoitemLbrCost = CoitemLbrCost;
			CostPrcType _CoitemMatlCost = CoitemMatlCost;
			CostPrcType _CoitemFovhdCost = CoitemFovhdCost;
			CostPrcType _CoitemVovhdCost = CoitemVovhdCost;
			CostPrcType _CoitemOutCost = CoitemOutCost;
			CostPrcType _CoitemQtyInvoiced = CoitemQtyInvoiced;
			CostPrcType _CoitemQtyShipped = CoitemQtyShipped;
			AmountType _CoitemPrgBillTot = CoitemPrgBillTot;
			AmountType _CoitemPrgBillApp = CoitemPrgBillApp;
			CoLineType _CoitemCoLine = CoitemCoLine;
			GenericIntType _CoitemCoRelease = CoitemCoRelease;
			ItemType _CoitemItem = CoitemItem;
			TaxCodeType _CoitemTaxCode1 = CoitemTaxCode1;
			TaxCodeType _CoitemTaxCode2 = CoitemTaxCode2;
			AmountType _CoitemLinePrice = CoitemLinePrice;
			InfobarType _Infobar = Infobar;
			AmtTotType _LineTaxAmount = LineTaxAmount;
			RowPointerType _CoitemRowPointer = CoitemRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCoitemLinePriceSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemPrice", _CoitemPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemDisc", _CoitemDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemQtyOrdered", _CoitemQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemLbrCost", _CoitemLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemMatlCost", _CoitemMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemFovhdCost", _CoitemFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemVovhdCost", _CoitemVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemOutCost", _CoitemOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemQtyInvoiced", _CoitemQtyInvoiced, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemQtyShipped", _CoitemQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemPrgBillTot", _CoitemPrgBillTot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemPrgBillApp", _CoitemPrgBillApp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemCoLine", _CoitemCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemCoRelease", _CoitemCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemItem", _CoitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemTaxCode1", _CoitemTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemTaxCode2", _CoitemTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemLinePrice", _CoitemLinePrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LineTaxAmount", _LineTaxAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoitemRowPointer", _CoitemRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoitemLinePrice = _CoitemLinePrice;
				Infobar = _Infobar;
				LineTaxAmount = _LineTaxAmount;
				
				return (Severity, CoitemLinePrice, Infobar, LineTaxAmount);
			}
		}
	}
}
