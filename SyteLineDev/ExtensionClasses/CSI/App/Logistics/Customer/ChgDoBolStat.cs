//PROJECT NAME: CSICustomer
//CLASS NAME: ChgDoBolStat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IChgDoBolStat
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ChgDoBolStatSp(string PText,
		string IOldDoStat,
		string INewDoStat,
		string SDoBolNum,
		string EDoBolNum,
		string SCustNum,
		string ECustNum,
		int? SShipToNum,
		int? EShipToNum,
		DateTime? SPickupDate,
		DateTime? EPickupDate,
		string Infobar,
		short? StartingPickupDateOffset = null,
		short? EndingPickupDateOffset = null);
	}
	
	public class ChgDoBolStat : IChgDoBolStat
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ChgDoBolStat(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ChgDoBolStatSp(string PText,
		string IOldDoStat,
		string INewDoStat,
		string SDoBolNum,
		string EDoBolNum,
		string SCustNum,
		string ECustNum,
		int? SShipToNum,
		int? EShipToNum,
		DateTime? SPickupDate,
		DateTime? EPickupDate,
		string Infobar,
		short? StartingPickupDateOffset = null,
		short? EndingPickupDateOffset = null)
		{
			LongListType _PText = PText;
			DoStatusType _IOldDoStat = IOldDoStat;
			DoStatusType _INewDoStat = INewDoStat;
			DoNumType _SDoBolNum = SDoBolNum;
			DoNumType _EDoBolNum = EDoBolNum;
			CustNumType _SCustNum = SCustNum;
			CustNumType _ECustNum = ECustNum;
			CustSeqType _SShipToNum = SShipToNum;
			CustSeqType _EShipToNum = EShipToNum;
			DateType _SPickupDate = SPickupDate;
			DateType _EPickupDate = EPickupDate;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingPickupDateOffset = StartingPickupDateOffset;
			DateOffsetType _EndingPickupDateOffset = EndingPickupDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChgDoBolStatSp";
				
				appDB.AddCommandParameter(cmd, "PText", _PText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IOldDoStat", _IOldDoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "INewDoStat", _INewDoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SDoBolNum", _SDoBolNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EDoBolNum", _EDoBolNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SCustNum", _SCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECustNum", _ECustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SShipToNum", _SShipToNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EShipToNum", _EShipToNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPickupDate", _SPickupDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPickupDate", _EPickupDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingPickupDateOffset", _StartingPickupDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPickupDateOffset", _EndingPickupDateOffset, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
