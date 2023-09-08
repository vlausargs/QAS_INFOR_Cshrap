//PROJECT NAME: CSIProjects
//CLASS NAME: UpdateAutoNominateInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IUpdateAutoNominateInvoice
	{
		int UpdateAutoNominateInvoiceSp(ref byte? AutoNominateInvoice);
	}
	
	public class UpdateAutoNominateInvoice : IUpdateAutoNominateInvoice
	{
		readonly IApplicationDB appDB;
		
		public UpdateAutoNominateInvoice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int UpdateAutoNominateInvoiceSp(ref byte? AutoNominateInvoice)
		{
			ListYesNoType _AutoNominateInvoice = AutoNominateInvoice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateAutoNominateInvoiceSp";
				
				appDB.AddCommandParameter(cmd, "AutoNominateInvoice", _AutoNominateInvoice, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AutoNominateInvoice = _AutoNominateInvoice;
				
				return Severity;
			}
		}
	}
}
