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

namespace CSI.Material
{
    public class MRPSupDem : IMRPSupDem
    {
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;

		public MRPSupDem(IApplicationDB appDB,
			IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
			IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}

        public ICollectionLoadResponse MRPSupDemFn(int? DetailDisplay = 0, int? UseFullyTransactedOrders = 0, int? PExcludePLNs = 0)
        {
			ListYesNoType _DetailDisplay = DetailDisplay;
			ListYesNoType _UseFullyTransactedOrders = UseFullyTransactedOrders;
			ListYesNoType _PExcludePLNs = PExcludePLNs;

			using (IDbCommand cmd = appDB.CreateCommand())
            {
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "Select * from dbo.[MRPSupDem](@DetailDisplay, @UseFullyTransactedOrders, @PExcludePLNs)";

				appDB.AddCommandParameter(cmd, "DetailDisplay", _DetailDisplay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseFullyTransactedOrders", _UseFullyTransactedOrders, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExcludePLNs", _PExcludePLNs, ParameterDirection.Input);

				DataTable dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_MRPSupDem";
				this.dataTableUtil.CloneDataTableIntoDB(dtReturn);

				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}

		}
    }
}
