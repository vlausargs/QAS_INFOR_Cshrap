//PROJECT NAME: CSIVendor
//CLASS NAME: AP1099MagMedia.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IAP1099MagMedia
	{
		(ICollectionLoadResponse Data, int? ReturnCode) AP1099MagMediaSp(string PSiteGroup = null,
		string PVendorNumStarting = null,
		string PVendorNumEnding = null,
		decimal? PMinPayments = null,
		byte? PUseLstYrPayRec = null,
		string PPaperTapeDisk = null,
		byte? PCombineState = null,
		byte? PForeignTrans = null,
		string PCountry = null,
		byte? PForeignPayer = null,
		string PTransTIN = null,
		string PCompany = null,
		string PCompany2 = null,
		string PAddress = null,
		string PCity = null,
		string PState = null,
		string PZip = null,
		string PContact = null,
		string PPhone = null,
		string PSoftVendor = null,
		byte? PSetPriorYearIndicator = null,
		string PContactEmail = null);
	}
	
	public class AP1099MagMedia : IAP1099MagMedia
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public AP1099MagMedia(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) AP1099MagMediaSp(string PSiteGroup = null,
		string PVendorNumStarting = null,
		string PVendorNumEnding = null,
		decimal? PMinPayments = null,
		byte? PUseLstYrPayRec = null,
		string PPaperTapeDisk = null,
		byte? PCombineState = null,
		byte? PForeignTrans = null,
		string PCountry = null,
		byte? PForeignPayer = null,
		string PTransTIN = null,
		string PCompany = null,
		string PCompany2 = null,
		string PAddress = null,
		string PCity = null,
		string PState = null,
		string PZip = null,
		string PContact = null,
		string PPhone = null,
		string PSoftVendor = null,
		byte? PSetPriorYearIndicator = null,
		string PContactEmail = null)
		{
			SiteGroupType _PSiteGroup = PSiteGroup;
			VendNumType _PVendorNumStarting = PVendorNumStarting;
			VendNumType _PVendorNumEnding = PVendorNumEnding;
			AmountType _PMinPayments = PMinPayments;
			ListYesNoType _PUseLstYrPayRec = PUseLstYrPayRec;
			StringType _PPaperTapeDisk = PPaperTapeDisk;
			ListYesNoType _PCombineState = PCombineState;
			ListYesNoType _PForeignTrans = PForeignTrans;
			CountryType _PCountry = PCountry;
			ListYesNoType _PForeignPayer = PForeignPayer;
			StringType _PTransTIN = PTransTIN;
			StringType _PCompany = PCompany;
			StringType _PCompany2 = PCompany2;
			StringType _PAddress = PAddress;
			StringType _PCity = PCity;
			StringType _PState = PState;
			StringType _PZip = PZip;
			StringType _PContact = PContact;
			StringType _PPhone = PPhone;
			NameType _PSoftVendor = PSoftVendor;
			ListYesNoType _PSetPriorYearIndicator = PSetPriorYearIndicator;
			StringType _PContactEmail = PContactEmail;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AP1099MagMediaSp";
				
				appDB.AddCommandParameter(cmd, "PSiteGroup", _PSiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendorNumStarting", _PVendorNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendorNumEnding", _PVendorNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMinPayments", _PMinPayments, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUseLstYrPayRec", _PUseLstYrPayRec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPaperTapeDisk", _PPaperTapeDisk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCombineState", _PCombineState, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForeignTrans", _PForeignTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCountry", _PCountry, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForeignPayer", _PForeignPayer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransTIN", _PTransTIN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCompany", _PCompany, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCompany2", _PCompany2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAddress", _PAddress, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCity", _PCity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PState", _PState, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PZip", _PZip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PContact", _PContact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPhone", _PPhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSoftVendor", _PSoftVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSetPriorYearIndicator", _PSetPriorYearIndicator, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PContactEmail", _PContactEmail, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
