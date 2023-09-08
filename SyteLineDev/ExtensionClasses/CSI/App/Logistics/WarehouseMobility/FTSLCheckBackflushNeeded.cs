//PROJECT NAME: Logistics
//CLASS NAME: FTSLCheckBackflushNeeded.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLCheckBackflushNeeded : IFTSLCheckBackflushNeeded
	{
		readonly IApplicationDB appDB;
		
		
		public FTSLCheckBackflushNeeded(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar,
		int? BflushLotNeeded,
		int? BflushSerialNeeded) FTSLCheckBackflushNeededSp(int? BackflushByLot,
		string TransClass = "J",
		decimal? TransNum = null,
		string Job = null,
		int? Suffix = null,
		int? OperNum = null,
		string JobItem = null,
		decimal? PhantomMulti = null,
		string PhantomUnits = null,
		decimal? PhantomScrap = null,
		DateTime? TransDate = null,
		string Whse = null,
		string Lot = null,
		decimal? RouteQtyComplete = null,
		decimal? RouteQtyScrapped = null,
		string EmpNum = null,
		string Infobar = null,
		int? BflushLotNeeded = null,
		int? BflushSerialNeeded = null)
		{
			ListYesNoType _BackflushByLot = BackflushByLot;
			JobtranClassType _TransClass = TransClass;
			HugeTransNumType _TransNum = TransNum;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			ItemType _JobItem = JobItem;
			QtyPerType _PhantomMulti = PhantomMulti;
			LongListType _PhantomUnits = PhantomUnits;
			ScrapFactorType _PhantomScrap = PhantomScrap;
			CurrentDateType _TransDate = TransDate;
			WhseType _Whse = Whse;
			HighLowCharType _Lot = Lot;
			QtyUnitType _RouteQtyComplete = RouteQtyComplete;
			QtyUnitType _RouteQtyScrapped = RouteQtyScrapped;
			EmpNumType _EmpNum = EmpNum;
			InfobarType _Infobar = Infobar;
			ListYesNoType _BflushLotNeeded = BflushLotNeeded;
			ListYesNoType _BflushSerialNeeded = BflushSerialNeeded;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLCheckBackflushNeededSp";
				
				appDB.AddCommandParameter(cmd, "BackflushByLot", _BackflushByLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransClass", _TransClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobItem", _JobItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhantomMulti", _PhantomMulti, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhantomUnits", _PhantomUnits, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhantomScrap", _PhantomScrap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RouteQtyComplete", _RouteQtyComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RouteQtyScrapped", _RouteQtyScrapped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BflushLotNeeded", _BflushLotNeeded, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BflushSerialNeeded", _BflushSerialNeeded, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				BflushLotNeeded = _BflushLotNeeded;
				BflushSerialNeeded = _BflushSerialNeeded;
				
				return (Severity, Infobar, BflushLotNeeded, BflushSerialNeeded);
			}
		}
	}
}
