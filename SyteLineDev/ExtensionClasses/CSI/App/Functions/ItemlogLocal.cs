//PROJECT NAME: Data
//CLASS NAME: ItemlogLocal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemlogLocal : IItemlogLocal
	{
		readonly IApplicationDB appDB;
		
		public ItemlogLocal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ItemlogLocalSp(
			string PCoNum,
			int? PCoLine,
			int? PCoRelease,
			string PItem,
			decimal? POldQty,
			decimal? PNewQty,
			decimal? POldPrice,
			decimal? PNewPrice,
			decimal? POldDisc,
			decimal? PNewDisc,
			decimal? POldCoDisc,
			decimal? PNewCoDisc,
			DateTime? POldDueDate,
			DateTime? PNewDueDate,
			DateTime? POldProjectedDate,
			DateTime? PNewProjectedDate,
			string PAction,
			decimal? PUomConvFactor,
			string POldUm,
			string PNewUm,
			string ShipSite,
			string Infobar)
		{
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			ItemType _PItem = PItem;
			QtyUnitNoNegType _POldQty = POldQty;
			QtyUnitNoNegType _PNewQty = PNewQty;
			CostPrcType _POldPrice = POldPrice;
			CostPrcType _PNewPrice = PNewPrice;
			LineDiscType _POldDisc = POldDisc;
			LineDiscType _PNewDisc = PNewDisc;
			OrderDiscType _POldCoDisc = POldCoDisc;
			OrderDiscType _PNewCoDisc = PNewCoDisc;
			DateType _POldDueDate = POldDueDate;
			DateType _PNewDueDate = PNewDueDate;
			DateType _POldProjectedDate = POldProjectedDate;
			DateType _PNewProjectedDate = PNewProjectedDate;
			LongListType _PAction = PAction;
			UMConvFactorType _PUomConvFactor = PUomConvFactor;
			UMType _POldUm = POldUm;
			UMType _PNewUm = PNewUm;
			SiteType _ShipSite = ShipSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemlogLocalSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldQty", _POldQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewQty", _PNewQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldPrice", _POldPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewPrice", _PNewPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldDisc", _POldDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewDisc", _PNewDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldCoDisc", _POldCoDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewCoDisc", _PNewCoDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldDueDate", _POldDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewDueDate", _PNewDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldProjectedDate", _POldProjectedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewProjectedDate", _PNewProjectedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAction", _PAction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUomConvFactor", _PUomConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldUm", _POldUm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewUm", _PNewUm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
