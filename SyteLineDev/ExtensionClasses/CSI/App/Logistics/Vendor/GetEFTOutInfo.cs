//PROJECT NAME: Logistics
//CLASS NAME: GetEFTOutInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetEFTOutInfo : IGetEFTOutInfo
	{
		readonly IApplicationDB appDB;
		
		
		public GetEFTOutInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PEFTDestinationID,
		string PEFTOriginationID,
		decimal? PEFTCompanyID,
		string EFTDirectory,
		string EFTFile,
		DateTime? EFTDate,
		string EFTUserName,
		string EFTRegNumber,
		int? UseDefEFTAcct,
        string EFTUserNumber) GetEFTOutInfoSp(string PEFTFormat,
		string PEFTBankCode,
		string PEFTDestinationID,
		string PEFTOriginationID,
		decimal? PEFTCompanyID,
		string EFTDirectory,
		string EFTFile,
		DateTime? EFTDate,
		string EFTUserName,
		string EFTRegNumber,
		int? UseDefEFTAcct,
        string EFTUserNumber)
		{
			EFTFormatType _PEFTFormat = PEFTFormat;
			BankCodeType _PEFTBankCode = PEFTBankCode;
			BankTransitNumType _PEFTDestinationID = PEFTDestinationID;
			AchOriginIdType _PEFTOriginationID = PEFTOriginationID;
			AchIdType _PEFTCompanyID = PEFTCompanyID;
			OSLocationType _EFTDirectory = EFTDirectory;
			EFTFileType _EFTFile = EFTFile;
			DateType _EFTDate = EFTDate;
			EFTUserNameType _EFTUserName = EFTUserName;
			EFTRegistrationNumberType _EFTRegNumber = EFTRegNumber;
			ListYesNoType _UseDefEFTAcct = UseDefEFTAcct;
            EFTUserNumberType _EFTUserNumber = EFTUserNumber;


            using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetEFTOutInfoSp";
				
				appDB.AddCommandParameter(cmd, "PEFTFormat", _PEFTFormat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEFTBankCode", _PEFTBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEFTDestinationID", _PEFTDestinationID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEFTOriginationID", _PEFTOriginationID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEFTCompanyID", _PEFTCompanyID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EFTDirectory", _EFTDirectory, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EFTFile", _EFTFile, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EFTDate", _EFTDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EFTUserName", _EFTUserName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EFTRegNumber", _EFTRegNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseDefEFTAcct", _UseDefEFTAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EFTUserNumber", _EFTUserNumber, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);
				
				PEFTDestinationID = _PEFTDestinationID;
				PEFTOriginationID = _PEFTOriginationID;
				PEFTCompanyID = _PEFTCompanyID;
				EFTDirectory = _EFTDirectory;
				EFTFile = _EFTFile;
				EFTDate = _EFTDate;
				EFTUserName = _EFTUserName;
				EFTRegNumber = _EFTRegNumber;
				UseDefEFTAcct = _UseDefEFTAcct;
                EFTUserNumber = _EFTUserNumber;

                return (Severity, PEFTDestinationID, PEFTOriginationID, PEFTCompanyID, EFTDirectory, EFTFile, EFTDate, EFTUserName, EFTRegNumber, UseDefEFTAcct, EFTUserNumber);
			}
		}
	}
}
