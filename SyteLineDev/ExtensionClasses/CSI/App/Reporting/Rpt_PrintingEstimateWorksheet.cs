//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PrintingEstimateWorksheet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PrintingEstimateWorksheet : IRpt_PrintingEstimateWorksheet
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PrintingEstimateWorksheet(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PrintingEstimateWorksheetSp(string CoNum = null,
		int? CoLine = 0,
		decimal? CompQty2 = 0,
		decimal? CompQty3 = 0,
		decimal? CompQty4 = 0,
		decimal? CompQty5 = 0,
		string pSite = null)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			QtyUnitNoNegType _CompQty2 = CompQty2;
			QtyUnitNoNegType _CompQty3 = CompQty3;
			QtyUnitNoNegType _CompQty4 = CompQty4;
			QtyUnitNoNegType _CompQty5 = CompQty5;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PrintingEstimateWorksheetSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompQty2", _CompQty2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompQty3", _CompQty3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompQty4", _CompQty4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompQty5", _CompQty5, ParameterDirection.Input);
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
