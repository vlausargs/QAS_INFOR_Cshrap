//PROJECT NAME: CSICustomer
//CLASS NAME: ArSummCustomer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IArSummCustomer
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ArSummCustomerSp(int? RowCount,
		string Filter,
		string Infobar,
		int? PSubordinate = 0,
		int? PSiteQuery = 0);
	}
	
	public class ArSummCustomer : IArSummCustomer
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ArSummCustomer(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ArSummCustomerSp(int? RowCount,
		string Filter,
		string Infobar,
		int? PSubordinate = 0,
		int? PSiteQuery = 0)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				IntType _RowCount = RowCount;
				LongListType _Filter = Filter;
				InfobarType _Infobar = Infobar;
				FlagNyType _PSubordinate = PSubordinate;
				FlagNyType _PSiteQuery = PSiteQuery;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "ArSummCustomerSp";
					
					appDB.AddCommandParameter(cmd, "RowCount", _RowCount, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Filter", _Filter, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					appDB.AddCommandParameter(cmd, "PSubordinate", _PSubordinate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PSiteQuery", _PSiteQuery, ParameterDirection.Input);
					
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
