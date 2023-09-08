//PROJECT NAME: CSIDataCollection
//CLASS NAME: DctsSerialLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IDctsSerialLoad
	{
		DataTable DctsSerialLoadSp(byte? GenSer,
		                           int? TransNum,
		                           decimal? QtyShipped,
		                           string FromLoc,
		                           string FromLot,
		                           string ToLot,
		                           string TrnNum,
		                           short? TrnLine,
		                           string StartSerNum);
	}
	
	public class DctsSerialLoad : IDctsSerialLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public DctsSerialLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable DctsSerialLoadSp(byte? GenSer,
		                                  int? TransNum,
		                                  decimal? QtyShipped,
		                                  string FromLoc,
		                                  string FromLot,
		                                  string ToLot,
		                                  string TrnNum,
		                                  short? TrnLine,
		                                  string StartSerNum)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ListYesNoType _GenSer = GenSer;
				DcTransNumType _TransNum = TransNum;
				QtyUnitType _QtyShipped = QtyShipped;
				LocType _FromLoc = FromLoc;
				LotType _FromLot = FromLot;
				LotType _ToLot = ToLot;
				TrnNumType _TrnNum = TrnNum;
				TrnLineType _TrnLine = TrnLine;
				SerNumType _StartSerNum = StartSerNum;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "DctsSerialLoadSp";
					
					appDB.AddCommandParameter(cmd, "GenSer", _GenSer, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FromLot", _FromLot, ParameterDirection.Input);
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
