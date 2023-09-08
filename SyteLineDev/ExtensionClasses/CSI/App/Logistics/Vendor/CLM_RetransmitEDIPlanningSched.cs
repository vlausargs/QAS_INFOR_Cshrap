//PROJECT NAME: Logistics
//CLASS NAME: RetransmitEDIPlanningSched.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface ICLM_RetransmitEDIPlanningSched
    {
        (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) RetransmitEDIPlanningSchedSp(string VendorStarting = null,
                                                                                                     string VendorEnding = null,
                                                                                                     int? SchedNumStarting = null,
                                                                                                     int? SchedNumEnding = null,
                                                                                                     DateTime? CDateStarting = null,
                                                                                                     DateTime? CDateEnding = null,
                                                                                                     short? CDateStartingOffset = null,
                                                                                                     short? CDateEndingOffset = null,
                                                                                                     byte? ProcessFlag = (byte)1,
                                                                                                     string Infobar = null);
    }

    public class CLM_RetransmitEDIPlanningSched : ICLM_RetransmitEDIPlanningSched
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public CLM_RetransmitEDIPlanningSched(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) RetransmitEDIPlanningSchedSp(string VendorStarting = null,
                                                                                                            string VendorEnding = null,
                                                                                                            int? SchedNumStarting = null,
                                                                                                            int? SchedNumEnding = null,
                                                                                                            DateTime? CDateStarting = null,
                                                                                                            DateTime? CDateEnding = null,
                                                                                                            short? CDateStartingOffset = null,
                                                                                                            short? CDateEndingOffset = null,
                                                                                                            byte? ProcessFlag = (byte)1,
                                                                                                            string Infobar = null)
        {
            VendNumType _VendorStarting = VendorStarting;
            VendNumType _VendorEnding = VendorEnding;
            EdiSchedNumType _SchedNumStarting = SchedNumStarting;
            EdiSchedNumType _SchedNumEnding = SchedNumEnding;
            DateType _CDateStarting = CDateStarting;
            DateType _CDateEnding = CDateEnding;
            DateOffsetType _CDateStartingOffset = CDateStartingOffset;
            DateOffsetType _CDateEndingOffset = CDateEndingOffset;
            ListYesNoType _ProcessFlag = ProcessFlag;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RetransmitEDIPlanningSchedSp";

                appDB.AddCommandParameter(cmd, "VendorStarting", _VendorStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VendorEnding", _VendorEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchedNumStarting", _SchedNumStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchedNumEnding", _SchedNumEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CDateStarting", _CDateStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CDateEnding", _CDateEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CDateStartingOffset", _CDateStartingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CDateEndingOffset", _CDateEndingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProcessFlag", _ProcessFlag, ParameterDirection.Input);
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
