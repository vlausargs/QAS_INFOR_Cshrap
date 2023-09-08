//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemWhereUsed.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ItemWhereUsed : IRpt_ItemWhereUsed
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ItemWhereUsed(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemWhereUsedSp(string StartingItem = null,
		string EndingItem = null,
		string StartingProductCode = null,
		string EndingProductCode = null,
		string IStat = null,
		string MatlType = null,
		string PMTCode = null,
		string pStocked = null,
		string ABCCode = null,
		int? PageBetweenItems = null,
		int? DisplayHeader = 1,
		string pSite = null,
		string BGUser = null)
		{
			ItemType _StartingItem = StartingItem;
			ItemType _EndingItem = EndingItem;
			ProductCodeType _StartingProductCode = StartingProductCode;
			ProductCodeType _EndingProductCode = EndingProductCode;
			StringType _IStat = IStat;
			StringType _MatlType = MatlType;
			StringType _PMTCode = PMTCode;
			StringType _pStocked = pStocked;
			StringType _ABCCode = ABCCode;
			ListYesNoType _PageBetweenItems = PageBetweenItems;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ItemWhereUsedSp";
				
				appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingProductCode", _StartingProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingProductCode", _EndingProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IStat", _IStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlType", _MatlType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMTCode", _PMTCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStocked", _pStocked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBetweenItems", _PageBetweenItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
