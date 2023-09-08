//PROJECT NAME: Finance
//CLASS NAME: GetVATTrxn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GetVATTrxn : IGetVATTrxn
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public GetVATTrxn(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) GetVATTrxnSp(string PeriodKey,
		string BoxNum,
		string TaxJur,
		int? TaxSystem = 1,
		string FilterSite = null)
		{
			VATPeriodKeyType _PeriodKey = PeriodKey;
			StringType _BoxNum = BoxNum;
			TaxJurType _TaxJur = TaxJur;
			TaxSystemType _TaxSystem = TaxSystem;
			SiteType _FilterSite = FilterSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetVATTrxnSp";
				
				appDB.AddCommandParameter(cmd, "PeriodKey", _PeriodKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BoxNum", _BoxNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxJur", _TaxJur, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxSystem", _TaxSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterSite", _FilterSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
