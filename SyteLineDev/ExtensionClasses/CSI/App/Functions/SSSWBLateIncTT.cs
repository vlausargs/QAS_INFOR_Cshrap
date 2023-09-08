using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Functions
{
    public class SSSWBLateIncTT : ISSSWBLateIncTT
    {
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;

		public SSSWBLateIncTT(IApplicationDB appDB,
			IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
			IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}

        public ICollectionLoadResponse SSSWBLateIncTTFn()
        {
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "Select * from dbo.[SSSWBLateIncTT]()";

				DataTable dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_SSSWBLateIncTT";
				this.dataTableUtil.CloneDataTableIntoDB(dtReturn);

				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
    }
}
