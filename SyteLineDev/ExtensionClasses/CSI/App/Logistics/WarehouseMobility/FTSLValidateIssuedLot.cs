//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateIssuedLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateIssuedLot
	{
		(int? ReturnCode, decimal? QtyOnHand, decimal? QtyRsvd, decimal? QtyContained, decimal? QtyAvailable, int? SLLotExp, string Infobar, string Uom) FTSLValidateIssuedLotSp(string Lot,
		string Item,
		string Whse,
		string Loc,
		decimal? QtyOnHand,
		decimal? QtyRsvd,
		decimal? QtyContained,
		decimal? QtyAvailable,
		int? SLLotExp,
		byte? SLAllowNegInvFlag,
		byte? FTAllowNegInvFlag,
		string Infobar,
		byte? FDALotTraceability = (byte)0,
		string Job = null,
		short? Suffix = null,
		short? Operation = null,
		string Uom = null);
	}
	
	public class FTSLValidateIssuedLot : IFTSLValidateIssuedLot
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateIssuedLot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? QtyOnHand, decimal? QtyRsvd, decimal? QtyContained, decimal? QtyAvailable, int? SLLotExp, string Infobar, string Uom) FTSLValidateIssuedLotSp(string Lot,
		string Item,
		string Whse,
		string Loc,
		decimal? QtyOnHand,
		decimal? QtyRsvd,
		decimal? QtyContained,
		decimal? QtyAvailable,
		int? SLLotExp,
		byte? SLAllowNegInvFlag,
		byte? FTAllowNegInvFlag,
		string Infobar,
		byte? FDALotTraceability = (byte)0,
		string Job = null,
		short? Suffix = null,
		short? Operation = null,
		string Uom = null)
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
			ListYesNoType _FDALotTraceability = FDALotTraceability;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumPoReleaseType _Operation = Operation;
			UMType _Uom = Uom;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateIssuedLotSp";
				
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
				appDB.AddCommandParameter(cmd, "FDALotTraceability", _FDALotTraceability, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Operation", _Operation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Uom", _Uom, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyOnHand = _QtyOnHand;
				QtyRsvd = _QtyRsvd;
				QtyContained = _QtyContained;
				QtyAvailable = _QtyAvailable;
				SLLotExp = _SLLotExp;
				Infobar = _Infobar;
				Uom = _Uom;
				
				return (Severity, QtyOnHand, QtyRsvd, QtyContained, QtyAvailable, SLLotExp, Infobar, Uom);
			}
		}
	}
}
