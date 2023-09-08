//PROJECT NAME: Data
//CLASS NAME: UpdateVendLcr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdateVendLcr : IUpdateVendLcr
	{
		readonly IApplicationDB appDB;
		
		public UpdateVendLcr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) UpdateVendLcrSp(
			string PoNum,
			string PoVendNum,
			int? AddAccum,
			string LcrNum,
			string Infobar)
		{
			PoNumType _PoNum = PoNum;
			VendNumType _PoVendNum = PoVendNum;
			FlagNyType _AddAccum = AddAccum;
			VendLcrNumType _LcrNum = LcrNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateVendLcrSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoVendNum", _PoVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AddAccum", _AddAccum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LcrNum", _LcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
