//PROJECT NAME: Data
//CLASS NAME: NextBuilderInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextBuilderInvoice : INextBuilderInvoice
	{
		readonly IApplicationDB appDB;
		
		public NextBuilderInvoice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string NewBuilderInvoiceNum,
			string Infobar) NextBuilderInvoiceSp(
			string NewBuilderInvoiceNum,
			string Infobar)
		{
			BuilderInvNumType _NewBuilderInvoiceNum = NewBuilderInvoiceNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NextBuilderInvoiceSp";
				
				appDB.AddCommandParameter(cmd, "NewBuilderInvoiceNum", _NewBuilderInvoiceNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewBuilderInvoiceNum = _NewBuilderInvoiceNum;
				Infobar = _Infobar;
				
				return (Severity, NewBuilderInvoiceNum, Infobar);
			}
		}
	}
}
