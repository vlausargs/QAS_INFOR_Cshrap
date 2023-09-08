//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_PostedVoucherInquiry.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface ICHSRpt_PostedVoucherInquiry
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_PostedVoucherInquirySp(DateTime? TransDate,
		byte? Period,
		string CrntNmbrStart,
		string CrntNmbrEnd,
		string TypeCode,
		string pSite = null);
	}
	
	public class CHSRpt_PostedVoucherInquiry : ICHSRpt_PostedVoucherInquiry
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSRpt_PostedVoucherInquiry(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_PostedVoucherInquirySp(DateTime? TransDate,
		byte? Period,
		string CrntNmbrStart,
		string CrntNmbrEnd,
		string TypeCode,
		string pSite = null)
		{
			DateType _TransDate = TransDate;
			FinPeriodType _Period = Period;
			GenericMedCodeType _CrntNmbrStart = CrntNmbrStart;
			GenericMedCodeType _CrntNmbrEnd = CrntNmbrEnd;
			TransNatType _TypeCode = TypeCode;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRpt_PostedVoucherInquirySp";
				
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CrntNmbrStart", _CrntNmbrStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CrntNmbrEnd", _CrntNmbrEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TypeCode", _TypeCode, ParameterDirection.Input);
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
