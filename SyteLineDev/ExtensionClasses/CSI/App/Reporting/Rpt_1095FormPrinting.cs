//PROJECT NAME: Reporting
//CLASS NAME: Rpt_1095FormPrinting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_1095FormPrinting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_1095FormPrintingSp(Guid? SessionId = null,
		string EmployeeNumStarting = null,
		string EmployeeNumEnding = null,
		string PPhone = null,
		string pSite = null,
		DateTime? OfferDateStarting = null,
		DateTime? OfferDateEnding = null,
		string EmployerName = null,
		string EmployerAddr__1 = null,
		string EmployerZip = null,
		string EmployerCity = null,
		string EmployerState = null,
		string EmployerCountry = null,
		string EmployerEIN = null,
		byte? PCorrected = null);
	}
	
	public class Rpt_1095FormPrinting : IRpt_1095FormPrinting
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_1095FormPrinting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_1095FormPrintingSp(Guid? SessionId = null,
		string EmployeeNumStarting = null,
		string EmployeeNumEnding = null,
		string PPhone = null,
		string pSite = null,
		DateTime? OfferDateStarting = null,
		DateTime? OfferDateEnding = null,
		string EmployerName = null,
		string EmployerAddr__1 = null,
		string EmployerZip = null,
		string EmployerCity = null,
		string EmployerState = null,
		string EmployerCountry = null,
		string EmployerEIN = null,
		byte? PCorrected = null)
		{
			RowPointerType _SessionId = SessionId;
			EmpNumType _EmployeeNumStarting = EmployeeNumStarting;
			EmpNumType _EmployeeNumEnding = EmployeeNumEnding;
			PhoneType _PPhone = PPhone;
			SiteType _pSite = pSite;
			Date4Type _OfferDateStarting = OfferDateStarting;
			Date4Type _OfferDateEnding = OfferDateEnding;
			NameType _EmployerName = EmployerName;
			AddressType _EmployerAddr__1 = EmployerAddr__1;
			PostalCodeType _EmployerZip = EmployerZip;
			CityType _EmployerCity = EmployerCity;
			StateType _EmployerState = EmployerState;
			CountryType _EmployerCountry = EmployerCountry;
			TaxRegNumType _EmployerEIN = EmployerEIN;
			ListYesNoType _PCorrected = PCorrected;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_1095FormPrintingSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeNumStarting", _EmployeeNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeNumEnding", _EmployeeNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPhone", _PPhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OfferDateStarting", _OfferDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OfferDateEnding", _OfferDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployerName", _EmployerName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployerAddr##1", _EmployerAddr__1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployerZip", _EmployerZip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployerCity", _EmployerCity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployerState", _EmployerState, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployerCountry", _EmployerCountry, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployerEIN", _EmployerEIN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCorrected", _PCorrected, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
