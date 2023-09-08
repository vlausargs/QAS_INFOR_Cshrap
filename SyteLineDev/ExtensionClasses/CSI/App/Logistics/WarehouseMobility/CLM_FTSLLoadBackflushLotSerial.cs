//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLLoadBackflushLotSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLLoadBackflushLotSerial : ICLM_FTSLLoadBackflushLotSerial
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_FTSLLoadBackflushLotSerial(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar,
		int? BflushNeeded) CLM_FTSLLoadBackflushLotSerialSp(int? BackflushByLot,
		string TransClass,
		decimal? TransNum,
		string Job,
		int? Suffix,
		int? OperNum,
		string JobItem,
		decimal? PhantomMulti,
		string PhantomUnits,
		decimal? PhantomScrap,
		DateTime? TransDate,
		string Whse,
		string Lot,
		decimal? RouteQtyComplete,
		decimal? RouteQtyScrapped,
		string EmpNum,
		string Infobar,
		int? BflushNeeded = 0,
		int? ReverseQty = 0,
		int? FDALotTraceability = 0)
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
			ListYesNoType _BflushNeeded = BflushNeeded;
			ListYesNoType _ReverseQty = ReverseQty;
			ListYesNoType _FDALotTraceability = FDALotTraceability;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_FTSLLoadBackflushLotSerialSp";
				
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
				appDB.AddCommandParameter(cmd, "BflushNeeded", _BflushNeeded, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReverseQty", _ReverseQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FDALotTraceability", _FDALotTraceability, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				Infobar = _Infobar;
				BflushNeeded = _BflushNeeded;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar, BflushNeeded);
			}
		}
	}
}
