//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_OrderShipping.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_OrderShipping
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_OrderShippingSp(string CoNum = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		string CoitemStatuses = null,
		string CurWhse = null,
		string ContainerNum = null,
		string Infobar = null,
		string FilterString = null);
	}
	
	public class CLM_OrderShipping : ICLM_OrderShipping
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_OrderShipping(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_OrderShippingSp(string CoNum = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		string CoitemStatuses = null,
		string CurWhse = null,
		string ContainerNum = null,
		string Infobar = null,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				CoNumType _CoNum = CoNum;
				DateType _StartDate = StartDate;
				DateType _EndDate = EndDate;
				StringType _CoitemStatuses = CoitemStatuses;
				WhseType _CurWhse = CurWhse;
				ContainerNumType _ContainerNum = ContainerNum;
				InfobarType _Infobar = Infobar;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_OrderShippingSp";
					
					appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CoitemStatuses", _CoitemStatuses, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    Infobar = _Infobar;
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
