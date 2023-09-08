//PROJECT NAME: Data
//CLASS NAME: APP_ExpandNumSortChar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class APP_ExpandNumSortChar : IAPP_ExpandNumSortChar
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public APP_ExpandNumSortChar(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode,
			string ExpandedValue) APP_ExpandNumSortCharSp(
			int? Length,
			string UnexpandedValue,
			string IDOName,
			string PropertyName,
			string ExpandedValue)
		{
			IntType _Length = Length;
			StringType _UnexpandedValue = UnexpandedValue;
			CollectionNameType _IDOName = IDOName;
			PropertyClassType _PropertyName = PropertyName;
			StringType _ExpandedValue = ExpandedValue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APP_ExpandNumSortCharSp";
				
				appDB.AddCommandParameter(cmd, "Length", _Length, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnexpandedValue", _UnexpandedValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IDOName", _IDOName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PropertyName", _PropertyName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpandedValue", _ExpandedValue, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				ExpandedValue = _ExpandedValue;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, ExpandedValue);
			}
		}
	}
}
