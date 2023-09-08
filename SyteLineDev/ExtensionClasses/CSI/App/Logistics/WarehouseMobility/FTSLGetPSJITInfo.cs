//PROJECT NAME: Logistics
//CLASS NAME: FTSLGetPSJITInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetPSJITInfo : IFTSLGetPSJITInfo
	{
		readonly IApplicationDB appDB;
		
		
		public FTSLGetPSJITInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ItemDescription,
		string ItemUM,
		int? ItemLotTracked,
		int? ItemSerialTracked,
		string WcDescription,
		string Whse,
		string Loc,
		decimal? QtyExpected,
		decimal? QtyCompleted,
		decimal? QtyScrapped,
		string SymixJob,
		int? IsLastOper,
		decimal? QtyRemaining,
		DateTime? DueDate,
		int? SymixSuffix) FTSLGetPSJITInfoSp(string Item,
		string PsNum,
		string Wc,
		int? OperNum,
		string ItemDescription,
		string ItemUM,
		int? ItemLotTracked,
		int? ItemSerialTracked,
		string WcDescription,
		string Whse,
		string Loc,
		decimal? QtyExpected,
		decimal? QtyCompleted,
		decimal? QtyScrapped,
		string SymixJob = null,
		int? IsLastOper = 0,
		decimal? QtyRemaining = null,
		DateTime? DueDate = null,
		int? SymixSuffix = 0)
		{
			ItemType _Item = Item;
			PsNumType _PsNum = PsNum;
			WcType _Wc = Wc;
			OperNumType _OperNum = OperNum;
			DescriptionType _ItemDescription = ItemDescription;
			UMType _ItemUM = ItemUM;
			ListYesNoType _ItemLotTracked = ItemLotTracked;
			ListYesNoType _ItemSerialTracked = ItemSerialTracked;
			DescriptionType _WcDescription = WcDescription;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			QtyTotlType _QtyExpected = QtyExpected;
			QtyTotlType _QtyCompleted = QtyCompleted;
			QtyTotlType _QtyScrapped = QtyScrapped;
			JobType _SymixJob = SymixJob;
			ListYesNoType _IsLastOper = IsLastOper;
			QtyTotlType _QtyRemaining = QtyRemaining;
			DateType _DueDate = DueDate;
			SuffixType _SymixSuffix = SymixSuffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLGetPSJITInfoSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsNum", _PsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemLotTracked", _ItemLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemSerialTracked", _ItemSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WcDescription", _WcDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyExpected", _QtyExpected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyCompleted", _QtyCompleted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyScrapped", _QtyScrapped, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SymixJob", _SymixJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsLastOper", _IsLastOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyRemaining", _QtyRemaining, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SymixSuffix", _SymixSuffix, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemDescription = _ItemDescription;
				ItemUM = _ItemUM;
				ItemLotTracked = _ItemLotTracked;
				ItemSerialTracked = _ItemSerialTracked;
				WcDescription = _WcDescription;
				Whse = _Whse;
				Loc = _Loc;
				QtyExpected = _QtyExpected;
				QtyCompleted = _QtyCompleted;
				QtyScrapped = _QtyScrapped;
				SymixJob = _SymixJob;
				IsLastOper = _IsLastOper;
				QtyRemaining = _QtyRemaining;
				DueDate = _DueDate;
				SymixSuffix = _SymixSuffix;
				
				return (Severity, ItemDescription, ItemUM, ItemLotTracked, ItemSerialTracked, WcDescription, Whse, Loc, QtyExpected, QtyCompleted, QtyScrapped, SymixJob, IsLastOper, QtyRemaining, DueDate, SymixSuffix);
			}
		}
	}
}
