//PROJECT NAME: Data
//CLASS NAME: InvoiceBuilderCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InvoiceBuilderCopy : IInvoiceBuilderCopy
	{
		readonly IApplicationDB appDB;
		
		public InvoiceBuilderCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) InvoiceBuilderCopySp(
			Guid? PProcessId,
			string PToSite,
			int? PSelected = null,
			string PBuilderInvNum = null,
			string PBuilderInvOrigSite = null,
			string PCoNum = null,
			int? PCoLine = null,
			int? PCoRelease = null,
			Guid? PCoRowPointer = null,
			Guid? PCoitemRowPointer = null,
			decimal? PCost = null,
			string PCustNum = null,
			string PItem = null,
			string PItemDescription = null,
			string PUM = null,
			decimal? POrigQtyInvoice = null,
			decimal? PPrice = null,
			decimal? PQtyInvoice = null,
			decimal? PQtyOrdered = null,
			decimal? PQtyReturned = null,
			decimal? PQtyShipped = null,
			DateTime? PShipDate = null,
			string Infobar = null)
		{
			RowPointerType _PProcessId = PProcessId;
			SiteType _PToSite = PToSite;
			ListYesNoType _PSelected = PSelected;
			BuilderInvNumType _PBuilderInvNum = PBuilderInvNum;
			SiteType _PBuilderInvOrigSite = PBuilderInvOrigSite;
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			RowPointerType _PCoRowPointer = PCoRowPointer;
			RowPointerType _PCoitemRowPointer = PCoitemRowPointer;
			CostPrcType _PCost = PCost;
			CustNumType _PCustNum = PCustNum;
			ItemType _PItem = PItem;
			DescriptionType _PItemDescription = PItemDescription;
			UMType _PUM = PUM;
			QtyUnitNoNegType _POrigQtyInvoice = POrigQtyInvoice;
			CostPrcType _PPrice = PPrice;
			QtyUnitNoNegType _PQtyInvoice = PQtyInvoice;
			QtyUnitNoNegType _PQtyOrdered = PQtyOrdered;
			QtyUnitNoNegType _PQtyReturned = PQtyReturned;
			QtyUnitNoNegType _PQtyShipped = PQtyShipped;
			DateType _PShipDate = PShipDate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvoiceBuilderCopySp";
				
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToSite", _PToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSelected", _PSelected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBuilderInvNum", _PBuilderInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBuilderInvOrigSite", _PBuilderInvOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRowPointer", _PCoRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemRowPointer", _PCoitemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCost", _PCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemDescription", _PItemDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrigQtyInvoice", _POrigQtyInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrice", _PPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyInvoice", _PQtyInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyOrdered", _PQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyReturned", _PQtyReturned, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyShipped", _PQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShipDate", _PShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
