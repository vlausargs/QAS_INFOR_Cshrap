//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConsoleLoadTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSConsoleLoadTrans : ISSSFSConsoleLoadTrans
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSConsoleLoadTrans(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSConsoleLoadTransSp(string SroNum,
		int? SroLine,
		int? SroOper,
		string PlanAct,
		string SiteRef = null,
		string FilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				FSSRONumType _SroNum = SroNum;
				FSSROLineType _SroLine = SroLine;
				FSSROOperType _SroOper = SroOper;
				FSSROTransTypeType _PlanAct = PlanAct;
				SiteType _SiteRef = SiteRef;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SSSFSConsoleLoadTransSp";
					
					appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PlanAct", _PlanAct, ParameterDirection.Input);
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
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
