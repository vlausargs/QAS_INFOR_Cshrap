//PROJECT NAME: Reporting
//CLASS NAME: Rpt_DraftRemittancePosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_DraftRemittancePosting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_DraftRemittancePostingSp(string PBankCode = null,
		string PStartingVendor = null,
		string PEndingVendor = null,
		byte? DisplayHeader = null,
		int? PDraftNumberStarting = null,
		int? PDraftNumberEnding = null,
		DateTime? PDueDateStarting = null,
		DateTime? PDueDateEnding = null,
		short? PDueDateStartingOffset = null,
		short? PDueDateEndingOffset = null,
		string pSite = null);
	}
	
	public class Rpt_DraftRemittancePosting : IRpt_DraftRemittancePosting
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_DraftRemittancePosting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_DraftRemittancePostingSp(string PBankCode = null,
		string PStartingVendor = null,
		string PEndingVendor = null,
		byte? DisplayHeader = null,
		int? PDraftNumberStarting = null,
		int? PDraftNumberEnding = null,
		DateTime? PDueDateStarting = null,
		DateTime? PDueDateEnding = null,
		short? PDueDateStartingOffset = null,
		short? PDueDateEndingOffset = null,
		string pSite = null)
		{
			BankCodeType _PBankCode = PBankCode;
			VendNumType _PStartingVendor = PStartingVendor;
			VendNumType _PEndingVendor = PEndingVendor;
			ListYesNoType _DisplayHeader = DisplayHeader;
			DraftNumType _PDraftNumberStarting = PDraftNumberStarting;
			DraftNumType _PDraftNumberEnding = PDraftNumberEnding;
			DateType _PDueDateStarting = PDueDateStarting;
			DateType _PDueDateEnding = PDueDateEnding;
			DateOffsetType _PDueDateStartingOffset = PDueDateStartingOffset;
			DateOffsetType _PDueDateEndingOffset = PDueDateEndingOffset;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_DraftRemittancePostingSp";
				
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendor", _PStartingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendor", _PEndingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDraftNumberStarting", _PDraftNumberStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDraftNumberEnding", _PDraftNumberEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDateStarting", _PDueDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDateEnding", _PDueDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDateStartingOffset", _PDueDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDateEndingOffset", _PDueDateEndingOffset, ParameterDirection.Input);
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
