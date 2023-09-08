//PROJECT NAME: CSICustomer
//CLASS NAME: CoDiscAmountValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICoDiscAmountValid
	{
		(int? ReturnCode, string Infobar) CoDiscAmountValidSp(string PCoNum,
		string PCoDiscountType,
		decimal? PCoDiscAmount = 0,
		decimal? PCoMiscCharges = 0,
		string Infobar = null);
	}
	
	public class CoDiscAmountValid : ICoDiscAmountValid
	{
		readonly IApplicationDB appDB;
		
		public CoDiscAmountValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CoDiscAmountValidSp(string PCoNum,
		string PCoDiscountType,
		decimal? PCoDiscAmount = 0,
		decimal? PCoMiscCharges = 0,
		string Infobar = null)
		{
			CoNumType _PCoNum = PCoNum;
			ListAmountPercentType _PCoDiscountType = PCoDiscountType;
			AmountType _PCoDiscAmount = PCoDiscAmount;
			AmountType _PCoMiscCharges = PCoMiscCharges;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoDiscAmountValidSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoDiscountType", _PCoDiscountType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoDiscAmount", _PCoDiscAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoMiscCharges", _PCoMiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
