//PROJECT NAME: Logistics
//CLASS NAME: UpdateApparms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class UpdateApparms : IUpdateApparms
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateApparms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UpdateApparmsSp(string PEFTFile,
		DateTime? PEFTFileDate,
		string PFileFormat)
		{
			EFTFileType _PEFTFile = PEFTFile;
			DateType _PEFTFileDate = PEFTFileDate;
			EFTFormatType _PFileFormat = PFileFormat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateApparmsSp";
				
				appDB.AddCommandParameter(cmd, "PEFTFile", _PEFTFile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEFTFileDate", _PEFTFileDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFileFormat", _PFileFormat, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
