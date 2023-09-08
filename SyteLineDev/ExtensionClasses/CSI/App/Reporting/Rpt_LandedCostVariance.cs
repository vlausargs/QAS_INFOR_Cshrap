//PROJECT NAME: Reporting
//CLASS NAME: Rpt_LandedCostVariance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_LandedCostVariance : IRpt_LandedCostVariance
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_LandedCostVariance(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_LandedCostVarianceSp(string StartingPoNum = null,
		string EndingPoNum = null,
		string PoType = null,
		string PoStat = null,
		string PoitemStat = null,
		int? TransDomCurr = null,
		string StartingVendor = null,
		string EndingVendor = null,
		DateTime? StartingOrderDate = null,
		DateTime? EndingOrderDate = null,
		int? StartingOrderDateOffset = null,
		int? EndingOrderDateOffset = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null)
		{
			PoNumType _StartingPoNum = StartingPoNum;
			PoNumType _EndingPoNum = EndingPoNum;
			InfobarType _PoType = PoType;
			InfobarType _PoStat = PoStat;
			InfobarType _PoitemStat = PoitemStat;
			FlagNyType _TransDomCurr = TransDomCurr;
			VendNumType _StartingVendor = StartingVendor;
			VendNumType _EndingVendor = EndingVendor;
			DateType _StartingOrderDate = StartingOrderDate;
			DateType _EndingOrderDate = EndingOrderDate;
			DateOffsetType _StartingOrderDateOffset = StartingOrderDateOffset;
			DateOffsetType _EndingOrderDateOffset = EndingOrderDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_LandedCostVarianceSp";
				
				appDB.AddCommandParameter(cmd, "StartingPoNum", _StartingPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPoNum", _EndingPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoType", _PoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoStat", _PoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoitemStat", _PoitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingVendor", _StartingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendor", _EndingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingOrderDate", _StartingOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOrderDate", _EndingOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingOrderDateOffset", _StartingOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOrderDateOffset", _EndingOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
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
