//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcjrSerialLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IDcjrSerialLoad
	{
		DataTable DcjrSerialLoadSp(byte? GenSer,
		                           string TransType,
		                           decimal? GenQty,
		                           string SerialPrefix,
		                           string SerialLike,
		                           int? TransNum);
	}
	
	public class DcjrSerialLoad : IDcjrSerialLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public DcjrSerialLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable DcjrSerialLoadSp(byte? GenSer,
		                                  string TransType,
		                                  decimal? GenQty,
		                                  string SerialPrefix,
		                                  string SerialLike,
		                                  int? TransNum)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ListYesNoType _GenSer = GenSer;
				DcTransTypeType _TransType = TransType;
				QtyUnitType _GenQty = GenQty;
				SerialPrefixType _SerialPrefix = SerialPrefix;
				StringType _SerialLike = SerialLike;
				DcTransNumType _TransNum = TransNum;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "DcjrSerialLoadSp";
					
					appDB.AddCommandParameter(cmd, "GenSer", _GenSer, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "GenQty", _GenQty, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SerialLike", _SerialLike, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return dtReturn;
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
