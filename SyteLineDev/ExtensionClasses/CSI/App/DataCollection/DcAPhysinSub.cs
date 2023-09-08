//PROJECT NAME: DataCollection
//CLASS NAME: DcAPhysinSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcAPhysinSub : IDcAPhysinSub
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public DcAPhysinSub(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) DcAPhysinSubSp(
			string TTermId,
			string TEmpNum,
			DateTime? TTransDate,
			string TItem,
			string TCurWhse,
			string TLocation,
			string TLot,
			decimal? TQty,
			int? PTagNum,
			int? PSheetNum,
			string PEmpCount,
			string PEmpCheck,
			string PSerNum)
		{
			DcTermIdType _TTermId = TTermId;
			EmpNumType _TEmpNum = TEmpNum;
			DateTimeType _TTransDate = TTransDate;
			ItemType _TItem = TItem;
			WhseType _TCurWhse = TCurWhse;
			LocType _TLocation = TLocation;
			LotType _TLot = TLot;
			QtyUnitType _TQty = TQty;
			SheetTagNumType _PTagNum = PTagNum;
			SheetTagNumType _PSheetNum = PSheetNum;
			EmpNumType _PEmpCount = PEmpCount;
			EmpNumType _PEmpCheck = PEmpCheck;
			SerNumType _PSerNum = PSerNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcAPhysinSubSp";
				
				appDB.AddCommandParameter(cmd, "TTermId", _TTermId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEmpNum", _TEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItem", _TItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCurWhse", _TCurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLocation", _TLocation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLot", _TLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQty", _TQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTagNum", _PTagNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSheetNum", _PSheetNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmpCount", _PEmpCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmpCheck", _PEmpCheck, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSerNum", _PSerNum, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
