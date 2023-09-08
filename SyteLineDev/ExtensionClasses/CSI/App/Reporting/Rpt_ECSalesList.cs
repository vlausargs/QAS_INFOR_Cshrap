//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ECSalesList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ECSalesList : IRpt_ECSalesList
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ECSalesList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ECSalesListSP(string SiteGroup = null,
		DateTime? BeginInvStaxInvDate = null,
		DateTime? EndInvStaxInvDate = null,
		int? BeginInvStaxInvDateOffset = null,
		int? EndInvStaxInvDateOffset = null,
		string Eceslqtr = null,
		int? Eceslfrt = null,
		int? Eceslmsc = null,
		int? ShowDetail = null,
		string BeginCustNum = null,
		string EndCustNum = null,
		string BeginEcCode = null,
		string EndEcCode = null,
		string BeginProcessInd = null,
		string EndProcessInd = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		int? IncludeTransferOrders = null,
		string pSite = null)
		{
			SiteGroupType _SiteGroup = SiteGroup;
			DateType _BeginInvStaxInvDate = BeginInvStaxInvDate;
			DateType _EndInvStaxInvDate = EndInvStaxInvDate;
			DateOffsetType _BeginInvStaxInvDateOffset = BeginInvStaxInvDateOffset;
			DateOffsetType _EndInvStaxInvDateOffset = EndInvStaxInvDateOffset;
			StringType _Eceslqtr = Eceslqtr;
			ByteType _Eceslfrt = Eceslfrt;
			ByteType _Eceslmsc = Eceslmsc;
			ByteType _ShowDetail = ShowDetail;
			CustNumType _BeginCustNum = BeginCustNum;
			CustNumType _EndCustNum = EndCustNum;
			EcCodeType _BeginEcCode = BeginEcCode;
			EcCodeType _EndEcCode = EndEcCode;
			ProcessIndType _BeginProcessInd = BeginProcessInd;
			ProcessIndType _EndProcessInd = EndProcessInd;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			ByteType _IncludeTransferOrders = IncludeTransferOrders;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ECSalesListSP";
				
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginInvStaxInvDate", _BeginInvStaxInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvStaxInvDate", _EndInvStaxInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginInvStaxInvDateOffset", _BeginInvStaxInvDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvStaxInvDateOffset", _EndInvStaxInvDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Eceslqtr", _Eceslqtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Eceslfrt", _Eceslfrt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Eceslmsc", _Eceslmsc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginCustNum", _BeginCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginEcCode", _BeginEcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndEcCode", _EndEcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginProcessInd", _BeginProcessInd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndProcessInd", _EndProcessInd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeTransferOrders", _IncludeTransferOrders, ParameterDirection.Input);
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
