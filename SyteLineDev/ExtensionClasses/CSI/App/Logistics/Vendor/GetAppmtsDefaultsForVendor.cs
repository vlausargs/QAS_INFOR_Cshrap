//PROJECT NAME: CSIVendor
//CLASS NAME: GetAppmtsDefaultsForVendor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetAppmtsDefaultsForVendor
	{
		int GetAppmtsDefaultsForVendorSp(string PVendNum,
		                                 ref string PVendName,
		                                 ref string PPayType,
		                                 ref int? PCheckNum,
		                                 ref short? PCheckSeq,
		                                 ref DateTime? PCheckDate,
		                                 ref DateTime? PDueDate,
		                                 ref string PCurrCode,
		                                 ref decimal? PExchRate,
		                                 ref decimal? PForCheckAmt,
		                                 ref decimal? PDomCheckAmt,
		                                 ref decimal? PForApplied,
		                                 ref decimal? PDomApplied,
		                                 ref decimal? PForRemaining,
		                                 ref decimal? PDomRemaining,
		                                 ref string PBankCode,
		                                 ref byte? PPayHold,
		                                 ref string PTaxRegNum1,
		                                 ref string PBanCurrCode,
		                                 ref string PInfobar);
	}
	
	public class GetAppmtsDefaultsForVendor : IGetAppmtsDefaultsForVendor
	{
		readonly IApplicationDB appDB;
		
		public GetAppmtsDefaultsForVendor(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetAppmtsDefaultsForVendorSp(string PVendNum,
		                                        ref string PVendName,
		                                        ref string PPayType,
		                                        ref int? PCheckNum,
		                                        ref short? PCheckSeq,
		                                        ref DateTime? PCheckDate,
		                                        ref DateTime? PDueDate,
		                                        ref string PCurrCode,
		                                        ref decimal? PExchRate,
		                                        ref decimal? PForCheckAmt,
		                                        ref decimal? PDomCheckAmt,
		                                        ref decimal? PForApplied,
		                                        ref decimal? PDomApplied,
		                                        ref decimal? PForRemaining,
		                                        ref decimal? PDomRemaining,
		                                        ref string PBankCode,
		                                        ref byte? PPayHold,
		                                        ref string PTaxRegNum1,
		                                        ref string PBanCurrCode,
		                                        ref string PInfobar)
		{
			VendNumType _PVendNum = PVendNum;
			NameType _PVendName = PVendName;
			AppmtPayTypeType _PPayType = PPayType;
			ApCheckNumType _PCheckNum = PCheckNum;
			ApCheckSeqType _PCheckSeq = PCheckSeq;
			DateType _PCheckDate = PCheckDate;
			DateType _PDueDate = PDueDate;
			CurrCodeType _PCurrCode = PCurrCode;
			ExchRateType _PExchRate = PExchRate;
			AmountType _PForCheckAmt = PForCheckAmt;
			AmountType _PDomCheckAmt = PDomCheckAmt;
			AmountType _PForApplied = PForApplied;
			AmountType _PDomApplied = PDomApplied;
			AmountType _PForRemaining = PForRemaining;
			AmountType _PDomRemaining = PDomRemaining;
			BankCodeType _PBankCode = PBankCode;
			ListYesNoType _PPayHold = PPayHold;
			TaxRegNumType _PTaxRegNum1 = PTaxRegNum1;
			CurrCodeType _PBanCurrCode = PBanCurrCode;
			InfobarType _PInfobar = PInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAppmtsDefaultsForVendorSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendName", _PVendName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPayType", _PPayType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCheckSeq", _PCheckSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCheckDate", _PCheckDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PForCheckAmt", _PForCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomCheckAmt", _PDomCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PForApplied", _PForApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomApplied", _PDomApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PForRemaining", _PForRemaining, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomRemaining", _PDomRemaining, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPayHold", _PPayHold, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxRegNum1", _PTaxRegNum1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBanCurrCode", _PBanCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PInfobar", _PInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PVendName = _PVendName;
				PPayType = _PPayType;
				PCheckNum = _PCheckNum;
				PCheckSeq = _PCheckSeq;
				PCheckDate = _PCheckDate;
				PDueDate = _PDueDate;
				PCurrCode = _PCurrCode;
				PExchRate = _PExchRate;
				PForCheckAmt = _PForCheckAmt;
				PDomCheckAmt = _PDomCheckAmt;
				PForApplied = _PForApplied;
				PDomApplied = _PDomApplied;
				PForRemaining = _PForRemaining;
				PDomRemaining = _PDomRemaining;
				PBankCode = _PBankCode;
				PPayHold = _PPayHold;
				PTaxRegNum1 = _PTaxRegNum1;
				PBanCurrCode = _PBanCurrCode;
				PInfobar = _PInfobar;
				
				return Severity;
			}
		}
	}
}
