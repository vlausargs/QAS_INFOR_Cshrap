//PROJECT NAME: CSIDataCollection
//CLASS NAME: DctrSerialLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IDctrSerialLoad
	{
		DataTable DctrSerialLoadSp(byte? GenSer,
		                           string TransType,
		                           decimal? GenQty,
		                           string SerialPrefix,
		                           int? TransNum,
		                           decimal? QtyReceived,
		                           string FromLot,
		                           string ToLoc,
		                           string ToLot,
		                           string TrnNum,
		                           short? TrnLine,
		                           string StartSerNum);
	}
	
	public class DctrSerialLoad : IDctrSerialLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public DctrSerialLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable DctrSerialLoadSp(byte? GenSer,
		                                  string TransType,
		                                  decimal? GenQty,
		                                  string SerialPrefix,
		                                  int? TransNum,
		                                  decimal? QtyReceived,
		                                  string FromLot,
		                                  string ToLoc,
		                                  string ToLot,
		                                  string TrnNum,
		                                  short? TrnLine,
		                                  string StartSerNum)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ListYesNoType _GenSer = GenSer;
				DcTransTypeType _TransType = TransType;
				QtyUnitType _GenQty = GenQty;
				SerialPrefixType _SerialPrefix = SerialPrefix;
				DcTransNumType _TransNum = TransNum;
				QtyUnitType _QtyReceived = QtyReceived;
				LotType _FromLot = FromLot;
				LocType _ToLoc = ToLoc;
				LotType _ToLot = ToLot;
				TrnNumType _TrnNum = TrnNum;
				TrnLineType _TrnLine = TrnLine;
				SerNumType _StartSerNum = StartSerNum;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "DctrSerialLoadSp";
					
					appDB.AddCommandParameter(cmd, "GenSer", _GenSer, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "GenQty", _GenQty, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "QtyReceived", _QtyReceived, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FromLot", _FromLot, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ToLot", _ToLot, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartSerNum", _StartSerNum, ParameterDirection.Input);

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
