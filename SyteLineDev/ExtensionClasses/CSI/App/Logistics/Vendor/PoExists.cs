//PROJECT NAME: CSIVendor
//CLASS NAME: PoExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPoExists
	{
		int PoExistsSp(string PoNum,
		               ref string PoType,
		               ref byte? PoExists,
		               ref byte? PoChange,
		               ref byte? PoChangePrompt1User,
		               ref byte? PoChangePrompt2User,
		               ref string VendNum,
		               ref string VendName,
		               ref string Infobar);
	}
	
	public class PoExists : IPoExists
	{
		readonly IApplicationDB appDB;
		
		public PoExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PoExistsSp(string PoNum,
		                      ref string PoType,
		                      ref byte? PoExists,
		                      ref byte? PoChange,
		                      ref byte? PoChangePrompt1User,
		                      ref byte? PoChangePrompt2User,
		                      ref string VendNum,
		                      ref string VendName,
		                      ref string Infobar)
		{
			PoNumType _PoNum = PoNum;
			PoTypeType _PoType = PoType;
			FlagNyType _PoExists = PoExists;
			FlagNyType _PoChange = PoChange;
			FlagNyType _PoChangePrompt1User = PoChangePrompt1User;
			FlagNyType _PoChangePrompt2User = PoChangePrompt2User;
			VendNumType _VendNum = VendNum;
			NameType _VendName = VendName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoExistsSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoType", _PoType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoExists", _PoExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoChange", _PoChange, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoChangePrompt1User", _PoChangePrompt1User, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoChangePrompt2User", _PoChangePrompt2User, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendName", _VendName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoType = _PoType;
				PoExists = _PoExists;
				PoChange = _PoChange;
				PoChangePrompt1User = _PoChangePrompt1User;
				PoChangePrompt2User = _PoChangePrompt2User;
				VendNum = _VendNum;
				VendName = _VendName;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
