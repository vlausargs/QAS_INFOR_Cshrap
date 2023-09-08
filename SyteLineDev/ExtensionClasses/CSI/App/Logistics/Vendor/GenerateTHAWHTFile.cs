//PROJECT NAME: Logistics
//CLASS NAME: GenerateTHAWHTFile.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GenerateTHAWHTFile : IGenerateTHAWHTFile
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateTHAWHTFile(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string WHTFileName,
		string WHTContent,
		string WHTExportLogicalFolder,
		string Infobar) GenerateTHAWHTFileSp(string THAWHTList,
		string THAWHTSeqList,
		DateTime? LastWHTDate,
		string WHTType,
		string WHTFileName = null,
		string WHTContent = null,
		string WHTExportLogicalFolder = null,
		string Infobar = null)
		{
			StringType _THAWHTList = THAWHTList;
			StringType _THAWHTSeqList = THAWHTSeqList;
			DateType _LastWHTDate = LastWHTDate;
			StringType _WHTType = WHTType;
			StringType _WHTFileName = WHTFileName;
			VeryLongListType _WHTContent = WHTContent;
			AuthorizationObjectNameType _WHTExportLogicalFolder = WHTExportLogicalFolder;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateTHAWHTFileSp";
				
				appDB.AddCommandParameter(cmd, "THAWHTList", _THAWHTList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "THAWHTSeqList", _THAWHTSeqList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastWHTDate", _LastWHTDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WHTType", _WHTType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WHTFileName", _WHTFileName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WHTContent", _WHTContent, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WHTExportLogicalFolder", _WHTExportLogicalFolder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				WHTFileName = _WHTFileName;
				WHTContent = _WHTContent;
				WHTExportLogicalFolder = _WHTExportLogicalFolder;
				Infobar = _Infobar;
				
				return (Severity, WHTFileName, WHTContent, WHTExportLogicalFolder, Infobar);
			}
		}
	}
}
