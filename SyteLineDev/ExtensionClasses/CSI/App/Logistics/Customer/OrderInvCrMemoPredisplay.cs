//PROJECT NAME: CSICustomer
//CLASS NAME: OrderInvCrMemoPredisplay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IOrderInvCrMemoPredisplay
	{
		int OrderInvCrMemoPredisplaySp(decimal? Userid,
		                               ref byte? IsUserInReprintGroup,
		                               ref byte? FRCP,
		                               ref int? Result,
		                               ref string Infobar,
		                               ref byte? PArparmUsePrePrintedForms,
		                               ref short? PArparmLinesPerInv,
		                               ref short? PArparmLinesPerDM,
		                               ref short? PArparmLinesPerCM);
	}
	
	public class OrderInvCrMemoPredisplay : IOrderInvCrMemoPredisplay
	{
		readonly IApplicationDB appDB;
		
		public OrderInvCrMemoPredisplay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int OrderInvCrMemoPredisplaySp(decimal? Userid,
		                                      ref byte? IsUserInReprintGroup,
		                                      ref byte? FRCP,
		                                      ref int? Result,
		                                      ref string Infobar,
		                                      ref byte? PArparmUsePrePrintedForms,
		                                      ref short? PArparmLinesPerInv,
		                                      ref short? PArparmLinesPerDM,
		                                      ref short? PArparmLinesPerCM)
		{
			TokenType _Userid = Userid;
			FlagNyType _IsUserInReprintGroup = IsUserInReprintGroup;
			ListYesNoType _FRCP = FRCP;
			IntType _Result = Result;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PArparmUsePrePrintedForms = PArparmUsePrePrintedForms;
			LinesPerDocType _PArparmLinesPerInv = PArparmLinesPerInv;
			LinesPerDocType _PArparmLinesPerDM = PArparmLinesPerDM;
			LinesPerDocType _PArparmLinesPerCM = PArparmLinesPerCM;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "OrderInvCrMemoPredisplaySp";
				
				appDB.AddCommandParameter(cmd, "Userid", _Userid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsUserInReprintGroup", _IsUserInReprintGroup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FRCP", _FRCP, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Result", _Result, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArparmUsePrePrintedForms", _PArparmUsePrePrintedForms, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArparmLinesPerInv", _PArparmLinesPerInv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArparmLinesPerDM", _PArparmLinesPerDM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArparmLinesPerCM", _PArparmLinesPerCM, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				IsUserInReprintGroup = _IsUserInReprintGroup;
				FRCP = _FRCP;
				Result = _Result;
				Infobar = _Infobar;
				PArparmUsePrePrintedForms = _PArparmUsePrePrintedForms;
				PArparmLinesPerInv = _PArparmLinesPerInv;
				PArparmLinesPerDM = _PArparmLinesPerDM;
				PArparmLinesPerCM = _PArparmLinesPerCM;
				
				return Severity;
			}
		}
	}
}
