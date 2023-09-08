//PROJECT NAME: CSIVendor
//CLASS NAME: GetAppmtgDoProcessMessage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetAppmtgDoProcessMessage
	{
		int GetAppmtgDoProcessMessageSp(ref string Infobar);
	}
	
	public class GetAppmtgDoProcessMessage : IGetAppmtgDoProcessMessage
	{
		readonly IApplicationDB appDB;
		
		public GetAppmtgDoProcessMessage(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetAppmtgDoProcessMessageSp(ref string Infobar)
		{
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAppmtgDoProcessMessageSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
