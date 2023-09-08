//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLGetAllJobInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLGetAllJobInfo
	{
		(int? ReturnCode, byte? CoProdcutMix, decimal? JobOpReceivedQty, decimal? QtyScrapped, decimal? QtyCompleted, decimal? QtyMoved, string WC, string WCDesc, byte? IsLastOperation, byte? Complete, string LocDesc, int? NextOper, decimal? JobBalance, string Item, string ItemDesc, string UOM, string UOMDesc, string JobStat, decimal? JobQty, string Whse, string WhseDesc, byte? LotTrack, byte? PreassignLot, string LotPrefix, byte? SerialTrack, string RefJob, string Shift, string Overhead, string LotAttrGroup, string ProductCode, string SerialPrefix) FTSLGetAllJobInfoSp(string Job,
		short? Suffix,
		int? OperNum,
		string Loc,
		byte? ScrapConsider,
		string CallForm,
		short? TAImplement = 0,
		string Empum = null,
		byte? CoProdcutMix = null,
		decimal? JobOpReceivedQty = null,
		decimal? QtyScrapped = null,
		decimal? QtyCompleted = null,
		decimal? QtyMoved = null,
		string WC = null,
		string WCDesc = null,
		byte? IsLastOperation = null,
		byte? Complete = null,
		string LocDesc = null,
		int? NextOper = null,
		decimal? JobBalance = null,
		string Item = null,
		string ItemDesc = null,
		string UOM = null,
		string UOMDesc = null,
		string JobStat = null,
		decimal? JobQty = null,
		string Whse = null,
		string WhseDesc = null,
		byte? LotTrack = null,
		byte? PreassignLot = null,
		string LotPrefix = null,
		byte? SerialTrack = null,
		string RefJob = null,
		string Shift = null,
		string Overhead = null,
		string LotAttrGroup = null,
		string ProductCode = null,
		string SerialPrefix = null);
	}
	
	public class FTSLGetAllJobInfo : IFTSLGetAllJobInfo
	{
		readonly IApplicationDB appDB;
		
		public FTSLGetAllJobInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? CoProdcutMix, decimal? JobOpReceivedQty, decimal? QtyScrapped, decimal? QtyCompleted, decimal? QtyMoved, string WC, string WCDesc, byte? IsLastOperation, byte? Complete, string LocDesc, int? NextOper, decimal? JobBalance, string Item, string ItemDesc, string UOM, string UOMDesc, string JobStat, decimal? JobQty, string Whse, string WhseDesc, byte? LotTrack, byte? PreassignLot, string LotPrefix, byte? SerialTrack, string RefJob, string Shift, string Overhead, string LotAttrGroup, string ProductCode, string SerialPrefix) FTSLGetAllJobInfoSp(string Job,
		short? Suffix,
		int? OperNum,
		string Loc,
		byte? ScrapConsider,
		string CallForm,
		short? TAImplement = 0,
		string Empum = null,
		byte? CoProdcutMix = null,
		decimal? JobOpReceivedQty = null,
		decimal? QtyScrapped = null,
		decimal? QtyCompleted = null,
		decimal? QtyMoved = null,
		string WC = null,
		string WCDesc = null,
		byte? IsLastOperation = null,
		byte? Complete = null,
		string LocDesc = null,
		int? NextOper = null,
		decimal? JobBalance = null,
		string Item = null,
		string ItemDesc = null,
		string UOM = null,
		string UOMDesc = null,
		string JobStat = null,
		decimal? JobQty = null,
		string Whse = null,
		string WhseDesc = null,
		byte? LotTrack = null,
		byte? PreassignLot = null,
		string LotPrefix = null,
		byte? SerialTrack = null,
		string RefJob = null,
		string Shift = null,
		string Overhead = null,
		string LotAttrGroup = null,
		string ProductCode = null,
		string SerialPrefix = null)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			LocType _Loc = Loc;
			ListYesNoType _ScrapConsider = ScrapConsider;
			ContractType _CallForm = CallForm;
			SmallintType _TAImplement = TAImplement;
			EmpNumType _Empum = Empum;
			ListYesNoType _CoProdcutMix = CoProdcutMix;
			QtyUnitType _JobOpReceivedQty = JobOpReceivedQty;
			QtyUnitType _QtyScrapped = QtyScrapped;
			QtyUnitType _QtyCompleted = QtyCompleted;
			QtyUnitType _QtyMoved = QtyMoved;
			WcType _WC = WC;
			LongerDescType _WCDesc = WCDesc;
			ListYesNoType _IsLastOperation = IsLastOperation;
			ListYesNoType _Complete = Complete;
			LongerDescType _LocDesc = LocDesc;
			OperNumType _NextOper = NextOper;
			QtyUnitType _JobBalance = JobBalance;
			ItemType _Item = Item;
			LongerDescType _ItemDesc = ItemDesc;
			UMType _UOM = UOM;
			LongerDescType _UOMDesc = UOMDesc;
			LongerDescType _JobStat = JobStat;
			QtyUnitType _JobQty = JobQty;
			WhseType _Whse = Whse;
			LongerDescType _WhseDesc = WhseDesc;
			ListYesNoType _LotTrack = LotTrack;
			ListYesNoType _PreassignLot = PreassignLot;
			LotPrefixType _LotPrefix = LotPrefix;
			ListYesNoType _SerialTrack = SerialTrack;
			JobType _RefJob = RefJob;
			ShiftType _Shift = Shift;
			OverheadBasisType _Overhead = Overhead;
			AttributeGroupType _LotAttrGroup = LotAttrGroup;
			ProductCodeType _ProductCode = ProductCode;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLGetAllJobInfoSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScrapConsider", _ScrapConsider, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallForm", _CallForm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAImplement", _TAImplement, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Empum", _Empum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoProdcutMix", _CoProdcutMix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobOpReceivedQty", _JobOpReceivedQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyScrapped", _QtyScrapped, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyCompleted", _QtyCompleted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyMoved", _QtyMoved, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WC", _WC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WCDesc", _WCDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsLastOperation", _IsLastOperation, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Complete", _Complete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LocDesc", _LocDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NextOper", _NextOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobBalance", _JobBalance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UOM", _UOM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UOMDesc", _UOMDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobStat", _JobStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobQty", _JobQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WhseDesc", _WhseDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTrack", _LotTrack, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignLot", _PreassignLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotPrefix", _LotPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTrack", _SerialTrack, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefJob", _RefJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Shift", _Shift, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Overhead", _Overhead, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotAttrGroup", _LotAttrGroup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoProdcutMix = _CoProdcutMix;
				JobOpReceivedQty = _JobOpReceivedQty;
				QtyScrapped = _QtyScrapped;
				QtyCompleted = _QtyCompleted;
				QtyMoved = _QtyMoved;
				WC = _WC;
				WCDesc = _WCDesc;
				IsLastOperation = _IsLastOperation;
				Complete = _Complete;
				LocDesc = _LocDesc;
				NextOper = _NextOper;
				JobBalance = _JobBalance;
				Item = _Item;
				ItemDesc = _ItemDesc;
				UOM = _UOM;
				UOMDesc = _UOMDesc;
				JobStat = _JobStat;
				JobQty = _JobQty;
				Whse = _Whse;
				WhseDesc = _WhseDesc;
				LotTrack = _LotTrack;
				PreassignLot = _PreassignLot;
				LotPrefix = _LotPrefix;
				SerialTrack = _SerialTrack;
				RefJob = _RefJob;
				Shift = _Shift;
				Overhead = _Overhead;
				LotAttrGroup = _LotAttrGroup;
				ProductCode = _ProductCode;
				SerialPrefix = _SerialPrefix;
				
				return (Severity, CoProdcutMix, JobOpReceivedQty, QtyScrapped, QtyCompleted, QtyMoved, WC, WCDesc, IsLastOperation, Complete, LocDesc, NextOper, JobBalance, Item, ItemDesc, UOM, UOMDesc, JobStat, JobQty, Whse, WhseDesc, LotTrack, PreassignLot, LotPrefix, SerialTrack, RefJob, Shift, Overhead, LotAttrGroup, ProductCode, SerialPrefix);
			}
		}
	}
}
