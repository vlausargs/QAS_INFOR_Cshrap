//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CustomerOrderKitPickList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_CustomerOrderKitPickList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CustomerOrderKitPickListSP(string StartingCoNum = null,
		string EndingCoNum = null,
		int? StartingLineNum = null,
		int? EndingLineNum = null,
		int? StartingRelNum = null,
		int? EndingRelNum = null,
		string StartingKit = null,
		string EndingKit = null,
		decimal? StartingPickListId = null,
		decimal? EndingPickListId = null,
		byte? ProcessPickList = null,
		byte? SortByLoc = null,
		byte? PrintSecondaryLocations = null,
		byte? ExtendByScrapFactor = null,
		byte? PrintBarCode = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_CustomerOrderKitPickList : IRpt_CustomerOrderKitPickList
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_CustomerOrderKitPickList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_CustomerOrderKitPickListSP(string StartingCoNum = null,
		string EndingCoNum = null,
		int? StartingLineNum = null,
		int? EndingLineNum = null,
		int? StartingRelNum = null,
		int? EndingRelNum = null,
		string StartingKit = null,
		string EndingKit = null,
		decimal? StartingPickListId = null,
		decimal? EndingPickListId = null,
		byte? ProcessPickList = null,
		byte? SortByLoc = null,
		byte? PrintSecondaryLocations = null,
		byte? ExtendByScrapFactor = null,
		byte? PrintBarCode = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			CoNumType _StartingCoNum = StartingCoNum;
			CoNumType _EndingCoNum = EndingCoNum;
			GenericIntType _StartingLineNum = StartingLineNum;
			GenericIntType _EndingLineNum = EndingLineNum;
			GenericIntType _StartingRelNum = StartingRelNum;
			GenericIntType _EndingRelNum = EndingRelNum;
			ItemType _StartingKit = StartingKit;
			ItemType _EndingKit = EndingKit;
			PickListIDType _StartingPickListId = StartingPickListId;
			PickListIDType _EndingPickListId = EndingPickListId;
			ListYesNoType _ProcessPickList = ProcessPickList;
			ListYesNoType _SortByLoc = SortByLoc;
			ListYesNoType _PrintSecondaryLocations = PrintSecondaryLocations;
			ListYesNoType _ExtendByScrapFactor = ExtendByScrapFactor;
			ListYesNoType _PrintBarCode = PrintBarCode;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_CustomerOrderKitPickListSP";
				
				appDB.AddCommandParameter(cmd, "StartingCoNum", _StartingCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCoNum", _EndingCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingLineNum", _StartingLineNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingLineNum", _EndingLineNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingRelNum", _StartingRelNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingRelNum", _EndingRelNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingKit", _StartingKit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingKit", _EndingKit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingPickListId", _StartingPickListId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPickListId", _EndingPickListId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessPickList", _ProcessPickList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortByLoc", _SortByLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSecondaryLocations", _PrintSecondaryLocations, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExtendByScrapFactor", _ExtendByScrapFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBarCode", _PrintBarCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
