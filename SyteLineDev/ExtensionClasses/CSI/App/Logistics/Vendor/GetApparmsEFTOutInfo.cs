//PROJECT NAME: CSIVendor
//CLASS NAME: GetApparmsEFTOutInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetApparmsEFTOutInfo
	{
		int GetApparmsEFTOutInfoSp(ref string PEFTFormat,
		                           ref string PEFTDestinationID,
		                           ref string PEFTOriginationID,
		                           ref decimal? PEFTCompanyID,
		                           ref string EFTDirectory,
		                           ref string EFTFile,
		                           ref DateTime? EFTDate,
		                           ref string EFTUserName,
		                           ref string EFTRegNumber,
		                           ref byte? UseDefEFTAcct);
	}
	
	public class GetApparmsEFTOutInfo : IGetApparmsEFTOutInfo
	{
		readonly IApplicationDB appDB;
		
		public GetApparmsEFTOutInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetApparmsEFTOutInfoSp(ref string PEFTFormat,
		                                  ref string PEFTDestinationID,
		                                  ref string PEFTOriginationID,
		                                  ref decimal? PEFTCompanyID,
		                                  ref string EFTDirectory,
		                                  ref string EFTFile,
		                                  ref DateTime? EFTDate,
		                                  ref string EFTUserName,
		                                  ref string EFTRegNumber,
		                                  ref byte? UseDefEFTAcct)
		{
			EFTFormatType _PEFTFormat = PEFTFormat;
			BankTransitNumType _PEFTDestinationID = PEFTDestinationID;
			AchOriginIdType _PEFTOriginationID = PEFTOriginationID;
			AchIdType _PEFTCompanyID = PEFTCompanyID;
			OSLocationType _EFTDirectory = EFTDirectory;
			EFTFileType _EFTFile = EFTFile;
			DateType _EFTDate = EFTDate;
			EFTUserNameType _EFTUserName = EFTUserName;
			EFTRegistrationNumberType _EFTRegNumber = EFTRegNumber;
			ListYesNoType _UseDefEFTAcct = UseDefEFTAcct;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetApparmsEFTOutInfoSp";
				
				appDB.AddCommandParameter(cmd, "PEFTFormat", _PEFTFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEFTDestinationID", _PEFTDestinationID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEFTOriginationID", _PEFTOriginationID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEFTCompanyID", _PEFTCompanyID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EFTDirectory", _EFTDirectory, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EFTFile", _EFTFile, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EFTDate", _EFTDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EFTUserName", _EFTUserName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EFTRegNumber", _EFTRegNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseDefEFTAcct", _UseDefEFTAcct, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PEFTFormat = _PEFTFormat;
				PEFTDestinationID = _PEFTDestinationID;
				PEFTOriginationID = _PEFTOriginationID;
				PEFTCompanyID = _PEFTCompanyID;
				EFTDirectory = _EFTDirectory;
				EFTFile = _EFTFile;
				EFTDate = _EFTDate;
				EFTUserName = _EFTUserName;
				EFTRegNumber = _EFTRegNumber;
				UseDefEFTAcct = _UseDefEFTAcct;
				
				return Severity;
			}
		}
	}
}
