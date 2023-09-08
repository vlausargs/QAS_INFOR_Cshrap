//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROPlanActual.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROPlanActual : ISSSFSRpt_SROPlanActual
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_SROPlanActual(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROPlanActualSp(string SRONumBeg = null,
		string SRONumEnd = null,
		int? SROLineBeg = null,
		int? SROLineEnd = null,
		int? SROOperBeg = null,
		int? SROOperEnd = null,
		string ItemBeg = null,
		string ItemEnd = null,
		string WCBeg = null,
		string WCEnd = null,
		string MCBeg = null,
		string MCEnd = null,
		string CostPrice = "P",
		string pSite = null)
		{
			FSSRONumType _SRONumBeg = SRONumBeg;
			FSSRONumType _SRONumEnd = SRONumEnd;
			FSSROLineType _SROLineBeg = SROLineBeg;
			FSSROLineType _SROLineEnd = SROLineEnd;
			FSSROOperType _SROOperBeg = SROOperBeg;
			FSSROOperType _SROOperEnd = SROOperEnd;
			ItemType _ItemBeg = ItemBeg;
			ItemType _ItemEnd = ItemEnd;
			FSWorkCodeType _WCBeg = WCBeg;
			FSWorkCodeType _WCEnd = WCEnd;
			FSMiscCodeType _MCBeg = MCBeg;
			FSMiscCodeType _MCEnd = MCEnd;
			StringType _CostPrice = CostPrice;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_SROPlanActualSp";
				
				appDB.AddCommandParameter(cmd, "SRONumBeg", _SRONumBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONumEnd", _SRONumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLineBeg", _SROLineBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLineEnd", _SROLineEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROOperBeg", _SROOperBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROOperEnd", _SROOperEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemBeg", _ItemBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnd", _ItemEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WCBeg", _WCBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WCEnd", _WCEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MCBeg", _MCBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MCEnd", _MCEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostPrice", _CostPrice, ParameterDirection.Input);
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
