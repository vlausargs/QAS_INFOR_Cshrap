//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSSchedApptPostSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSSchedApptPostSave
	{
		int SSSFSSchedApptPostSaveSp(string SroNum,
		                             string StatCode,
		                             byte? Response,
		                             Guid? ApptRowPtr,
		                             Guid? ApptParentRowPtr);
	}
	
	public class SSSFSSchedApptPostSave : ISSSFSSchedApptPostSave
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSchedApptPostSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSSchedApptPostSaveSp(string SroNum,
		                                    string StatCode,
		                                    byte? Response,
		                                    Guid? ApptRowPtr,
		                                    Guid? ApptParentRowPtr)
		{
			FSSRONumType _SroNum = SroNum;
			FSStatCodeType _StatCode = StatCode;
			ListYesNoType _Response = Response;
			RowPointerType _ApptRowPtr = ApptRowPtr;
			RowPointerType _ApptParentRowPtr = ApptParentRowPtr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSchedApptPostSaveSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatCode", _StatCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Response", _Response, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptRowPtr", _ApptRowPtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptParentRowPtr", _ApptParentRowPtr, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
