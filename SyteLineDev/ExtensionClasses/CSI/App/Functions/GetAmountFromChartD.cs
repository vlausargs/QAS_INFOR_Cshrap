//PROJECT NAME: Data
//CLASS NAME: GetAmountFromChartD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetAmountFromChartD : IGetAmountFromChartD
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public GetAmountFromChartD(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) GetAmountFromChartDSp(
			DateTime? PDate,
			decimal? PDomAmount,
			string PAcct,
			int? PDomCurrencyPlaces,
			decimal? PForDAmount)
		{
			DateType _PDate = PDate;
			AmountType _PDomAmount = PDomAmount;
			AcctType _PAcct = PAcct;
			DecimalPlacesType _PDomCurrencyPlaces = PDomCurrencyPlaces;
			AmountType _PForDAmount = PForDAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAmountFromChartDSp";
				
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomAmount", _PDomAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomCurrencyPlaces", _PDomCurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForDAmount", _PForDAmount, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
