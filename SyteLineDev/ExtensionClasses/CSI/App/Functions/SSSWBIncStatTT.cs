﻿using CSI.Data;
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
    public class SSSWBIncStatTT : ISSSWBIncStatTT
    {
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;

		public SSSWBIncStatTT(IApplicationDB appDB,
			IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
			IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}

		public ICollectionLoadResponse SSSWBIncStatTTFn()
		{
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "Select * from dbo.[SSSWBIncStatTT]()";

				DataTable dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_SSSWBIncStatTT";
				this.dataTableUtil.CloneDataTableIntoDB(dtReturn);

				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
