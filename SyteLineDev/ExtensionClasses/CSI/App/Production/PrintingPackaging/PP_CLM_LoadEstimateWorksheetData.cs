//PROJECT NAME: Production
//CLASS NAME: PP_CLM_LoadEstimateWorksheetData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_CLM_LoadEstimateWorksheetData : IPP_CLM_LoadEstimateWorksheetData
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public PP_CLM_LoadEstimateWorksheetData(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) PP_CLM_LoadEstimateWorksheetDataSp(string CoNum,
		int? CoLine,
		decimal? CompQty2,
		decimal? CompQty3,
		decimal? CompQty4,
		decimal? CompQty5,
		string Infobar,
		string FilterString)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				CoNumType _CoNum = CoNum;
				CoLineType _CoLine = CoLine;
				QtyUnitNoNegType _CompQty2 = CompQty2;
				QtyUnitNoNegType _CompQty3 = CompQty3;
				QtyUnitNoNegType _CompQty4 = CompQty4;
				QtyUnitNoNegType _CompQty5 = CompQty5;
				InfobarType _Infobar = Infobar;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "PP_CLM_LoadEstimateWorksheetDataSp";
					
					appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CompQty2", _CompQty2, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CompQty3", _CompQty3, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CompQty4", _CompQty4, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CompQty5", _CompQty5, ParameterDirection.Input);
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
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
