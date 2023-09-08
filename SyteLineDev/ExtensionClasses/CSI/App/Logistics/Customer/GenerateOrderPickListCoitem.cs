//PROJECT NAME: Logistics
//CLASS NAME: GenerateOrderPickListCoitem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateOrderPickListCoitem : IGenerateOrderPickListCoitem
	{
		readonly IApplicationDB appDB;
		
		public GenerateOrderPickListCoitem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			Guid? PItemlocRowPointer,
			string Infobar) GenerateOrderPickListCoitemSp(
			Guid? PSessionID,
			int? PCoparmsPickwarnCo,
			string PPickwarn,
			int? PPostMatlIssues,
			int? PProcessBatchId,
			int? PCoitemCoLine,
			string PCoitemCoNum,
			int? PCoitemCoRelease,
			string PCoitemItem,
			DateTime? PCoitemPickDate,
			decimal? PCoitemQtyOrdered,
			decimal? PCoitemQtyShipped,
			string PCoitemWhse,
			Guid? PCoitemRowPointer,
			int? PListByLoc,
			Guid? PItemlocRowPointer,
			string Infobar)
		{
			RowPointerType _PSessionID = PSessionID;
			ListYesNoType _PCoparmsPickwarnCo = PCoparmsPickwarnCo;
			StringType _PPickwarn = PPickwarn;
			ListYesNoType _PPostMatlIssues = PPostMatlIssues;
			BatchIdType _PProcessBatchId = PProcessBatchId;
			CoLineType _PCoitemCoLine = PCoitemCoLine;
			CoNumType _PCoitemCoNum = PCoitemCoNum;
			CoReleaseType _PCoitemCoRelease = PCoitemCoRelease;
			ItemType _PCoitemItem = PCoitemItem;
			DateType _PCoitemPickDate = PCoitemPickDate;
			QtyUnitType _PCoitemQtyOrdered = PCoitemQtyOrdered;
			QtyUnitType _PCoitemQtyShipped = PCoitemQtyShipped;
			WhseType _PCoitemWhse = PCoitemWhse;
			RowPointerType _PCoitemRowPointer = PCoitemRowPointer;
			ListYesNoType _PListByLoc = PListByLoc;
			RowPointerType _PItemlocRowPointer = PItemlocRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateOrderPickListCoitemSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoparmsPickwarnCo", _PCoparmsPickwarnCo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPickwarn", _PPickwarn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostMatlIssues", _PPostMatlIssues, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessBatchId", _PProcessBatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCoLine", _PCoitemCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCoNum", _PCoitemCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCoRelease", _PCoitemCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemItem", _PCoitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemPickDate", _PCoitemPickDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemQtyOrdered", _PCoitemQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemQtyShipped", _PCoitemQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemWhse", _PCoitemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemRowPointer", _PCoitemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PListByLoc", _PListByLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemlocRowPointer", _PItemlocRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PItemlocRowPointer = _PItemlocRowPointer;
				Infobar = _Infobar;
				
				return (Severity, PItemlocRowPointer, Infobar);
			}
		}
	}
}
