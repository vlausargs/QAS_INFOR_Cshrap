//PROJECT NAME: CSIMaterial
//CLASS NAME: CLM_SerialsForTransactions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ICLM_SerialsForTransactions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_SerialsForTransactionsSp(string RefType,
		string RefNum,
		short? RefLineSuf,
		short? RefRelease,
		decimal? Count,
		byte? IsReturn = (byte)0,
		string Location = null);
	}
	
	public class CLM_SerialsForTransactions : ICLM_SerialsForTransactions
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_SerialsForTransactions(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_SerialsForTransactionsSp(string RefType,
		string RefNum,
		short? RefLineSuf,
		short? RefRelease,
		decimal? Count,
		byte? IsReturn = (byte)0,
		string Location = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				RefTypeJKOType _RefType = RefType;
				PoNumType _RefNum = RefNum;
				PoLineType _RefLineSuf = RefLineSuf;
				PoReleaseType _RefRelease = RefRelease;
				QtyUnitType _Count = Count;
				ListYesNoType _IsReturn = IsReturn;
				LocType _Location = Location;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_SerialsForTransactionsSp";
					
					appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Count", _Count, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "IsReturn", _IsReturn, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Location", _Location, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
