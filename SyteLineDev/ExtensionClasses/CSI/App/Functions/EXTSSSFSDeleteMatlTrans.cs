//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSDeleteMatlTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Functions
{
	public class EXTSSSFSDeleteMatlTrans : IEXTSSSFSDeleteMatlTrans
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public EXTSSSFSDeleteMatlTrans(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse EXTSSSFSDeleteMatlTransFn(
			DateTime? FromTransDate,
			DateTime? ToTransDate,
			decimal? FromTransNum,
			decimal? ToTransNum,
			string FromItem,
			string ToItem,
			string FromLoc,
			string ToLoc,
			string RefType)
		{
			DateType _FromTransDate = FromTransDate;
			DateType _ToTransDate = ToTransDate;
			MatlTransNumType _FromTransNum = FromTransNum;
			MatlTransNumType _ToTransNum = ToTransNum;
			ItemType _FromItem = FromItem;
			ItemType _ToItem = ToItem;
			LocType _FromLoc = FromLoc;
			LocType _ToLoc = ToLoc;
			StringType _RefType = RefType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[EXTSSSFSDeleteMatlTrans](@FromTransDate, @ToTransDate, @FromTransNum, @ToTransNum, @FromItem, @ToItem, @FromLoc, @ToLoc, @RefType)";
				
				appDB.AddCommandParameter(cmd, "FromTransDate", _FromTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransDate", _ToTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTransNum", _FromTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransNum", _ToTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_EXTSSSFSDeleteMatlTrans";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
