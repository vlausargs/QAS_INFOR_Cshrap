//PROJECT NAME: Data
//CLASS NAME: PoTotalValue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PoTotalValue : IPoTotalValue
	{
		readonly IApplicationDB appDB;
		
		public PoTotalValue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PoTotalValueSp(
			string VLcrNum,
			string VendNum,
			string Infobar)
		{
			LcrNumType _VLcrNum = VLcrNum;
			VendNumType _VendNum = VendNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoTotalValueSp";
				
				appDB.AddCommandParameter(cmd, "VLcrNum", _VLcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
