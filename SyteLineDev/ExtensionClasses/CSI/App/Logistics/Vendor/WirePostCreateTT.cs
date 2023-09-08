//PROJECT NAME: Logistics
//CLASS NAME: WirePostCreateTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class WirePostCreateTT : IWirePostCreateTT
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public WirePostCreateTT(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) WirePostCreateTTSp(string PBegVendNum,
		string PEndVendNum,
		string PBegName,
		string PEndName,
		string PBankCode,
		string PAppmtPayType,
		DateTime? PPayDateStarting,
		DateTime? PPayDateEnding,
		Guid? PSessionID,
		string PSortNameNum = "Number")
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				VendNumType _PBegVendNum = PBegVendNum;
				VendNumType _PEndVendNum = PEndVendNum;
				NameType _PBegName = PBegName;
				NameType _PEndName = PEndName;
				BankCodeType _PBankCode = PBankCode;
				AppmtPayTypeType _PAppmtPayType = PAppmtPayType;
				DateType _PPayDateStarting = PPayDateStarting;
				DateType _PPayDateEnding = PPayDateEnding;
				RowPointer _PSessionID = PSessionID;
				LongDescType _PSortNameNum = PSortNameNum;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "WirePostCreateTTSp";
					
					appDB.AddCommandParameter(cmd, "PBegVendNum", _PBegVendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndVendNum", _PEndVendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PBegName", _PBegName, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndName", _PEndName, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PAppmtPayType", _PAppmtPayType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PPayDateStarting", _PPayDateStarting, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PPayDateEnding", _PPayDateEnding, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PSortNameNum", _PSortNameNum, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
