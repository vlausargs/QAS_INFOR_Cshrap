using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data;

namespace CSI.MG.MGCore
{
	public class SplitString : ISplitString
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		IDataTableUtil dataTableUtil;

		public SplitString(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}

		public ICollectionLoadResponse SplitStringFn(string Delimiter,
		string List)
		{
			StringType _Delimiter = Delimiter;
			StringType _List = List;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[SplitString](@Delimiter, @List)";

				appDB.AddCommandParameter(cmd, "Delimiter", _Delimiter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "List", _List, ParameterDirection.Input);

				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_SplitString";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);

				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
