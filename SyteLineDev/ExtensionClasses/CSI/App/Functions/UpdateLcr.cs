//PROJECT NAME: Data
//CLASS NAME: UpdateLcr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdateLcr : IUpdateLcr
	{
		readonly IApplicationDB appDB;
		
		public UpdateLcr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) UpdateLcrSp(
			string CoNum,
			string CustNum,
			int? AddAccum,
			string LcrNum,
			string Infobar,
			decimal? OldTotalPrice = null,
			decimal? OldShipPrice = null)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			Flag _AddAccum = AddAccum;
			LcrNumType _LcrNum = LcrNum;
			Infobar _Infobar = Infobar;
			AmountType _OldTotalPrice = OldTotalPrice;
			AmountType _OldShipPrice = OldShipPrice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateLcrSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AddAccum", _AddAccum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LcrNum", _LcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OldTotalPrice", _OldTotalPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldShipPrice", _OldShipPrice, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
