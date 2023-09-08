//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_VoidDirectDebit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_VoidDirectDebit
	{
		DataTable CLM_VoidDirectDebitSp(int? pStartDirectDebitNum,
		                                int? pEndDirectDebitNum,
		                                ref string Infobar);
	}
	
	public class CLM_VoidDirectDebit : ICLM_VoidDirectDebit
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public CLM_VoidDirectDebit(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable CLM_VoidDirectDebitSp(int? pStartDirectDebitNum,
		                                       int? pEndDirectDebitNum,
		                                       ref string Infobar)
		{
			DirectDebitNumType _pStartDirectDebitNum = pStartDirectDebitNum;
			DirectDebitNumType _pEndDirectDebitNum = pEndDirectDebitNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_VoidDirectDebitSp";
				
				appDB.AddCommandParameter(cmd, "pStartDirectDebitNum", _pStartDirectDebitNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDirectDebitNum", _pEndDirectDebitNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;
				
				return dtReturn;
			}
		}
	}
}
