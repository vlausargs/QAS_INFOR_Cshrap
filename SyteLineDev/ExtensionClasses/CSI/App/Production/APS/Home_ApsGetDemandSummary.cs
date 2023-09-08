//PROJECT NAME: Production
//CLASS NAME: Home_ApsGetDemandSummary.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class Home_ApsGetDemandSummary : IHome_ApsGetDemandSummary
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

		public Home_ApsGetDemandSummary(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) Home_ApsGetDemandSummarySp(DateTime? PStartDate,
		DateTime? PEndDate,
		string PDemandType,
		string PDemandID,
		string PItem,
		string PCustomer,
		string PLateness,
		string PCriticalItem,
		int? PShowPLN,
		string PPlanCode,
		string PWildCardChar,
		int? AltNo,
		string SiteGroup,
		string FilterString)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();

			try
			{
				DateType _PStartDate = PStartDate;
				DateType _PEndDate = PEndDate;
				RefType _PDemandType = PDemandType;
				OrderRefStrType _PDemandID = PDemandID;
				ItemType _PItem = PItem;
				NameType _PCustomer = PCustomer;
				GenericKeyType _PLateness = PLateness;
				ItemType _PCriticalItem = PCriticalItem;
				ListYesNoType _PShowPLN = PShowPLN;
				UserCodeType _PPlanCode = PPlanCode;
				StringType _PWildCardChar = PWildCardChar;
				ApsAltNoType _AltNo = AltNo;
				SiteGroupType _SiteGroup = SiteGroup;
				LongListType _FilterString = FilterString;

				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();

					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "Home_ApsGetDemandSummarySp";

					appDB.AddCommandParameter(cmd, "PStartDate", _PStartDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndDate", _PEndDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PDemandType", _PDemandType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PDemandID", _PDemandID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PCustomer", _PCustomer, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PLateness", _PLateness, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PCriticalItem", _PCriticalItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PShowPLN", _PShowPLN, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PPlanCode", _PPlanCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PWildCardChar", _PWildCardChar, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);

					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

					dtReturn = appDB.ExecuteQuery(cmd);

					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
