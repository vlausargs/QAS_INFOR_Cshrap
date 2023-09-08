//PROJECT NAME: CSICustomer
//CLASS NAME: MoveLocalCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IMoveLocalCust
	{
		(int? ReturnCode, string Infobar) MoveLocalCustSp(string POldCustNum,
		int? POldCustSeq,
		string PNewCustNum,
		int? PNewCustSeq,
		string Infobar = null);
	}
	
	public class MoveLocalCust : IMoveLocalCust
	{
		readonly IApplicationDB appDB;
		
		public MoveLocalCust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MoveLocalCustSp(string POldCustNum,
		int? POldCustSeq,
		string PNewCustNum,
		int? PNewCustSeq,
		string Infobar = null)
		{
			CustNumType _POldCustNum = POldCustNum;
			CustSeqType _POldCustSeq = POldCustSeq;
			CustNumType _PNewCustNum = PNewCustNum;
			CustSeqType _PNewCustSeq = PNewCustSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MoveLocalCustSp";
				
				appDB.AddCommandParameter(cmd, "POldCustNum", _POldCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldCustSeq", _POldCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewCustNum", _PNewCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewCustSeq", _PNewCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
