//PROJECT NAME: Data
//CLASS NAME: UpdatePoitemVendNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdatePoitemVendNum : IUpdatePoitemVendNum
	{
		readonly IApplicationDB appDB;
		
		public UpdatePoitemVendNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UpdatePoitemVendNumSp(
			string PPoNum,
			string PVendNum,
			string PTransNat,
			string PTransNat2,
			string PDelterm,
			string PProcessInd)
		{
			PoNumType _PPoNum = PPoNum;
			VendNumType _PVendNum = PVendNum;
			TransNatType _PTransNat = PTransNat;
			TransNat2Type _PTransNat2 = PTransNat2;
			DeltermType _PDelterm = PDelterm;
			ProcessIndType _PProcessInd = PProcessInd;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdatePoitemVendNumSp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat", _PTransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat2", _PTransNat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDelterm", _PDelterm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessInd", _PProcessInd, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
