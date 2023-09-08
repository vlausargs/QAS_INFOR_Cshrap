//PROJECT NAME: Logistics
//CLASS NAME: GetEftOutfileInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetEftOutfileInfo : IGetEftOutfileInfo
	{
		readonly IApplicationDB appDB;
		
		
		public GetEftOutfileInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string EFTDirectory,
		string EFTFile,
		DateTime? EFTDate) GetEftOutfileInfoSp(string EFTDirectory,
		string EFTFile,
		DateTime? EFTDate)
		{
			OSLocationType _EFTDirectory = EFTDirectory;
			EFTFileType _EFTFile = EFTFile;
			DateType _EFTDate = EFTDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetEftOutfileInfoSp";
				
				appDB.AddCommandParameter(cmd, "EFTDirectory", _EFTDirectory, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EFTFile", _EFTFile, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EFTDate", _EFTDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EFTDirectory = _EFTDirectory;
				EFTFile = _EFTFile;
				EFTDate = _EFTDate;
				
				return (Severity, EFTDirectory, EFTFile, EFTDate);
			}
		}
	}
}
