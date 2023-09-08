//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_GetARAgingInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetARAgingInfo
	{
		DataTable CLM_GetARAgingInfoSp(byte? PSubordinate,
		                               string PCustNum,
		                               byte? PSiteQuery);
	}
	
	public class CLM_GetARAgingInfo : ICLM_GetARAgingInfo
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public CLM_GetARAgingInfo(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable CLM_GetARAgingInfoSp(byte? PSubordinate,
		                                      string PCustNum,
		                                      byte? PSiteQuery)
		{
			FlagNyType _PSubordinate = PSubordinate;
			CustNumType _PCustNum = PCustNum;
			FlagNyType _PSiteQuery = PSiteQuery;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_GetARAgingInfoSp";
				
				appDB.AddCommandParameter(cmd, "PSubordinate", _PSubordinate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteQuery", _PSiteQuery, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
			}
		}
	}
}
