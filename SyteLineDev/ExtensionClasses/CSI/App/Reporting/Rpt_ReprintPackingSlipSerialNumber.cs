//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ReprintPackingSlipSerialNumber.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ReprintPackingSlipSerialNumber : IRpt_ReprintPackingSlipSerialNumber
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ReprintPackingSlipSerialNumber(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ReprintPackingSlipSerialNumberSp(string PckitemCoNum = null,
		int? PckitemCoLine = null,
		int? PckitemCoRelease = null,
		int? PckHdrPackNum = null,
		string BGSessionId = null,
		string pSite = null)
		{
			CoNumType _PckitemCoNum = PckitemCoNum;
			CoLineType _PckitemCoLine = PckitemCoLine;
			CoReleaseType _PckitemCoRelease = PckitemCoRelease;
			PackNumType _PckHdrPackNum = PckHdrPackNum;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ReprintPackingSlipSerialNumberSp";
				
				appDB.AddCommandParameter(cmd, "PckitemCoNum", _PckitemCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PckitemCoLine", _PckitemCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PckitemCoRelease", _PckitemCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PckHdrPackNum", _PckHdrPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
