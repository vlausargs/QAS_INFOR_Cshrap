//PROJECT NAME: Data
//CLASS NAME: AutoVoucherGenerate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class AutoVoucherGenerate : IAutoVoucherGenerate
	{
		readonly IApplicationDB appDB;
		
		public AutoVoucherGenerate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) AutoVoucherGenerateSp(
			string VendNum,
			string Site,
			Guid? SessionID,
			string Infobar,
			string PoNum = null)
		{
			VendNumType _VendNum = VendNum;
			SiteType _Site = Site;
			RowPointerType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			PoNumType _PoNum = PoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AutoVoucherGenerateSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
