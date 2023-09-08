//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TransferOrderKitPickList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_TransferOrderKitPickList : IRpt_TransferOrderKitPickList
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_TransferOrderKitPickList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_TransferOrderKitPickListSP(string StartingTrnNum = null,
		string EndingTrnNum = null,
		int? StartingLineNum = null,
		int? EndingLineNum = null,
		string StartingKit = null,
		string EndingKit = null,
		int? SortByLoc = null,
		int? PrintSecondaryLocations = null,
		int? ExtendByScrapFactor = null,
		int? PrintBarCode = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			TrnNumType _StartingTrnNum = StartingTrnNum;
			TrnNumType _EndingTrnNum = EndingTrnNum;
			GenericIntType _StartingLineNum = StartingLineNum;
			GenericIntType _EndingLineNum = EndingLineNum;
			ItemType _StartingKit = StartingKit;
			ItemType _EndingKit = EndingKit;
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
				cmd.CommandText = "Rpt_TransferOrderKitPickListSP";
				
				appDB.AddCommandParameter(cmd, "StartingTrnNum", _StartingTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTrnNum", _EndingTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingLineNum", _StartingLineNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingLineNum", _EndingLineNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingKit", _StartingKit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingKit", _EndingKit, ParameterDirection.Input);
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
