//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ElectronicSignatureRecords.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ElectronicSignatureRecords : IRpt_ElectronicSignatureRecords
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ElectronicSignatureRecords(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ElectronicSignatureRecordsSp(string EsigType,
		string EsigNumber = null,
		int? EsigLine = null,
		int? EsigRelease = null,
		string LanguageId = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			ElectronicSignatureTypeType _EsigType = EsigType;
			JobPoProjReqTrnNumType _EsigNumber = EsigNumber;
			SuffixPoLineProjTaskReqTrnLineType _EsigLine = EsigLine;
			OperNumPoReleaseType _EsigRelease = EsigRelease;
			LanguageIDType _LanguageId = LanguageId;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ElectronicSignatureRecordsSp";
				
				appDB.AddCommandParameter(cmd, "EsigType", _EsigType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EsigNumber", _EsigNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EsigLine", _EsigLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EsigRelease", _EsigRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LanguageId", _LanguageId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
