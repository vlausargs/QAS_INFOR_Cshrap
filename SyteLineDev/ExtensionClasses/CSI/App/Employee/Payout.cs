//PROJECT NAME: CSIEmployee
//CLASS NAME: Payout.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IPayout
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PayoutSp(string InterfaceVersion = "W",
		string SummaryOrDetail = "D",
		string StartingDept = null,
		string EndingDept = null,
		string StartingEmpNum = null,
		string EndingEmpNum = null,
		string FilterString = null,
		decimal? UserId = null);
	}
	
	public class Payout : IPayout
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Payout(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) PayoutSp(string InterfaceVersion = "W",
		string SummaryOrDetail = "D",
		string StartingDept = null,
		string EndingDept = null,
		string StartingEmpNum = null,
		string EndingEmpNum = null,
		string FilterString = null,
		decimal? UserId = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				StringType _InterfaceVersion = InterfaceVersion;
				StringType _SummaryOrDetail = SummaryOrDetail;
				DeptType _StartingDept = StartingDept;
				DeptType _EndingDept = EndingDept;
				EmpNumType _StartingEmpNum = StartingEmpNum;
				EmpNumType _EndingEmpNum = EndingEmpNum;
				LongListType _FilterString = FilterString;
				TokenType _UserId = UserId;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "PayoutSp";
					
					appDB.AddCommandParameter(cmd, "InterfaceVersion", _InterfaceVersion, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SummaryOrDetail", _SummaryOrDetail, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartingDept", _StartingDept, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingDept", _EndingDept, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartingEmpNum", _StartingEmpNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingEmpNum", _EndingEmpNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
					
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
