//PROJECT NAME: Data
//CLASS NAME: DomCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DomCust : IDomCust
	{
		readonly IApplicationDB appDB;
		
		public DomCust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? ExchRate,
			int? FixedRate,
			string Infobar) DomCustSp(
			string CustNum,
			string CurrCode = null,
			decimal? ConvRate = null,
			string TEuroCurr = null,
			decimal? ExchRate = null,
			int? FixedRate = null,
			string Infobar = null)
		{
			CustNumType _CustNum = CustNum;
			CurrCodeType _CurrCode = CurrCode;
			GenericDecimalType _ConvRate = ConvRate;
			CurrCodeType _TEuroCurr = TEuroCurr;
			ExchRateType _ExchRate = ExchRate;
			ListYesNoType _FixedRate = FixedRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DomCustSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvRate", _ConvRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEuroCurr", _TEuroCurr, ParameterDirection.Input);
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
