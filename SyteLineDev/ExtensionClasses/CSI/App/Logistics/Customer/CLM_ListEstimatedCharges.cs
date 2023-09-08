//PROJECT NAME: Logistics
//CLASS NAME: CLM_ListEstimatedCharg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_ListEstimatedCharg
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ListEstimatedCharges(string PTable,
		string PSite,
		string PCoNum,
		byte? PCalcTax);
	}
	
	public class CLM_ListEstimatedCharg : ICLM_ListEstimatedCharg
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ListEstimatedCharg(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ListEstimatedCharges(string PTable,
		string PSite,
		string PCoNum,
		byte? PCalcTax)
		{
			StringType _PTable = PTable;
			SiteType _PSite = PSite;
			CoNumType _PCoNum = PCoNum;
			FlagNyType _PCalcTax = PCalcTax;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ListEstimatedCharges";
				
				appDB.AddCommandParameter(cmd, "PTable", _PTable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCalcTax", _PCalcTax, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
