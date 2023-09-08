//PROJECT NAME: Logistics
//CLASS NAME: GetApparmsEFTInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetApparmsEFTInfo : IGetApparmsEFTInfo
	{
		readonly IApplicationDB appDB;
		
		
		public GetApparmsEFTInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PEFTFormat,
		string PEFTDestinationID,
		string PEFTOriginationID,
		decimal? PEFTCompanyID) GetApparmsEFTInfoSp(string PEFTFormat,
		string PEFTDestinationID,
		string PEFTOriginationID,
		decimal? PEFTCompanyID)
		{
			EFTFormatType _PEFTFormat = PEFTFormat;
			BankTransitNumType _PEFTDestinationID = PEFTDestinationID;
			AchOriginIdType _PEFTOriginationID = PEFTOriginationID;
			AchIdType _PEFTCompanyID = PEFTCompanyID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetApparmsEFTInfoSp";
				
				appDB.AddCommandParameter(cmd, "PEFTFormat", _PEFTFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEFTDestinationID", _PEFTDestinationID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEFTOriginationID", _PEFTOriginationID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEFTCompanyID", _PEFTCompanyID, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PEFTFormat = _PEFTFormat;
				PEFTDestinationID = _PEFTDestinationID;
				PEFTOriginationID = _PEFTOriginationID;
				PEFTCompanyID = _PEFTCompanyID;
				
				return (Severity, PEFTFormat, PEFTDestinationID, PEFTOriginationID, PEFTCompanyID);
			}
		}
	}
}
