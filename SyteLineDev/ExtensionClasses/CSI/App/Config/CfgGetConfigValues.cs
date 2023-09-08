//PROJECT NAME: Data
//CLASS NAME: CfgGetConfigValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Config
{
    public class CfgGetConfigValues : ICfgGetConfigValues
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
        readonly IDataTableUtil dataTableUtil;

        public CfgGetConfigValues(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
            this.dataTableUtil = dataTableUtil;
        }

        public ICollectionLoadResponse CfgGetConfigValuesFn(
            string pConfigId,
            string pPrintFlag)
        {
            ConfigIdType _pConfigId = pConfigId;
            LongListType _pPrintFlag = pPrintFlag;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM dbo.[CfgGetConfigValues](@pConfigId, @pPrintFlag)";

                appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pPrintFlag", _pPrintFlag, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);
                dtReturn.TableName = "#fnt_CfgGetConfigValues";
                dataTableUtil.CloneDataTableIntoDB(dtReturn);

                return dataTableToCollectionLoadResponse.Process(dtReturn);
            }
        }
    }
}
