//PROJECT NAME: Production
//CLASS NAME: RSQC_GetEmailParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetEmailParms : IRSQC_GetEmailParms
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetEmailParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CarEMail,
		string MrrEMail,
		string CcrEMail,
		string VrmaEMail) RSQC_GetEmailParmsSp(string CarEMail,
		string MrrEMail,
		string CcrEMail,
		string VrmaEMail)
		{
			QCCharType _CarEMail = CarEMail;
			QCCharType _MrrEMail = MrrEMail;
			QCCharType _CcrEMail = CcrEMail;
			QCCharType _VrmaEMail = VrmaEMail;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetEmailParmsSp";
				
				appDB.AddCommandParameter(cmd, "CarEMail", _CarEMail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MrrEMail", _MrrEMail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CcrEMail", _CcrEMail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VrmaEMail", _VrmaEMail, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CarEMail = _CarEMail;
				MrrEMail = _MrrEMail;
				CcrEMail = _CcrEMail;
				VrmaEMail = _VrmaEMail;
				
				return (Severity, CarEMail, MrrEMail, CcrEMail, VrmaEMail);
			}
		}
	}
}
