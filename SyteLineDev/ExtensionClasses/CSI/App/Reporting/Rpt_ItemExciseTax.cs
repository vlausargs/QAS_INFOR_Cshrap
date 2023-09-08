//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemExciseTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ItemExciseTax
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemExciseTaxSp(string pStartItem = null,
		string pEndItem = null,
		DateTime? pStartInvDate = null,
		DateTime? pEndInvDate = null,
		string pStartCustNum = null,
		string pEndCustNum = null,
		byte? pDisplayHeader = (byte)1,
		short? pStartInvDateOffset = null,
		short? pEndInvDateOffset = null,
		string BGSessionId = null,
		string pSite = null);
	}
	
	public class Rpt_ItemExciseTax : IRpt_ItemExciseTax
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ItemExciseTax(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemExciseTaxSp(string pStartItem = null,
		string pEndItem = null,
		DateTime? pStartInvDate = null,
		DateTime? pEndInvDate = null,
		string pStartCustNum = null,
		string pEndCustNum = null,
		byte? pDisplayHeader = (byte)1,
		short? pStartInvDateOffset = null,
		short? pEndInvDateOffset = null,
		string BGSessionId = null,
		string pSite = null)
		{
			ItemType _pStartItem = pStartItem;
			ItemType _pEndItem = pEndItem;
			DateType _pStartInvDate = pStartInvDate;
			DateType _pEndInvDate = pEndInvDate;
			CustNumType _pStartCustNum = pStartCustNum;
			CustNumType _pEndCustNum = pEndCustNum;
			ListYesNoType _pDisplayHeader = pDisplayHeader;
			DateOffsetType _pStartInvDateOffset = pStartInvDateOffset;
			DateOffsetType _pEndInvDateOffset = pEndInvDateOffset;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ItemExciseTaxSp";
				
				appDB.AddCommandParameter(cmd, "pStartItem", _pStartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndItem", _pEndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartInvDate", _pStartInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndInvDate", _pEndInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartCustNum", _pStartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum", _pEndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDisplayHeader", _pDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartInvDateOffset", _pStartInvDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndInvDateOffset", _pEndInvDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
