//PROJECT NAME: Logistics
//CLASS NAME: DelVocuhAdjNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class DelVocuhAdjNum : IDelVocuhAdjNum
	{
		readonly IApplicationDB appDB;
		
		
		public DelVocuhAdjNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? LasttranLastTran,
		string Infobar) DelVocuhAdjNumSp(int? LasttranKey,
		string Action,
		decimal? LasttranLastTran,
		string VoucherType,
		string Infobar)
		{
			LasttranKeyType _LasttranKey = LasttranKey;
			StringType _Action = Action;
			LastTranType _LasttranLastTran = LasttranLastTran;
			StringType _VoucherType = VoucherType;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DelVocuhAdjNumSp";
				
				appDB.AddCommandParameter(cmd, "LasttranKey", _LasttranKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LasttranLastTran", _LasttranLastTran, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VoucherType", _VoucherType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LasttranLastTran = _LasttranLastTran;
				Infobar = _Infobar;
				
				return (Severity, LasttranLastTran, Infobar);
			}
		}
	}
}
