//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSearchRRLo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSSearchRRLo
    {
        (ICollectionLoadResponse Data, int? ReturnCode) SSSFSSearchRRLoad(int? MaxResults,
        string SearchOperator,
        string SearchString,
        int? SearchKbase,
        int? SearchIncDesc,
        int? SearchIncNotes,
        int? SearchIncReasons,
        int? SearchIncResolutions,
        int? SearchSRODesc,
        int? SearchSRONotes,
        int? SearchSROLines,
        int? SearchSROLineNotes,
        int? SearchSROOperations,
        int? SearchSROOperNotes,
        int? SearchSROReasons,
        int? SearchSROResolutions,
        DateTime? SearchStartDate,
        DateTime? SearchEndDate,
        string SearchSerNumRR,
        string FilterString = null);
    }

    public class SSSFSSearchRRLo : ISSSFSSearchRRLo
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public SSSFSSearchRRLo(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSSearchRRLoad(int? MaxResults,
        string SearchOperator,
        string SearchString,
        int? SearchKbase,
        int? SearchIncDesc,
        int? SearchIncNotes,
        int? SearchIncReasons,
        int? SearchIncResolutions,
        int? SearchSRODesc,
        int? SearchSRONotes,
        int? SearchSROLines,
        int? SearchSROLineNotes,
        int? SearchSROOperations,
        int? SearchSROOperNotes,
        int? SearchSROReasons,
        int? SearchSROResolutions,
        DateTime? SearchStartDate,
        DateTime? SearchEndDate,
        string SearchSerNumRR,
        string FilterString = null)
        {
            IntType _MaxResults = MaxResults;
            StringType _SearchOperator = SearchOperator;
            StringType _SearchString = SearchString;
            IntType _SearchKbase = SearchKbase;
            IntType _SearchIncDesc = SearchIncDesc;
            IntType _SearchIncNotes = SearchIncNotes;
            IntType _SearchIncReasons = SearchIncReasons;
            IntType _SearchIncResolutions = SearchIncResolutions;
            IntType _SearchSRODesc = SearchSRODesc;
            IntType _SearchSRONotes = SearchSRONotes;
            IntType _SearchSROLines = SearchSROLines;
            IntType _SearchSROLineNotes = SearchSROLineNotes;
            IntType _SearchSROOperations = SearchSROOperations;
            IntType _SearchSROOperNotes = SearchSROOperNotes;
            IntType _SearchSROReasons = SearchSROReasons;
            IntType _SearchSROResolutions = SearchSROResolutions;
            DateTimeType _SearchStartDate = SearchStartDate;
            DateTimeType _SearchEndDate = SearchEndDate;
            StringType _SearchSerNumRR = SearchSerNumRR;
            LongListType _FilterString = FilterString;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSSearchRRLoadSp";

                appDB.AddCommandParameter(cmd, "MaxResults", _MaxResults, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchOperator", _SearchOperator, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchString", _SearchString, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchKbase", _SearchKbase, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchIncDesc", _SearchIncDesc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchIncNotes", _SearchIncNotes, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchIncReasons", _SearchIncReasons, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchIncResolutions", _SearchIncResolutions, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchSRODesc", _SearchSRODesc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchSRONotes", _SearchSRONotes, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchSROLines", _SearchSROLines, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchSROLineNotes", _SearchSROLineNotes, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchSROOperations", _SearchSROOperations, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchSROOperNotes", _SearchSROOperNotes, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchSROReasons", _SearchSROReasons, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchSROResolutions", _SearchSROResolutions, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchStartDate", _SearchStartDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchEndDate", _SearchEndDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchSerNumRR", _SearchSerNumRR, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
            }
        }
    }
}
