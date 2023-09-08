//PROJECT NAME: Production
//CLASS NAME: ValidateResource.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ValidateResource : IValidateResource
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateResource(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string RESID,
		string DESCR,
		string Infobar) ValidateResourceSp(string RESID,
		int? AltNo,
		string DESCR,
		string Infobar)
		{
			ApsResourceType _RESID = RESID;
			ApsAltNoType _AltNo = AltNo;
			ApsDescriptType _DESCR = DESCR;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateResourceSp";
				
				appDB.AddCommandParameter(cmd, "RESID", _RESID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DESCR", _DESCR, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RESID = _RESID;
				DESCR = _DESCR;
				Infobar = _Infobar;
				
				return (Severity, RESID, DESCR, Infobar);
			}
		}
	}
}
