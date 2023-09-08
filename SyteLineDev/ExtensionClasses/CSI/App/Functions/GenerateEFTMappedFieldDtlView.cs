using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Functions
{
    public class GenerateEFTMappedFieldDtlView : IGenerateEFTMappedFieldDtlView
    {
        readonly IApplicationDB appDB;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
        readonly IDataTableUtil dataTableUtil;

        public GenerateEFTMappedFieldDtlView(IApplicationDB appDB,
            IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
            IDataTableUtil dataTableUtil)
        {
            this.appDB = appDB;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
            this.dataTableUtil = dataTableUtil;
        }

        public ICollectionLoadResponse GenerateEFTMappedFieldDtlViewFn(string osLocationType)
        {
            OSLocationType _osLocationType = osLocationType;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from dbo.[GenerateEFTMappedFieldDtlView](@osLocationType)";

                appDB.AddCommandParameter(cmd, "osLocationType", _osLocationType, ParameterDirection.Input);

                DataTable dtReturn = appDB.ExecuteQuery(cmd);
                dtReturn.TableName = "#fnt_GenerateEFTMappedFieldDtlView";
                this.dataTableUtil.CloneDataTableIntoDB(dtReturn);

                return dataTableToCollectionLoadResponse.Process(dtReturn);
            }
        }
    }
}
