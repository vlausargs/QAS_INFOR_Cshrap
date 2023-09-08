//PROJECT NAME: CSIDataCollection
//CLASS NAME: DccoSerialLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IDccoSerialLoad
	{
		DataTable DccoSerialLoadSp(byte? GenSer,
		                           string StartSerNum,
		                           int? TransNum,
		                           string Item,
		                           string Whse,
		                           string Loc,
		                           string Lot,
		                           decimal? QtyShipped,
		                           decimal? QtyReturned,
		                           string CoNum,
		                           short? CoLine,
		                           short? CoRelease);
	}
	
	public class DccoSerialLoad : IDccoSerialLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public DccoSerialLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable DccoSerialLoadSp(byte? GenSer,
		                                  string StartSerNum,
		                                  int? TransNum,
		                                  string Item,
		                                  string Whse,
		                                  string Loc,
		                                  string Lot,
		                                  decimal? QtyShipped,
		                                  decimal? QtyReturned,
		                                  string CoNum,
		                                  short? CoLine,
		                                  short? CoRelease)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ListYesNoType _GenSer = GenSer;
				SerNumType _StartSerNum = StartSerNum;
				DcTransNumType _TransNum = TransNum;
				ItemType _Item = Item;
				WhseType _Whse = Whse;
				LocType _Loc = Loc;
				LotType _Lot = Lot;
				QtyUnitType _QtyShipped = QtyShipped;
				QtyUnitType _QtyReturned = QtyReturned;
				CoNumType _CoNum = CoNum;
				CoLineType _CoLine = CoLine;
				CoReleaseType _CoRelease = CoRelease;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "DccoSerialLoadSp";
					
					appDB.AddCommandParameter(cmd, "GenSer", _GenSer, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartSerNum", _StartSerNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "QtyReturned", _QtyReturned, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);

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
