//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetPortalCoShippingMethods.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_GetPortalCoShippingMethods : ICLM_GetPortalCoShippingMethods
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GetPortalCoShippingMethods(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_GetPortalCoShippingMethodsSp(string CoNum,
		string CoPaymentMethod,
		int? LocaleID,
		string Filter)
		{
			CoNumType _CoNum = CoNum;
			PaymentMethodType _CoPaymentMethod = CoPaymentMethod;
			GenericIntType _LocaleID = LocaleID;
			StringType _Filter = Filter;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_GetPortalCoShippingMethodsSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoPaymentMethod", _CoPaymentMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocaleID", _LocaleID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Filter", _Filter, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
