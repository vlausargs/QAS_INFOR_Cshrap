//PROJECT NAME: CSIVendor
//CLASS NAME: MoveLocalVend.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IMoveLocalVend
	{
		(int? ReturnCode, string Infobar) MoveLocalVendSp(string POldVendNum,
		string PNewVendNum,
		string Infobar = null);
	}
	
	public class MoveLocalVend : IMoveLocalVend
	{
		readonly IApplicationDB appDB;
		
		public MoveLocalVend(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MoveLocalVendSp(string POldVendNum,
		string PNewVendNum,
		string Infobar = null)
		{
			VendNumType _POldVendNum = POldVendNum;
			VendNumType _PNewVendNum = PNewVendNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MoveLocalVendSp";
				
				appDB.AddCommandParameter(cmd, "POldVendNum", _POldVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewVendNum", _PNewVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
