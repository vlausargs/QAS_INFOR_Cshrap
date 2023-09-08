//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConfigSearchLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConfigSearchLoad : ISSSFSConfigSearchLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSConfigSearchLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSConfigSearchLoadSp(int? Current,
		string SerNum,
		string Item,
		string CustNum,
		string Search,
		int? UnitSer,
		int? UnitItem,
		int? UnitCustItem,
		int? UnitDesc,
		int? CompSer,
		int? CompItem,
		int? CompCustItem,
		int? CompDesc)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ListYesNoType _Current = Current;
				SerNumType _SerNum = SerNum;
				ItemType _Item = Item;
				CustNumType _CustNum = CustNum;
				DescriptionType _Search = Search;
				ListYesNoType _UnitSer = UnitSer;
				ListYesNoType _UnitItem = UnitItem;
				ListYesNoType _UnitCustItem = UnitCustItem;
				ListYesNoType _UnitDesc = UnitDesc;
				ListYesNoType _CompSer = CompSer;
				ListYesNoType _CompItem = CompItem;
				ListYesNoType _CompCustItem = CompCustItem;
				ListYesNoType _CompDesc = CompDesc;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SSSFSConfigSearchLoadSp";
					
					appDB.AddCommandParameter(cmd, "Current", _Current, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Search", _Search, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "UnitSer", _UnitSer, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "UnitItem", _UnitItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "UnitCustItem", _UnitCustItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "UnitDesc", _UnitDesc, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CompSer", _CompSer, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CompItem", _CompItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CompCustItem", _CompCustItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CompDesc", _CompDesc, ParameterDirection.Input);
					
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
