//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCloseLo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroCloseLo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSSroCloseLoad(string StartSRONum = null,
		string EndSRONum = null,
		string StartSROType = null,
		string EndSROType = null,
		string StartBillMgr = null,
		string EndBillMgr = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		byte? BillComplete = (byte)0,
		byte? LinesShipped = (byte)0,
		byte? MatlShipped = (byte)0,
		DateTime? CloseDate = null,
		byte? ExcludeWip = (byte)0,
		string infoBar = null,
		byte? PlannedTransPosted = (byte)0,
		byte? StatCodeClose = (byte)0);
	}
	
	public class SSSFSSroCloseLo : ISSSFSSroCloseLo
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSSroCloseLo(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSSroCloseLoad(string StartSRONum = null,
		string EndSRONum = null,
		string StartSROType = null,
		string EndSROType = null,
		string StartBillMgr = null,
		string EndBillMgr = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		byte? BillComplete = (byte)0,
		byte? LinesShipped = (byte)0,
		byte? MatlShipped = (byte)0,
		DateTime? CloseDate = null,
		byte? ExcludeWip = (byte)0,
		string infoBar = null,
		byte? PlannedTransPosted = (byte)0,
		byte? StatCodeClose = (byte)0)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				FSSRONumType _StartSRONum = StartSRONum;
				FSSRONumType _EndSRONum = EndSRONum;
				FSSROTypeType _StartSROType = StartSROType;
				FSSROTypeType _EndSROType = EndSROType;
				FSPartnerType _StartBillMgr = StartBillMgr;
				FSPartnerType _EndBillMgr = EndBillMgr;
				DateType _StartDate = StartDate;
				DateType _EndDate = EndDate;
				ListYesNoType _BillComplete = BillComplete;
				ListYesNoType _LinesShipped = LinesShipped;
				ListYesNoType _MatlShipped = MatlShipped;
				DateType _CloseDate = CloseDate;
				ListYesNoType _ExcludeWip = ExcludeWip;
				InfobarType _infoBar = infoBar;
				ListYesNoType _PlannedTransPosted = PlannedTransPosted;
				ListYesNoType _StatCodeClose = StatCodeClose;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SSSFSSroCloseLoad";
					
					appDB.AddCommandParameter(cmd, "StartSRONum", _StartSRONum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndSRONum", _EndSRONum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartSROType", _StartSROType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndSROType", _EndSROType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartBillMgr", _StartBillMgr, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndBillMgr", _EndBillMgr, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "BillComplete", _BillComplete, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "LinesShipped", _LinesShipped, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "MatlShipped", _MatlShipped, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CloseDate", _CloseDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ExcludeWip", _ExcludeWip, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "infoBar", _infoBar, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PlannedTransPosted", _PlannedTransPosted, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StatCodeClose", _StatCodeClose, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
