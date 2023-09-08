//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSAcmGenerateSched.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSAcmGenerateSched
	{
		int SSSFSAcmGenerateSchedSp(ref string AcmNum,
		                            ref string Infobar);
	}
	
	public class SSSFSAcmGenerateSched : ISSSFSAcmGenerateSched
	{
		readonly IApplicationDB appDB;
		
		public SSSFSAcmGenerateSched(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSAcmGenerateSchedSp(ref string AcmNum,
		                                   ref string Infobar)
		{
			FSACMNumType _AcmNum = AcmNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSAcmGenerateSchedSp";
				
				appDB.AddCommandParameter(cmd, "AcmNum", _AcmNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AcmNum = _AcmNum;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
