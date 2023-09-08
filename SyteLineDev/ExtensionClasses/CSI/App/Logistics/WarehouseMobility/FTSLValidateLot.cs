//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateLot
	{
		int FTSLValidateLotSp(string Lot,
		                      string Item,
		                      string Whse,
		                      string Loc,
		                      ref decimal? QtyOnHand,
		                      ref decimal? QtyRsvd,
		                      ref decimal? QtyContained,
		                      ref decimal? QtyAvailable,
		                      ref int? SLLotExp,
		                      byte? SLAllowNegInvFlag,
		                      byte? FTAllowNegInvFlag,
		                      ref string Infobar);
	}
	
	public class FTSLValidateLot : IFTSLValidateLot
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateLot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLValidateLotSp(string Lot,
		                             string Item,
		                             string Whse,
		                             string Loc,
		                             ref decimal? QtyOnHand,
		                             ref decimal? QtyRsvd,
		                             ref decimal? QtyContained,
		                             ref decimal? QtyAvailable,
		                             ref int? SLLotExp,
		                             byte? SLAllowNegInvFlag,
		                             byte? FTAllowNegInvFlag,
		                             ref string Infobar)
		{
			LotType _Lot = Lot;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			QtyUnitType _QtyOnHand = QtyOnHand;
			QtyUnitType _QtyRsvd = QtyRsvd;
			QtyUnitType _QtyContained = QtyContained;
			QtyUnitType _QtyAvailable = QtyAvailable;
			CustSeqType _SLLotExp = SLLotExp;
			ListYesNoType _SLAllowNegInvFlag = SLAllowNegInvFlag;
			ListYesNoType _FTAllowNegInvFlag = FTAllowNegInvFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateLotSp";
				
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyRsvd", _QtyRsvd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyContained", _QtyContained, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyAvailable", _QtyAvailable, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SLLotExp", _SLLotExp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SLAllowNegInvFlag", _SLAllowNegInvFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTAllowNegInvFlag", _FTAllowNegInvFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyOnHand = _QtyOnHand;
				QtyRsvd = _QtyRsvd;
				QtyContained = _QtyContained;
				QtyAvailable = _QtyAvailable;
				SLLotExp = _SLLotExp;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
