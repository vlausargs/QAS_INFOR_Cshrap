//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemLeadTime.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemLeadTime
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ItemLeadTimeSp(string FromItem,
		string ToItem,
		byte? UseWcCal,
		byte? UseOffsetHrs,
		byte? ListOpts,
		string Infobar,
		string ShopCal = null,
		string ApplyOffsetHrsStart = null);
	}
	
	public class ItemLeadTime : IItemLeadTime
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ItemLeadTime(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ItemLeadTimeSp(string FromItem,
		string ToItem,
		byte? UseWcCal,
		byte? UseOffsetHrs,
		byte? ListOpts,
		string Infobar,
		string ShopCal = null,
		string ApplyOffsetHrsStart = null)
		{
			ItemType _FromItem = FromItem;
			ItemType _ToItem = ToItem;
			ListYesNoType _UseWcCal = UseWcCal;
			ListYesNoType _UseOffsetHrs = UseOffsetHrs;
			ListYesNoType _ListOpts = ListOpts;
			InfobarType _Infobar = Infobar;
			CalendarType _ShopCal = ShopCal;
			StringType _ApplyOffsetHrsStart = ApplyOffsetHrsStart;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemLeadTimeSp";
				
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseWcCal", _UseWcCal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseOffsetHrs", _UseOffsetHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ListOpts", _ListOpts, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShopCal", _ShopCal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApplyOffsetHrsStart", _ApplyOffsetHrsStart, ParameterDirection.Input);
				
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
