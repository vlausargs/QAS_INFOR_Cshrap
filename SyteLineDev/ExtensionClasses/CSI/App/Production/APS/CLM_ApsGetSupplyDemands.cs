//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetSupplyDemands.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CLM_ApsGetSupplyDemands : ICLM_ApsGetSupplyDemands
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ApsGetSupplyDemands(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetSupplyDemandsSp(string SupplyType,
		string Item,
		int? SupplyMatltag,
		int? ShowTopOnly,
		int? AltNo,
		string FilterString)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ApsOrderType _SupplyType = SupplyType;
				ItemType _Item = Item;
				ApsItemTagType _SupplyMatltag = SupplyMatltag;
				ListYesNoType _ShowTopOnly = ShowTopOnly;
				ApsAltNoType _AltNo = AltNo;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ApsGetSupplyDemandsSp";
					
					appDB.AddCommandParameter(cmd, "SupplyType", _SupplyType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SupplyMatltag", _SupplyMatltag, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ShowTopOnly", _ShowTopOnly, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
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
