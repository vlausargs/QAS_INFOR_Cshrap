//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXShipLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXShipLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) SSSRMXShipLoadSp(string VendNum,
		byte? Reverse,
		string Infobar,
		string FilterString = null);
	}
	
	public class SSSRMXShipLoad : ISSSRMXShipLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSRMXShipLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) SSSRMXShipLoadSp(string VendNum,
		byte? Reverse,
		string Infobar,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				VendNumType _VendNum = VendNum;
				ListYesNoType _Reverse = Reverse;
				Infobar _Infobar = Infobar;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SSSRMXShipLoadSp";
					
					appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Reverse", _Reverse, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    Infobar = _Infobar;
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
