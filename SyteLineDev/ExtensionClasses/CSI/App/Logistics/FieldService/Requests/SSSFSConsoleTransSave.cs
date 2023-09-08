//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSConsoleTransSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSConsoleTransSave
	{
		int SSSFSConsoleTransSaveSp(Guid? RowPointer,
		                            string TransType,
		                            string RefType,
		                            string RefNum,
		                            int? RefLineSuf,
		                            int? RefRelease);
	}
	
	public class SSSFSConsoleTransSave : ISSSFSConsoleTransSave
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConsoleTransSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSConsoleTransSaveSp(Guid? RowPointer,
		                                   string TransType,
		                                   string RefType,
		                                   string RefNum,
		                                   int? RefLineSuf,
		                                   int? RefRelease)
		{
			RowPointer _RowPointer = RowPointer;
			ExtSystemTransIdType _TransType = TransType;
			FSRefTypeIJKMOPRTType _RefType = RefType;
			FSRefNumType _RefNum = RefNum;
			FSRefLineType _RefLineSuf = RefLineSuf;
			FSRefReleaseType _RefRelease = RefRelease;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConsoleTransSaveSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
