//PROJECT NAME: Data
//CLASS NAME: ConvertInvoiceNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConvertInvoiceNum : IConvertInvoiceNum
	{
		readonly IApplicationDB appDB;
		
		public ConvertInvoiceNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ConvertInvoiceNumSp(
			int? InvLength,
			string Infobar)
		{
			InvNumLength _InvLength = InvLength;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ConvertInvoiceNumSp";
				
				appDB.AddCommandParameter(cmd, "InvLength", _InvLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
