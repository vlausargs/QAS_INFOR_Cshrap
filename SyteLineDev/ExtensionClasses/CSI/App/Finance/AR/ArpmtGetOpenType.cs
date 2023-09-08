//PROJECT NAME: Finance
//CLASS NAME: ArpmtGetOpenType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArpmtGetOpenType : IArpmtGetOpenType
	{
		readonly IApplicationDB appDB;
		
		public ArpmtGetOpenType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string POpenType,
			string POpenCode,
			decimal? PForCheckAmt,
			decimal? PExchRate,
			string PBankCode,
			string Infobar,
			string POpenCurrCode) ArpmtGetOpenTypeSp(
			string PCustNum,
			int? PCheckNum,
			string POpenType,
			string POpenCode,
			decimal? PForCheckAmt,
			decimal? PExchRate,
			string PBankCode,
			string Infobar,
			string PCreditMemoNum = null,
			string POpenCurrCode = null)
		{
			CustNumType _PCustNum = PCustNum;
			ArCheckNumType _PCheckNum = PCheckNum;
			LongListType _POpenType = POpenType;
			LongListType _POpenCode = POpenCode;
			AmountType _PForCheckAmt = PForCheckAmt;
			ExchRateType _PExchRate = PExchRate;
			BankCodeType _PBankCode = PBankCode;
			InfobarType _Infobar = Infobar;
			InvNumType _PCreditMemoNum = PCreditMemoNum;
			CurrCodeType _POpenCurrCode = POpenCurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtGetOpenTypeSp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POpenType", _POpenType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POpenCode", _POpenCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PForCheckAmt", _PForCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCreditMemoNum", _PCreditMemoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POpenCurrCode", _POpenCurrCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				POpenType = _POpenType;
				POpenCode = _POpenCode;
				PForCheckAmt = _PForCheckAmt;
				PExchRate = _PExchRate;
				PBankCode = _PBankCode;
				Infobar = _Infobar;
				POpenCurrCode = _POpenCurrCode;
				
				return (Severity, POpenType, POpenCode, PForCheckAmt, PExchRate, PBankCode, Infobar, POpenCurrCode);
			}
		}
		public string ArpmtGetOpenTypeFn(
			string PCustNum,
			int? PCheckNum)
		{
			CustNumType _PCustNum = PCustNum;
			ArCheckNumType _PCheckNum = PCheckNum;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ArpmtGetOpenType](@PCustNum, @PCheckNum)";

				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}

	}
}
