//PROJECT NAME: CSIMOIndPack
//CLASS NAME: CloseResMant.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.MOIndPack
{
	public interface ICloseResMant
	{
		int CloseResMantSp(string MOMaintenanceID,
		                   short? AltNo,
		                   byte? DelAssSchMaint,
		                   ref string Infobar);
	}
	
	public class CloseResMant : ICloseResMant
	{
		readonly IApplicationDB appDB;
		
		public CloseResMant(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CloseResMantSp(string MOMaintenanceID,
		                          short? AltNo,
		                          byte? DelAssSchMaint,
		                          ref string Infobar)
		{
			MO_MaintenanceIDType _MOMaintenanceID = MOMaintenanceID;
			ApsAltNoType _AltNo = AltNo;
			ListYesNoType _DelAssSchMaint = DelAssSchMaint;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CloseResMantSp";
				
				appDB.AddCommandParameter(cmd, "MOMaintenanceID", _MOMaintenanceID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DelAssSchMaint", _DelAssSchMaint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
