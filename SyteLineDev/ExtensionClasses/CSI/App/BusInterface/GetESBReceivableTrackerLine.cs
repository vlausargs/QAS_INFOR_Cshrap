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
    public class GetESBReceivableTrackerLine : IGetESBReceivableTrackerLine
    {
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;

		public GetESBReceivableTrackerLine(IApplicationDB appDB,
			IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
			IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}

		public ICollectionLoadResponse GetESBReceivableTrackerLineFn()
        {
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "select * from dbo.[GetESBReceivableTrackerLine]()";

				DataTable dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_GetESBReceivableTrackerLine";
				this.dataTableUtil.CloneDataTableIntoDB(dtReturn);

				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
    }
}
