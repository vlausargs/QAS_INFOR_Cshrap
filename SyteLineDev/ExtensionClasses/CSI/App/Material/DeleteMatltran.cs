//PROJECT NAME: CSIMaterial
//CLASS NAME: DeleteMatltran.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IDeleteMatltran
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) DeleteMatltranSp(string PreviewOrCommit = "P",
		DateTime? FromTransDate = null,
		DateTime? ToTransDate = null,
		string TransType = null,
		string RefType = null,
		string FromItem = null,
		string ToItem = null,
		string FromLoc = null,
		string ToLoc = null,
		decimal? FromTransNum = null,
		decimal? ToTransNum = null,
		string Infobar = null,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null,
		byte? List = (byte)1);
	}
	
	public class DeleteMatltran : IDeleteMatltran
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public DeleteMatltran(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) DeleteMatltranSp(string PreviewOrCommit = "P",
		DateTime? FromTransDate = null,
		DateTime? ToTransDate = null,
		string TransType = null,
		string RefType = null,
		string FromItem = null,
		string ToItem = null,
		string FromLoc = null,
		string ToLoc = null,
		decimal? FromTransNum = null,
		decimal? ToTransNum = null,
		string Infobar = null,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null,
		byte? List = (byte)1)
		{
			LongListType _PreviewOrCommit = PreviewOrCommit;
			DateType _FromTransDate = FromTransDate;
			DateType _ToTransDate = ToTransDate;
			StringType _TransType = TransType;
			StringType _RefType = RefType;
			ItemType _FromItem = FromItem;
			ItemType _ToItem = ToItem;
			LocType _FromLoc = FromLoc;
			LocType _ToLoc = ToLoc;
			MatlTransNumType _FromTransNum = FromTransNum;
			MatlTransNumType _ToTransNum = ToTransNum;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			ListYesNoType _List = List;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteMatltranSp";
				
				appDB.AddCommandParameter(cmd, "PreviewOrCommit", _PreviewOrCommit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTransDate", _FromTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransDate", _ToTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTransNum", _FromTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransNum", _ToTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "List", _List, ParameterDirection.Input);
				
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
