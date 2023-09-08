//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContTmpLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContTmpLoad : ISSSFSContTmpLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSContTmpLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSContTmpLoadSp(string SerNum,
		string Item,
		string CustNum,
		DateTime? TestDate,
		int? InclBad,
		string UsrNum = null,
		int? CustSeq = null,
		int? UsrSeq = null,
		string Mode = null,
		string FilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				SerNumType _SerNum = SerNum;
				ItemType _Item = Item;
				CustNumType _CustNum = CustNum;
				DateType _TestDate = TestDate;
				ListYesNoType _InclBad = InclBad;
				FSUsrNumType _UsrNum = UsrNum;
				CustSeqType _CustSeq = CustSeq;
				FSUsrSeqType _UsrSeq = UsrSeq;
				StringType _Mode = Mode;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SSSFSContTmpLoadSp";
					
					appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TestDate", _TestDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "InclBad", _InclBad, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "UsrNum", _UsrNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "UsrSeq", _UsrSeq, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
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
