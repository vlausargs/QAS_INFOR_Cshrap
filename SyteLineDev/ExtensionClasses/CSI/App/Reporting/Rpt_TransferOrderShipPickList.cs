//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TransferOrderShipPickList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_TransferOrderShipPickList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_TransferOrderShipPickListSp(string BegTrnNum = null,
		string EndTrnNum = null,
		DateTime? BegShipDate = null,
		short? BegShipDateOffset = null,
		DateTime? EndShipDate = null,
		short? EndShipDateOffset = null,
		DateTime? PostDate = null,
		short? PostDateOffset = null,
		byte? TRNOrderText = (byte)0,
		byte? TRNitemNotes = (byte)0,
		byte? PrSerialNumbers = (byte)0,
		byte? ListByLoc = (byte)0,
		byte? PostMatlIssues = (byte)0,
		byte? PrintBc = (byte)0,
		byte? Pickwarn = (byte)0,
		byte? DisplayHeader = (byte)0,
		byte? PProcess = (byte)1,
		byte? ShowInternal = (byte)1,
		byte? ShowExternal = (byte)1,
		decimal? UserId = null,
		string BGSessionId = null,
		string pSite = null,
		string BGUser = null);
	}
	
	public class Rpt_TransferOrderShipPickList : IRpt_TransferOrderShipPickList
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_TransferOrderShipPickList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_TransferOrderShipPickListSp(string BegTrnNum = null,
		string EndTrnNum = null,
		DateTime? BegShipDate = null,
		short? BegShipDateOffset = null,
		DateTime? EndShipDate = null,
		short? EndShipDateOffset = null,
		DateTime? PostDate = null,
		short? PostDateOffset = null,
		byte? TRNOrderText = (byte)0,
		byte? TRNitemNotes = (byte)0,
		byte? PrSerialNumbers = (byte)0,
		byte? ListByLoc = (byte)0,
		byte? PostMatlIssues = (byte)0,
		byte? PrintBc = (byte)0,
		byte? Pickwarn = (byte)0,
		byte? DisplayHeader = (byte)0,
		byte? PProcess = (byte)1,
		byte? ShowInternal = (byte)1,
		byte? ShowExternal = (byte)1,
		decimal? UserId = null,
		string BGSessionId = null,
		string pSite = null,
		string BGUser = null)
		{
			TrnNumType _BegTrnNum = BegTrnNum;
			TrnNumType _EndTrnNum = EndTrnNum;
			DateType _BegShipDate = BegShipDate;
			DateOffsetType _BegShipDateOffset = BegShipDateOffset;
			DateType _EndShipDate = EndShipDate;
			DateOffsetType _EndShipDateOffset = EndShipDateOffset;
			DateType _PostDate = PostDate;
			DateOffsetType _PostDateOffset = PostDateOffset;
			ListYesNoType _TRNOrderText = TRNOrderText;
			ListYesNoType _TRNitemNotes = TRNitemNotes;
			ListYesNoType _PrSerialNumbers = PrSerialNumbers;
			ListYesNoType _ListByLoc = ListByLoc;
			ListYesNoType _PostMatlIssues = PostMatlIssues;
			ListYesNoType _PrintBc = PrintBc;
			ListYesNoType _Pickwarn = Pickwarn;
			ListYesNoType _DisplayHeader = DisplayHeader;
			FlagNyType _PProcess = PProcess;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			TokenType _UserId = UserId;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_TransferOrderShipPickListSp";
				
				appDB.AddCommandParameter(cmd, "BegTrnNum", _BegTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTrnNum", _EndTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegShipDate", _BegShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegShipDateOffset", _BegShipDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndShipDate", _EndShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndShipDateOffset", _EndShipDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDateOffset", _PostDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRNOrderText", _TRNOrderText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRNitemNotes", _TRNitemNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrSerialNumbers", _PrSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ListByLoc", _ListByLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostMatlIssues", _PostMatlIssues, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBc", _PrintBc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pickwarn", _Pickwarn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcess", _PProcess, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
