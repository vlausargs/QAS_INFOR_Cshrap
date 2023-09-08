//PROJECT NAME: Reporting
//CLASS NAME: RPT_RSQC_GageCalCertificate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class RPT_RSQC_GageCalCertificate : IRPT_RSQC_GageCalCertificate
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public RPT_RSQC_GageCalCertificate(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) RPT_RSQC_GageCalCertificateSp(
			string BegGage = null,
			string EndGage = null,
			int? BegTransNum = null,
			int? EndTransNum = null,
			DateTime? BegCalDate = null,
			DateTime? EndCalDate = null,
			int? DisplayHeader = null,
			string psite = null)
		{
			QCCharType _BegGage = BegGage;
			QCCharType _EndGage = EndGage;
			QCTransNumType _BegTransNum = BegTransNum;
			QCTransNumType _EndTransNum = EndTransNum;
			DateType _BegCalDate = BegCalDate;
			DateType _EndCalDate = EndCalDate;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _psite = psite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RPT_RSQC_GageCalCertificateSp";
				
				appDB.AddCommandParameter(cmd, "BegGage", _BegGage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndGage", _EndGage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegTransNum", _BegTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransNum", _EndTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegCalDate", _BegCalDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCalDate", _EndCalDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "psite", _psite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
