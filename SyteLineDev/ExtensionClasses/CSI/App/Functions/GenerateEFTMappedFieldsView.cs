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
    public class GenerateEFTMappedFieldsView : IGenerateEFTMappedFieldsView
    {
        readonly IApplicationDB appDB;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
        readonly IDataTableUtil dataTableUtil;

        public GenerateEFTMappedFieldsView(IApplicationDB appDB,
            IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
            IDataTableUtil dataTableUtil)
        {
            this.appDB = appDB;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
            this.dataTableUtil = dataTableUtil;
        }

        public ICollectionLoadResponse GenerateEFTMappedFieldsViewFn(string osLocationType)
        {
            OSLocationType _osLocationType = osLocationType;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from dbo.[GenerateEFTMappedFieldsView](@osLocationType)";

                appDB.AddCommandParameter(cmd, "osLocationType", _osLocationType, ParameterDirection.Input);

                DataTable dtReturn  = appDB.ExecuteQuery(cmd);
                dtReturn.TableName = "#fnt_GenerateEFTMappedFieldsView";
                this.dataTableUtil.CloneDataTableIntoDB(dtReturn);

                return dataTableToCollectionLoadResponse.Process(dtReturn);
            }
        }
    }
}
