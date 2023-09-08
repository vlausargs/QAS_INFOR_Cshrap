//PROJECT NAME: Logistics
//CLASS NAME: IGetEFTOutInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetEFTOutInfo
	{
		(int? ReturnCode, string PEFTDestinationID,
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
        string EFTUserNumber);
	}
}

