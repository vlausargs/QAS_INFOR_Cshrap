//PROJECT NAME: Logistics
//CLASS NAME: CoitemUpdLcr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoitemUpdLcr : ICoitemUpdLcr
	{
		readonly IApplicationDB appDB;
		
		public CoitemUpdLcr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CoitemUpdLcrSp(
			string PCoNum,
			int? CoLine,
			int? CoRelease,
			decimal? ItemPrice,
			decimal? ItemDisc,
			decimal? QtyOrdered,
			decimal? QtyInvoiced,
			decimal? QtyReturned,
			decimal? QtyShipped,
			string CoItem,
			string CoitemTaxCode1,
			string CoitemTaxCode2,
			string ShipSite,
			int? PAddAccum,
			DateTime? PDueDate,
			string Infobar)
		{
			CoNumType _PCoNum = PCoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			AmountType _ItemPrice = ItemPrice;
			AmountType _ItemDisc = ItemDisc;
			QtyUnitType _QtyOrdered = QtyOrdered;
			QtyUnitType _QtyInvoiced = QtyInvoiced;
			QtyUnitType _QtyReturned = QtyReturned;
			QtyUnitType _QtyShipped = QtyShipped;
			ItemType _CoItem = CoItem;
			TaxCodeType _CoitemTaxCode1 = CoitemTaxCode1;
			TaxCodeType _CoitemTaxCode2 = CoitemTaxCode2;
			SiteType _ShipSite = ShipSite;
			FlagNyType _PAddAccum = PAddAccum;
			DateType _PDueDate = PDueDate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoitemUpdLcrSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPrice", _ItemPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDisc", _ItemDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyInvoiced", _QtyInvoiced, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReturned", _QtyReturned, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItem", _CoItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemTaxCode1", _CoitemTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemTaxCode2", _CoitemTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAddAccum", _PAddAccum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
