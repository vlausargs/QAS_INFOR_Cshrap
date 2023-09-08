//PROJECT NAME: Production
//CLASS NAME: ApsGetSHIFT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetSHIFT : IApsGetSHIFT
	{
		readonly IApplicationDB appDB;
		
		
		public ApsGetSHIFT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string DESCR,
		string Infobar) ApsGetSHIFTSp(int? AltNo,
		string SHIFTID,
		string DESCR,
		string Infobar)
		{
			ApsAltNoType _AltNo = AltNo;
			ApsShiftType _SHIFTID = SHIFTID;
			DescriptionType _DESCR = DESCR;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsGetSHIFTSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SHIFTID", _SHIFTID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DESCR", _DESCR, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DESCR = _DESCR;
				Infobar = _Infobar;
				
				return (Severity, DESCR, Infobar);
			}
		}
	}
}
