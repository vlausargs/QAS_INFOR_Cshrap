//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_VoucherTotal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface ICHSRpt_VoucherTotal
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_VoucherTotalSp(DateTime? BegDate,
		DateTime? EndDate,
		string BegCHVounum,
		string EndCHVounum,
		string pSite = null);
	}
	
	public class CHSRpt_VoucherTotal : ICHSRpt_VoucherTotal
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSRpt_VoucherTotal(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_VoucherTotalSp(DateTime? BegDate,
		DateTime? EndDate,
		string BegCHVounum,
		string EndCHVounum,
		string pSite = null)
		{
			DateType _BegDate = BegDate;
			DateType _EndDate = EndDate;
			GenericMedCodeType _BegCHVounum = BegCHVounum;
			GenericMedCodeType _EndCHVounum = EndCHVounum;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRpt_VoucherTotalSp";
				
				appDB.AddCommandParameter(cmd, "BegDate", _BegDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegCHVounum", _BegCHVounum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCHVounum", _EndCHVounum, ParameterDirection.Input);
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
