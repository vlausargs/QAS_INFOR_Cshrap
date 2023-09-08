//PROJECT NAME: Material
//CLASS NAME: CLM_LoadBackflush.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CLM_LoadBackflush : ICLM_LoadBackflush
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_LoadBackflush(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_LoadBackflushSp(int? BackflushByLot,
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
		int? NESTLEVEL = 0)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
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
				IntType _NESTLEVEL = NESTLEVEL;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_LoadBackflushSp";
					
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
					appDB.AddCommandParameter(cmd, "NESTLEVEL", _NESTLEVEL, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					Infobar = _Infobar;
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
