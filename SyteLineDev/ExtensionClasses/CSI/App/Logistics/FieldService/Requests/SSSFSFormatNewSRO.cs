//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSFormatNewSRO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSFormatNewSRO
	{
		int SSSFSFormatNewSROSp(string SroNum,
		                        ref string NewSroNum,
		                        ref string Infobar);
	}
	
	public class SSSFSFormatNewSRO : ISSSFSFormatNewSRO
	{
		readonly IApplicationDB appDB;
		
		public SSSFSFormatNewSRO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSFormatNewSROSp(string SroNum,
		                               ref string NewSroNum,
		                               ref string Infobar)
		{
			FSSRONumType _SroNum = SroNum;
			FSSRONumType _NewSroNum = NewSroNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSFormatNewSROSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewSroNum", _NewSroNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewSroNum = _NewSroNum;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
