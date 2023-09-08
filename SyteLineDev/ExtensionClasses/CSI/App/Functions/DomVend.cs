//PROJECT NAME: Data
//CLASS NAME: DomVend.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DomVend : IDomVend
	{
		readonly IApplicationDB appDB;
		
		public DomVend(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? ExchRate,
			int? FixedRate,
			string Infobar) DomVendSp(
			string VendNum,
			string CurrCode = null,
			decimal? ConvRate = null,
			string TEuroCurr = null,
			int? IncludeRcpt = null,
			string RcptPoNum = null,
			decimal? ExchRate = null,
			int? FixedRate = null,
			string Infobar = null)
		{
			VendNumType _VendNum = VendNum;
			CurrCodeType _CurrCode = CurrCode;
			GenericDecimalType _ConvRate = ConvRate;
			CurrCodeType _TEuroCurr = TEuroCurr;
			Flag _IncludeRcpt = IncludeRcpt;
			PoNumType _RcptPoNum = RcptPoNum;
			ExchRateType _ExchRate = ExchRate;
			ListYesNoType _FixedRate = FixedRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DomVendSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvRate", _ConvRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEuroCurr", _TEuroCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeRcpt", _IncludeRcpt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RcptPoNum", _RcptPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FixedRate", _FixedRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExchRate = _ExchRate;
				FixedRate = _FixedRate;
				Infobar = _Infobar;
				
				return (Severity, ExchRate, FixedRate, Infobar);
			}
		}
	}
}
