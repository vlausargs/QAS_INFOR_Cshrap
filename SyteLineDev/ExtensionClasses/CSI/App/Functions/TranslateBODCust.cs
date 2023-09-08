//PROJECT NAME: Data
//CLASS NAME: TranslateBODCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TranslateBODCust : ITranslateBODCust
	{
		readonly IApplicationDB appDB;
		
		public TranslateBODCust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CustNum,
			int? CustSeq,
			string Infobar) TranslateBODCustSp(
			string CustomerID,
			string CustNum,
			int? CustSeq,
			string Infobar)
		{
			StringType _CustomerID = CustomerID;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TranslateBODCustSp";
				
				appDB.AddCommandParameter(cmd, "CustomerID", _CustomerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustNum = _CustNum;
				CustSeq = _CustSeq;
				Infobar = _Infobar;
				
				return (Severity, CustNum, CustSeq, Infobar);
			}
		}
	}
}
