//PROJECT NAME: Reporting
//CLASS NAME: Rpt_1099FormPrinting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_1099FormPrinting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_1099FormPrintingSp(string ExOptszSiteGroup = null,
		string VendorNumStarting = null,
		string VendorNumEnding = null,
		decimal? ExOptgoMinPayments = null,
		byte? ExOptszUseLstYrPayRec = null,
		string ExOptprPaperTapeDisk = null,
		string PPhone = null,
		string pSite = null);
	}
	
	public class Rpt_1099FormPrinting : IRpt_1099FormPrinting
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_1099FormPrinting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_1099FormPrintingSp(string ExOptszSiteGroup = null,
		string VendorNumStarting = null,
		string VendorNumEnding = null,
		decimal? ExOptgoMinPayments = null,
		byte? ExOptszUseLstYrPayRec = null,
		string ExOptprPaperTapeDisk = null,
		string PPhone = null,
		string pSite = null)
		{
			SiteGroupType _ExOptszSiteGroup = ExOptszSiteGroup;
			VendNumType _VendorNumStarting = VendorNumStarting;
			VendNumType _VendorNumEnding = VendorNumEnding;
			AmountType _ExOptgoMinPayments = ExOptgoMinPayments;
			ListYesNoType _ExOptszUseLstYrPayRec = ExOptszUseLstYrPayRec;
			StringType _ExOptprPaperTapeDisk = ExOptprPaperTapeDisk;
			PhoneType _PPhone = PPhone;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_1099FormPrintingSp";
				
				appDB.AddCommandParameter(cmd, "ExOptszSiteGroup", _ExOptszSiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorNumStarting", _VendorNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorNumEnding", _VendorNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptgoMinPayments", _ExOptgoMinPayments, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszUseLstYrPayRec", _ExOptszUseLstYrPayRec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPaperTapeDisk", _ExOptprPaperTapeDisk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPhone", _PPhone, ParameterDirection.Input);
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
