//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBReceivableTrackerLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class CLM_ESBReceivableTrackerLine : ICLM_ESBReceivableTrackerLine
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ESBReceivableTrackerLine(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBReceivableTrackerLineSp(string CustomerPartyID,
		string Invoice,
		int? Sequence,
        string ArTranType,
        string BankCode,
        string ArpmtType)
		{
			CustNumType _CustomerPartyID = CustomerPartyID;
			InvNumType _Invoice = Invoice;
			InvSeqType _Sequence = Sequence;
            ArtranTypeType _ArTranType = ArTranType;
            BankCodeType _BankCode = BankCode;
            ArpmtTypeType _ArpmtType = ArpmtType;
            using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ESBReceivableTrackerLineSp";
				
				appDB.AddCommandParameter(cmd, "CustomerPartyID", _CustomerPartyID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Invoice", _Invoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ArTranType", _ArTranType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ArpmtType", _ArpmtType, ParameterDirection.Input);
                IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
