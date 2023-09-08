//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MaterialAvailability.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_MaterialAvailability : IRpt_MaterialAvailability
	{
		IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_MaterialAvailability(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_MaterialAvailabilitySp(string ExOptdfEst08Item = null,
		string ExOptdfEst08Job = null,
		int? ExOptdfEst08Suffix = null,
		string ExOptprPsNum = null,
		DateTime? ReleaseDueDate = null,
		decimal? ExOptdfEst08QtyReq = null,
		DateTime? ExOptdfEst08Date = null,
		int? ExOptacConsItemOh = null,
		int? ExOptszUseSafety = null,
		int? ExOptgoInclRelJobs = null,
		string TPsStat = null,
		int? ExOptgoInclOrdPo = null,
		int? ExOptszShowShortOnly = null,
		int? ExOptszSubFromOnhand = null,
		int? TDateSensitive = null,
		string ExOptdfEst08Whse = null,
		int? ExOptdfEst08DateOffset = null,
		int? DisplayHeader = null,
		string pSite = null,
		string BGUser = null)
		{
			ItemType _ExOptdfEst08Item = ExOptdfEst08Item;
			JobType _ExOptdfEst08Job = ExOptdfEst08Job;
			SuffixType _ExOptdfEst08Suffix = ExOptdfEst08Suffix;
			PsNumType _ExOptprPsNum = ExOptprPsNum;
			DateType _ReleaseDueDate = ReleaseDueDate;
			QtyUnitType _ExOptdfEst08QtyReq = ExOptdfEst08QtyReq;
			DateType _ExOptdfEst08Date = ExOptdfEst08Date;
			ListYesNoType _ExOptacConsItemOh = ExOptacConsItemOh;
			ListYesNoType _ExOptszUseSafety = ExOptszUseSafety;
			ListYesNoType _ExOptgoInclRelJobs = ExOptgoInclRelJobs;
			StringType _TPsStat = TPsStat;
			ListYesNoType _ExOptgoInclOrdPo = ExOptgoInclOrdPo;
			ListYesNoType _ExOptszShowShortOnly = ExOptszShowShortOnly;
			ListYesNoType _ExOptszSubFromOnhand = ExOptszSubFromOnhand;
			ListYesNoType _TDateSensitive = TDateSensitive;
			WhseType _ExOptdfEst08Whse = ExOptdfEst08Whse;
			DateOffsetType _ExOptdfEst08DateOffset = ExOptdfEst08DateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_MaterialAvailabilitySp";
				
				appDB.AddCommandParameter(cmd, "ExOptdfEst08Item", _ExOptdfEst08Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEst08Job", _ExOptdfEst08Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEst08Suffix", _ExOptdfEst08Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPsNum", _ExOptprPsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReleaseDueDate", _ReleaseDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEst08QtyReq", _ExOptdfEst08QtyReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEst08Date", _ExOptdfEst08Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacConsItemOh", _ExOptacConsItemOh, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszUseSafety", _ExOptszUseSafety, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptgoInclRelJobs", _ExOptgoInclRelJobs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPsStat", _TPsStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptgoInclOrdPo", _ExOptgoInclOrdPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszShowShortOnly", _ExOptszShowShortOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszSubFromOnhand", _ExOptszSubFromOnhand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDateSensitive", _TDateSensitive, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEst08Whse", _ExOptdfEst08Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEst08DateOffset", _ExOptdfEst08DateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
