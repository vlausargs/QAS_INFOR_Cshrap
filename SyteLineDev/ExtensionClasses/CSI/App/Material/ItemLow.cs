//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemLow.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemLow
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ItemLowSp(string ListDuring = "N",
		byte? ListRecursiveOnly = (byte)0,
		string Infobar = null);
	}
	
	public class ItemLow : IItemLow
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ItemLow(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ItemLowSp(string ListDuring = "N",
		byte? ListRecursiveOnly = (byte)0,
		string Infobar = null)
		{
			GenericCodeType _ListDuring = ListDuring;
			ListYesNoType _ListRecursiveOnly = ListRecursiveOnly;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemLowSp";
				
				appDB.AddCommandParameter(cmd, "ListDuring", _ListDuring, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ListRecursiveOnly", _ListRecursiveOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
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
