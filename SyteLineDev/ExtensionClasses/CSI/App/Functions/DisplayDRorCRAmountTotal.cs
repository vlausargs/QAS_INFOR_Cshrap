//PROJECT NAME: Data
//CLASS NAME: DisplayDRorCRAmountTotal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayDRorCRAmountTotal : IDisplayDRorCRAmountTotal
	{
		readonly IApplicationDB appDB;
		
		public DisplayDRorCRAmountTotal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? DisplayDRorCRAmountTotalFn(
			decimal? DomDrAmount,
			decimal? DomCrAmount,
			int? IsDR,
			int? pSeperateDRandCRtot)
		{
			AmountType _DomDrAmount = DomDrAmount;
			AmountType _DomCrAmount = DomCrAmount;
			ListYesNoType _IsDR = IsDR;
			ListYesNoType _pSeperateDRandCRtot = pSeperateDRandCRtot;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayDRorCRAmountTotal](@DomDrAmount, @DomCrAmount, @IsDR, @pSeperateDRandCRtot)";
				
				appDB.AddCommandParameter(cmd, "DomDrAmount", _DomDrAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCrAmount", _DomCrAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsDR", _IsDR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSeperateDRandCRtot", _pSeperateDRandCRtot, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
