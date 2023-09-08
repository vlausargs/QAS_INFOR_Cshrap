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
	public class EventMessageChoices : IEventMessageChoices
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		IDataTableUtil dataTableUtil;

		public EventMessageChoices(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}

		public ICollectionLoadResponse EventMessageChoicesFn(string Choices)
		{
			MessageResponseChoicesType _Choices = Choices;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[EventMessageChoices](@Choices)";

				appDB.AddCommandParameter(cmd, "Choices", _Choices, ParameterDirection.Input);

				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_EventMessageChoices";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);

				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
