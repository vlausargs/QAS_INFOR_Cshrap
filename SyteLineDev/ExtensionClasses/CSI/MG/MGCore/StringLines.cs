using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.Data.RecordSets;
using CSI.Data;

namespace CSI.MG.MGCore
{
	public class StringLines : IStringLines
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		IDataTableUtil dataTableUtil;

		public StringLines(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}

		public ICollectionLoadResponse StringLinesFn(string Lines,
		bool? IgnoreLeadingEmptyLine = true,
		string Indent = "",
		string Replace1 = "",
		string With1 = "",
		string Replace2 = "",
		string With2 = "",
		string Replace3 = "",
		string With3 = "")
		{
			StringType _Lines = Lines;
			BooleanType _IgnoreLeadingEmptyLine = IgnoreLeadingEmptyLine;
			StringType _Indent = Indent;
			StringType _Replace1 = Replace1;
			StringType _With1 = With1;
			StringType _Replace2 = Replace2;
			StringType _With2 = With2;
			StringType _Replace3 = Replace3;
			StringType _With3 = With3;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[StringLines](@Lines, @IgnoreLeadingEmptyLine, @Indent, @Replace1, @With1, @Replace2, @With2, @Replace3, @With3)";

				appDB.AddCommandParameter(cmd, "Lines", _Lines, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IgnoreLeadingEmptyLine", _IgnoreLeadingEmptyLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Indent", _Indent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Replace1", _Replace1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "With1", _With1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Replace2", _Replace2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "With2", _With2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Replace3", _Replace3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "With3", _With3, ParameterDirection.Input);

				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_StringLines";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);

				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
