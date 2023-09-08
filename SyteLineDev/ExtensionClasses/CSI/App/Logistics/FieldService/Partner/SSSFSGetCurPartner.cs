//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSGetCurPartner.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSGetCurPartner
	{
		int SSSFSGetCurPartnerSp(ref string Partner,
		                         ref string Name,
		                         ref string Infobar);
	}
	
	public class SSSFSGetCurPartner : ISSSFSGetCurPartner
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetCurPartner(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSGetCurPartnerSp(ref string Partner,
		                                ref string Name,
		                                ref string Infobar)
		{
			FSPartnerType _Partner = Partner;
			NameType _Name = Name;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetCurPartnerSp";
				
				appDB.AddCommandParameter(cmd, "Partner", _Partner, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Partner = _Partner;
				Name = _Name;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
