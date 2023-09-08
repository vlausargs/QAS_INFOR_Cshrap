//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedDispatchPartnerLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedDispatchPartnerLoad : ISSSFSSchedDispatchPartnerLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSSchedDispatchPartnerLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSSchedDispatchPartnerLoadSp(string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		int? RefSeq,
		Guid? RefRowPointer,
		DateTime? RequestDate,
		int? DaysToLookAhead,
		decimal? ApptHrs,
		string FilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				FSRefTypeJKNSType _RefType = RefType;
				FSRefNumType _RefNum = RefNum;
				FSRefLineType _RefLineSuf = RefLineSuf;
				FSRefReleaseType _RefRelease = RefRelease;
				FSRefSeqType _RefSeq = RefSeq;
				RowPointerType _RefRowPointer = RefRowPointer;
				DateType _RequestDate = RequestDate;
				IntType _DaysToLookAhead = DaysToLookAhead;
				HoursOffType _ApptHrs = ApptHrs;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SSSFSSchedDispatchPartnerLoadSp";
					
					appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RefSeq", _RefSeq, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RequestDate", _RequestDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "DaysToLookAhead", _DaysToLookAhead, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ApptHrs", _ApptHrs, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
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
