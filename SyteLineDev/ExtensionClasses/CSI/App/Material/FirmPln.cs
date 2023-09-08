//PROJECT NAME: CSIMaterial
//CLASS NAME: FirmPln.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IFirmPln
	{
		int FirmPlnSp(Guid? SessionId,
		              string VendNum,
		              string UserName,
		              ref string Infobar);
	}
	
	public class FirmPln : IFirmPln
	{
		readonly IApplicationDB appDB;
		
		public FirmPln(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FirmPlnSp(Guid? SessionId,
		                     string VendNum,
		                     string UserName,
		                     ref string Infobar)
		{
			RowPointerType _SessionId = SessionId;
			VendNumType _VendNum = VendNum;
			UsernameType _UserName = UserName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FirmPlnSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
