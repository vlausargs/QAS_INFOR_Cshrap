//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetCoShippingMethods.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_GetCoShippingMethods : ICLM_GetCoShippingMethods
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GetCoShippingMethods(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_GetCoShippingMethodsSp(string ShipMethod,
		string CoNum,
		string CoPaymentMethod,
		string LangCode)
		{
			ShipMethodType _ShipMethod = ShipMethod;
			CoNumType _CoNum = CoNum;
			PaymentMethodType _CoPaymentMethod = CoPaymentMethod;
			LangCodeType _LangCode = LangCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_GetCoShippingMethodsSp";
				
				appDB.AddCommandParameter(cmd, "ShipMethod", _ShipMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoPaymentMethod", _CoPaymentMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LangCode", _LangCode, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
