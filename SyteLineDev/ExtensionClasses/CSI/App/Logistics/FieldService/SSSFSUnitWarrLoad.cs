//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitWarrLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitWarrLoad : ISSSFSUnitWarrLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSUnitWarrLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSUnitWarrLoadSp(string CustNum,
		string UsrNum,
		DateTime? IncDate = null,
		decimal? MeterAmt = null,
		string SerNum = null,
		string Item = null,
		int? CustSeq = null,
		int? UsrSeq = null,
		string Mode = null,
		string FilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				CustNumType _CustNum = CustNum;
				FSUsrNumType _UsrNum = UsrNum;
				DateType _IncDate = IncDate;
				AmountType _MeterAmt = MeterAmt;
				SerNumType _SerNum = SerNum;
				ItemType _Item = Item;
				CustSeqType _CustSeq = CustSeq;
				FSUsrSeqType _UsrSeq = UsrSeq;
				StringType _Mode = Mode;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SSSFSUnitWarrLoadSp";
					
					appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "UsrNum", _UsrNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "IncDate", _IncDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "MeterAmt", _MeterAmt, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
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
