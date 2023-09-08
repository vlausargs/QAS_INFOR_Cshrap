//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RecentPurchases.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RecentPurchases : IRpt_RecentPurchases
	{
        readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RecentPurchases(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RecentPurchasesSp(string StartingItem = null,
		string EndingItem = null,
		string StartingBuyer = null,
		string EndingBuyer = null,
		string StartingVendor = null,
		string EndingVendor = null,
		DateTime? StartingDueDate = null,
		DateTime? EndingDueDate = null,
		int? TranslateCurrency = null,
		int? StartingDueDateOffset = null,
		int? EndingDueDateOffset = null,
		int? PDisplayHeader = 1,
		string pSite = null)
		{
			ItemType _StartingItem = StartingItem;
			ItemType _EndingItem = EndingItem;
			NameType _StartingBuyer = StartingBuyer;
			NameType _EndingBuyer = EndingBuyer;
			VendNumType _StartingVendor = StartingVendor;
			VendNumType _EndingVendor = EndingVendor;
			DateType _StartingDueDate = StartingDueDate;
			DateType _EndingDueDate = EndingDueDate;
			ListYesNoType _TranslateCurrency = TranslateCurrency;
			DateOffsetType _StartingDueDateOffset = StartingDueDateOffset;
			DateOffsetType _EndingDueDateOffset = EndingDueDateOffset;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RecentPurchasesSp";
				
				appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingBuyer", _StartingBuyer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingBuyer", _EndingBuyer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingVendor", _StartingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendor", _EndingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingDueDate", _StartingDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDueDate", _EndingDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranslateCurrency", _TranslateCurrency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingDueDateOffset", _StartingDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDueDateOffset", _EndingDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
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
