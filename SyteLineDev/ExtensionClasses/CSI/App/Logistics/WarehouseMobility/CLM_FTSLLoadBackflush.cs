//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLLoadBackflush.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLLoadBackflush : ICLM_FTSLLoadBackflush
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_FTSLLoadBackflush(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_FTSLLoadBackflushSp(int? BackflushByLot,
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
		string ERPQueryJobMatResponseString = null,
		string ERPQueryJobSerResponseString = null,
		string Infobar = null)
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
			XMLStringType _ERPQueryJobMatResponseString = ERPQueryJobMatResponseString;
			XMLStringType _ERPQueryJobSerResponseString = ERPQueryJobSerResponseString;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_FTSLLoadBackflushSp";
				
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
				appDB.AddCommandParameter(cmd, "ERPQueryJobMatResponseString", _ERPQueryJobMatResponseString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ERPQueryJobSerResponseString", _ERPQueryJobSerResponseString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
