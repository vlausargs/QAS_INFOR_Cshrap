//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobMaterialKitPickList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_JobMaterialKitPickList : IRpt_JobMaterialKitPickList
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_JobMaterialKitPickList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobMaterialKitPickListSP(string StartingJob = null,
		int? StartingSuffix = null,
		string EndingJob = null,
		int? EndingSuffix = null,
		int? StartingOperNum = null,
		int? EndingOperNum = null,
		string StartingKit = null,
		string EndingKit = null,
		int? SortByLoc = null,
		int? PrintSecondaryLocations = null,
		int? ExtendByScrapFactor = null,
		int? PrintBarCode = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			JobType _StartingJob = StartingJob;
			SuffixType _StartingSuffix = StartingSuffix;
			JobType _EndingJob = EndingJob;
			SuffixType _EndingSuffix = EndingSuffix;
			OperNumType _StartingOperNum = StartingOperNum;
			OperNumType _EndingOperNum = EndingOperNum;
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
				cmd.CommandText = "Rpt_JobMaterialKitPickListSP";
				
				appDB.AddCommandParameter(cmd, "StartingJob", _StartingJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingSuffix", _StartingSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingJob", _EndingJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingSuffix", _EndingSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingOperNum", _StartingOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOperNum", _EndingOperNum, ParameterDirection.Input);
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
