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

namespace CSI.BusInterface
{
    class GetESBReceivableTrackerMXLine : IGetESBReceivableTrackerMXLine
    {
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;

		public GetESBReceivableTrackerMXLine(IApplicationDB appDB,
			IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
			IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}

        public ICollectionLoadResponse GetESBReceivableTrackerMXLineFn()
        {
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.[GetESBReceivableTrackerMXLine]()";

                DataTable dtReturn  = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_GetESBReceivableTrackerMXLine";
				this.dataTableUtil.CloneDataTableIntoDB(dtReturn);

				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
    }
}
