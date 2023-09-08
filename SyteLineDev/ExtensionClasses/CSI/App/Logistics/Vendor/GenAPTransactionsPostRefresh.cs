//PROJECT NAME: CSIVendor
//CLASS NAME: GenAPTransactionsPostRefresh.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGenAPTransactionsPostRefresh
	{
		int GenAPTransactionsPostRefreshSp(string PVendNum,
		                                   string PVendInvNum,
		                                   string PPoNum,
		                                   byte? PEdiFlag,
		                                   ref byte? PFixedRate,
		                                   ref decimal? PExchRate,
		                                   ref string PTermsCode,
		                                   ref string PTermsCodeDescription,
		                                   ref string PAuthorizer,
		                                   ref short? PSeqNum,
		                                   ref decimal? PFreight,
		                                   ref decimal? PMiscCharges,
		                                   ref decimal? PSalesTax,
		                                   ref DateTime? PInvDate,
		                                   ref string PInvNum);
	}
	
	public class GenAPTransactionsPostRefresh : IGenAPTransactionsPostRefresh
	{
		readonly IApplicationDB appDB;
		
		public GenAPTransactionsPostRefresh(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GenAPTransactionsPostRefreshSp(string PVendNum,
		                                          string PVendInvNum,
		                                          string PPoNum,
		                                          byte? PEdiFlag,
		                                          ref byte? PFixedRate,
		                                          ref decimal? PExchRate,
		                                          ref string PTermsCode,
		                                          ref string PTermsCodeDescription,
		                                          ref string PAuthorizer,
		                                          ref short? PSeqNum,
		                                          ref decimal? PFreight,
		                                          ref decimal? PMiscCharges,
		                                          ref decimal? PSalesTax,
		                                          ref DateTime? PInvDate,
		                                          ref string PInvNum)
		{
			VendNumType _PVendNum = PVendNum;
			VendInvNumType _PVendInvNum = PVendInvNum;
			PoNumType _PPoNum = PPoNum;
			FlagNyType _PEdiFlag = PEdiFlag;
			ListYesNoType _PFixedRate = PFixedRate;
			ExchRateType _PExchRate = PExchRate;
			TermsCodeType _PTermsCode = PTermsCode;
			DescriptionType _PTermsCodeDescription = PTermsCodeDescription;
			UsernameType _PAuthorizer = PAuthorizer;
			EdiSeqType _PSeqNum = PSeqNum;
			AmountType _PFreight = PFreight;
			AmountType _PMiscCharges = PMiscCharges;
			AmountType _PSalesTax = PSalesTax;
			DateType _PInvDate = PInvDate;
			VendInvNumType _PInvNum = PInvNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenAPTransactionsPostRefreshSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendInvNum", _PVendInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEdiFlag", _PEdiFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFixedRate", _PFixedRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTermsCode", _PTermsCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTermsCodeDescription", _PTermsCodeDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAuthorizer", _PAuthorizer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSeqNum", _PSeqNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFreight", _PFreight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMiscCharges", _PMiscCharges, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSalesTax", _PSalesTax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PFixedRate = _PFixedRate;
				PExchRate = _PExchRate;
				PTermsCode = _PTermsCode;
				PTermsCodeDescription = _PTermsCodeDescription;
				PAuthorizer = _PAuthorizer;
				PSeqNum = _PSeqNum;
				PFreight = _PFreight;
				PMiscCharges = _PMiscCharges;
				PSalesTax = _PSalesTax;
				PInvDate = _PInvDate;
				PInvNum = _PInvNum;
				
				return Severity;
			}
		}
	}
}
