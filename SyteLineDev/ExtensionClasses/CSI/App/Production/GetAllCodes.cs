//PROJECT NAME: Production
//CLASS NAME: GetAllCodes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class GetAllCodes : IGetAllCodes
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

		public GetAllCodes(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) GetAllCodesSp(
			string Class1,
			string Class2 = null,
			string Class3 = null,
			string Class4 = null,
			string Class5 = null,
			string Class6 = null,
			string Class7 = null,
			string Class8 = null,
			string Class9 = null,
			string Class10 = null)
		{
			ComboClassType _Class1 = Class1;
			ComboClassType _Class2 = Class2;
			ComboClassType _Class3 = Class3;
			ComboClassType _Class4 = Class4;
			ComboClassType _Class5 = Class5;
			ComboClassType _Class6 = Class6;
			ComboClassType _Class7 = Class7;
			ComboClassType _Class8 = Class8;
			ComboClassType _Class9 = Class9;
			ComboClassType _Class10 = Class10;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAllCodesSp";

				appDB.AddCommandParameter(cmd, "Class1", _Class1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Class2", _Class2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Class3", _Class3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Class4", _Class4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Class5", _Class5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Class6", _Class6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Class7", _Class7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Class8", _Class8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Class9", _Class9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Class10", _Class10, ParameterDirection.Input);

				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

				dtReturn = appDB.ExecuteQuery(cmd);

				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
