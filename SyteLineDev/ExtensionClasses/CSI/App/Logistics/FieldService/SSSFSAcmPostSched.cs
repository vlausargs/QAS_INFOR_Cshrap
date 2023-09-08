//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAcmPostSched.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSAcmPostSched : ISSSFSAcmPostSched
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSAcmPostSched(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSAcmPostSchedSp(string AcmNum,
		int? AcmSeq,
		DateTime? PostDate,
		string Infobar)
		{
			FSACMNumType _AcmNum = AcmNum;
			FSSeqType _AcmSeq = AcmSeq;
			DateType _PostDate = PostDate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSAcmPostSchedSp";
				
				appDB.AddCommandParameter(cmd, "AcmNum", _AcmNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcmSeq", _AcmSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
