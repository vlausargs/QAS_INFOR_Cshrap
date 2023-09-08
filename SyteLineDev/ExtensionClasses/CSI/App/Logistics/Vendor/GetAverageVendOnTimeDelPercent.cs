//PROJECT NAME: Logistics
//CLASS NAME: GetAverageVendOnTimeDelPercent.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetAverageVendOnTimeDelPercent : IGetAverageVendOnTimeDelPercent
	{
		readonly IApplicationDB appDB;
		
		
		public GetAverageVendOnTimeDelPercent(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? pAverageOnTimeDelPercent) GetAverageVendOnTimeDelPercentSp(string pVendNum,
		int? pNumberOfMonths,
		decimal? pAverageOnTimeDelPercent)
		{
			VendNumType _pVendNum = pVendNum;
			ShortType _pNumberOfMonths = pNumberOfMonths;
			DecimalType _pAverageOnTimeDelPercent = pAverageOnTimeDelPercent;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAverageVendOnTimeDelPercentSp";
				
				appDB.AddCommandParameter(cmd, "pVendNum", _pVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNumberOfMonths", _pNumberOfMonths, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAverageOnTimeDelPercent", _pAverageOnTimeDelPercent, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pAverageOnTimeDelPercent = _pAverageOnTimeDelPercent;
				
				return (Severity, pAverageOnTimeDelPercent);
			}
		}
		public decimal? GetAverageVendOnTimeDelPercentFn(
			string VendNum,
			int? NumberOfMonths)
		{
			VendNumType _VendNum = VendNum;
			ShortType _NumberOfMonths = NumberOfMonths;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetAverageVendOnTimeDelPercent](@VendNum, @NumberOfMonths)";

				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumberOfMonths", _NumberOfMonths, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<decimal?>(cmd);

				return Output;
			}
		}

	}
}
