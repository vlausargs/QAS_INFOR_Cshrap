//PROJECT NAME: Data
//CLASS NAME: EurDom3ConvertTransfers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EurDom3ConvertTransfers : IEurDom3ConvertTransfers
	{
		readonly IApplicationDB appDB;
		
		public EurDom3ConvertTransfers(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EurDom3ConvertTransfersSp(
			decimal? ConvRate,
			int? ConvPlaces,
			string TEuroCurr,
			string OrigCurrCode,
			int? TUseStandard,
			string Infobar)
		{
			GenericDecimalType _ConvRate = ConvRate;
			DecimalPlacesType _ConvPlaces = ConvPlaces;
			CurrCodeType _TEuroCurr = TEuroCurr;
			CurrCodeType _OrigCurrCode = OrigCurrCode;
			FlagNyType _TUseStandard = TUseStandard;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EurDom3ConvertTransfersSp";
				
				appDB.AddCommandParameter(cmd, "ConvRate", _ConvRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvPlaces", _ConvPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEuroCurr", _TEuroCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrigCurrCode", _OrigCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUseStandard", _TUseStandard, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
