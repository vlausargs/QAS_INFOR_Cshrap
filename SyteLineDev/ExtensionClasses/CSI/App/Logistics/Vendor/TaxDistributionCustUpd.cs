//PROJECT NAME: Logistics
//CLASS NAME: TaxDistributionCustUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class TaxDistributionCustUpd : ITaxDistributionCustUpd
	{
		readonly IApplicationDB appDB;
		
		
		public TaxDistributionCustUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? TaxDistributionCustUpdSp(string VchType,
		string PoNum,
		int? TaxSystem,
		string TaxCode,
		string TaxCodeE,
		decimal? AmtTaxBasis,
		decimal? AmtTaxAmount)
		{
			TTVoucherType _VchType = VchType;
			PoNumType _PoNum = PoNum;
			TaxSystemType _TaxSystem = TaxSystem;
			TaxCodeType _TaxCode = TaxCode;
			TaxCodeType _TaxCodeE = TaxCodeE;
			AmountType _AmtTaxBasis = AmtTaxBasis;
			AmountType _AmtTaxAmount = AmtTaxAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TaxDistributionCustUpdSp";
				
				appDB.AddCommandParameter(cmd, "VchType", _VchType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxSystem", _TaxSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode", _TaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCodeE", _TaxCodeE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtTaxBasis", _AmtTaxBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtTaxAmount", _AmtTaxAmount, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
