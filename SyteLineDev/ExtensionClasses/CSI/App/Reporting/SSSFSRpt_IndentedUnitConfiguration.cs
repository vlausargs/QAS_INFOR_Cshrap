//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_IndentedUnitConfiguration.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_IndentedUnitConfiguration : ISSSFSRpt_IndentedUnitConfiguration
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_IndentedUnitConfiguration(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_IndentedUnitConfigurationSp(string StartingSerNum,
		string EndingSerNum,
		string StartingItem,
		string EndingItem,
		int? IncludeWarranty,
		int? tLevel,
		DateTime? ConfigDate,
		int? tpage,
		string pSite = null)
		{
			SerNumType _StartingSerNum = StartingSerNum;
			SerNumType _EndingSerNum = EndingSerNum;
			ItemType _StartingItem = StartingItem;
			ItemType _EndingItem = EndingItem;
			ListYesNoType _IncludeWarranty = IncludeWarranty;
			GenericIntType _tLevel = tLevel;
			DateType _ConfigDate = ConfigDate;
			ListYesNoType _tpage = tpage;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_IndentedUnitConfigurationSp";
				
				appDB.AddCommandParameter(cmd, "StartingSerNum", _StartingSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingSerNum", _EndingSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeWarranty", _IncludeWarranty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tLevel", _tLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConfigDate", _ConfigDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tpage", _tpage, ParameterDirection.Input);
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
