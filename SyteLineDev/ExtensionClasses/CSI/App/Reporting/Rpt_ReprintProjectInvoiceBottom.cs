//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ReprintProjectInvoiceBottom.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ReprintProjectInvoiceBottom : IRpt_ReprintProjectInvoiceBottom
	{
		readonly IApplicationDB appDB;
		
		public Rpt_ReprintProjectInvoiceBottom(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_ReprintProjectInvoiceBottomSp(
			string InvNum,
			int? TransDomCurr,
			int? PrintProjectNotes,
			int? PrintStandardNotes,
			int? ShowInternal = 1,
			int? ShowExternal = 1)
		{
			InvNumType _InvNum = InvNum;
			ListYesNoType _TransDomCurr = TransDomCurr;
			ListYesNoType _PrintProjectNotes = PrintProjectNotes;
			ListYesNoType _PrintStandardNotes = PrintStandardNotes;
			ListYesNoType _ShowInternal = ShowInternal;
			ListYesNoType _ShowExternal = ShowExternal;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ReprintProjectInvoiceBottomSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintProjectNotes", _PrintProjectNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintStandardNotes", _PrintStandardNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
