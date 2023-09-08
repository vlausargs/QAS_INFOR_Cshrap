//PROJECT NAME: Logistics
//CLASS NAME: CoitemChgStat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoitemChgStat : ICoitemChgStat
	{
		readonly IApplicationDB appDB;
		
		public CoitemChgStat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			decimal? ItemwhseQtyAllocCo) CoitemChgStatSp(
			string PCoNum,
			int? PCoLine,
			int? PCoRelease,
			string POldWhse,
			decimal? POldQtyOrdered,
			decimal? POldQtyShipped,
			decimal? POldQtyOrderedConv,
			decimal? POldPriceConv,
			decimal? POldDisc,
			string POldUM,
			decimal? PCoDisc,
			int? PNewRecord,
			string POldStatus,
			string PNewStatus,
			string PNewItem,
			decimal? PNewQtyOrdered,
			string Infobar,
			string ParmsSite = null,
			int? BufferItemwhse = 0,
			decimal? ItemwhseQtyAllocCo = null)
		{
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			WhseType _POldWhse = POldWhse;
			QtyUnitNoNegType _POldQtyOrdered = POldQtyOrdered;
			QtyUnitNoNegType _POldQtyShipped = POldQtyShipped;
			QtyUnitNoNegType _POldQtyOrderedConv = POldQtyOrderedConv;
			CostPrcType _POldPriceConv = POldPriceConv;
			LineDiscType _POldDisc = POldDisc;
			UMType _POldUM = POldUM;
			OrderDiscType _PCoDisc = PCoDisc;
			FlagNyType _PNewRecord = PNewRecord;
			CoitemStatusType _POldStatus = POldStatus;
			CoitemStatusType _PNewStatus = PNewStatus;
			ItemType _PNewItem = PNewItem;
			QtyUnitNoNegType _PNewQtyOrdered = PNewQtyOrdered;
			InfobarType _Infobar = Infobar;
			SiteType _ParmsSite = ParmsSite;
			ListYesNoType _BufferItemwhse = BufferItemwhse;
			QtyTotlType _ItemwhseQtyAllocCo = ItemwhseQtyAllocCo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoitemChgStatSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldWhse", _POldWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldQtyOrdered", _POldQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldQtyShipped", _POldQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldQtyOrderedConv", _POldQtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldPriceConv", _POldPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldDisc", _POldDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldUM", _POldUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoDisc", _PCoDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewRecord", _PNewRecord, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldStatus", _POldStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewStatus", _PNewStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewItem", _PNewItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewQtyOrdered", _PNewQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ParmsSite", _ParmsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BufferItemwhse", _BufferItemwhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemwhseQtyAllocCo", _ItemwhseQtyAllocCo, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				ItemwhseQtyAllocCo = _ItemwhseQtyAllocCo;
				
				return (Severity, Infobar, ItemwhseQtyAllocCo);
			}
		}
	}
}
