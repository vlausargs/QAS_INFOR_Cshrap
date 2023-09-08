//PROJECT NAME: CSIVendor
//CLASS NAME: POReceivingListProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPOReceivingListProcess
	{
		(ICollectionLoadResponse Data, int? ReturnCode) POReceivingListProcessSp(string Whse,
		string PoNum,
		DateTime? PDate,
		byte? MatRcptPosting = (byte)0,
		byte? PrBarCode = (byte)0,
		byte? PrVendItem = (byte)0,
		byte? DisplayHeader = (byte)1,
		byte? PrPreLots = (byte)0,
		byte? PrPreSerials = (byte)0,
		byte? PrintManufacturerItem = (byte)0,
		decimal? UserID = null,
		string pSite = null);
	}
	
	public class POReceivingListProcess : IPOReceivingListProcess
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public POReceivingListProcess(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) POReceivingListProcessSp(string Whse,
		string PoNum,
		DateTime? PDate,
		byte? MatRcptPosting = (byte)0,
		byte? PrBarCode = (byte)0,
		byte? PrVendItem = (byte)0,
		byte? DisplayHeader = (byte)1,
		byte? PrPreLots = (byte)0,
		byte? PrPreSerials = (byte)0,
		byte? PrintManufacturerItem = (byte)0,
		decimal? UserID = null,
		string pSite = null)
		{
			WhseType _Whse = Whse;
			PoNumType _PoNum = PoNum;
			DateType _PDate = PDate;
			ListYesNoType _MatRcptPosting = MatRcptPosting;
			ListYesNoType _PrBarCode = PrBarCode;
			ListYesNoType _PrVendItem = PrVendItem;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _PrPreLots = PrPreLots;
			ListYesNoType _PrPreSerials = PrPreSerials;
			ListYesNoType _PrintManufacturerItem = PrintManufacturerItem;
			TokenType _UserID = UserID;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "POReceivingListProcessSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatRcptPosting", _MatRcptPosting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrBarCode", _PrBarCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrVendItem", _PrVendItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrPreLots", _PrPreLots, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrPreSerials", _PrPreSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintManufacturerItem", _PrintManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
