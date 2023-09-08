//PROJECT NAME: Logistics
//CLASS NAME: GenerateOrderPickListLisbylo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateOrderPickListLisbylo : IGenerateOrderPickListLisbylo
	{
		readonly IApplicationDB appDB;
		
		public GenerateOrderPickListLisbylo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			Guid? PItemlocRowPointer,
			string PItemlocLoc,
			Guid? PLotLocRowPointer,
			string PLotLocLot,
			string Infobar) GenerateOrderPickListLisbyloSp(
			string PCoitemWhse,
			string PCoitemItem,
			int? PItemLotTracked,
			string PItemIssueBy,
			Guid? PItemlocRowPointer,
			string PItemlocLoc,
			Guid? PLotLocRowPointer,
			string PLotLocLot,
			string Infobar)
		{
			WhseType _PCoitemWhse = PCoitemWhse;
			ItemType _PCoitemItem = PCoitemItem;
			ListYesNoType _PItemLotTracked = PItemLotTracked;
			ListLocLotType _PItemIssueBy = PItemIssueBy;
			RowPointerType _PItemlocRowPointer = PItemlocRowPointer;
			LocType _PItemlocLoc = PItemlocLoc;
			RowPointerType _PLotLocRowPointer = PLotLocRowPointer;
			LotType _PLotLocLot = PLotLocLot;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateOrderPickListLisbyloSp";
				
				appDB.AddCommandParameter(cmd, "PCoitemWhse", _PCoitemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemItem", _PCoitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemLotTracked", _PItemLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemIssueBy", _PItemIssueBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemlocRowPointer", _PItemlocRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemlocLoc", _PItemlocLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLotLocRowPointer", _PLotLocRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLotLocLot", _PLotLocLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PItemlocRowPointer = _PItemlocRowPointer;
				PItemlocLoc = _PItemlocLoc;
				PLotLocRowPointer = _PLotLocRowPointer;
				PLotLocLot = _PLotLocLot;
				Infobar = _Infobar;
				
				return (Severity, PItemlocRowPointer, PItemlocLoc, PLotLocRowPointer, PLotLocLot, Infobar);
			}
		}
	}
}
