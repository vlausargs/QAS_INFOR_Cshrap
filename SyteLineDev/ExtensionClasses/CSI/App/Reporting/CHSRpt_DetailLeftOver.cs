//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_DetailLeftOver.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface ICHSRpt_DetailLeftOver
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_DetailLeftOverSp(int? PYear,
		int? PPeriod,
		string PText,
		int? PrintZeroBal,
		string pSite = null);
	}
	
	public class CHSRpt_DetailLeftOver : ICHSRpt_DetailLeftOver
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSRpt_DetailLeftOver(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_DetailLeftOverSp(int? PYear,
		int? PPeriod,
		string PText,
		int? PrintZeroBal,
		string pSite = null)
		{
			IntType _PYear = PYear;
			IntType _PPeriod = PPeriod;
			StringType _PText = PText;
			IntType _PrintZeroBal = PrintZeroBal;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRpt_DetailLeftOverSp";
				
				appDB.AddCommandParameter(cmd, "PYear", _PYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPeriod", _PPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PText", _PText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintZeroBal", _PrintZeroBal, ParameterDirection.Input);
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
