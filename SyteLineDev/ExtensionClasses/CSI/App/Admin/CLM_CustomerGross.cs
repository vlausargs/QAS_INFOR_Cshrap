//PROJECT NAME: CSIAdmin
//CLASS NAME: CLM_CustomerGross.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public interface ICLM_CustomerGross
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_CustomerGrossSp(string Cust_Num = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		byte? Detail = (byte)0,
		string SiteRef = null,
		string FilterString = null);
	}
	
	public class CLM_CustomerGross : ICLM_CustomerGross
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_CustomerGross(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_CustomerGrossSp(string Cust_Num = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		byte? Detail = (byte)0,
		string SiteRef = null,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				CustNumType _Cust_Num = Cust_Num;
				DateTimeType _StartDate = StartDate;
				DateTimeType _EndDate = EndDate;
				FlagNyType _Detail = Detail;
				SiteType _SiteRef = SiteRef;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_CustomerGrossSp";
					
					appDB.AddCommandParameter(cmd, "Cust_Num", _Cust_Num, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Detail", _Detail, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
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
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
