//PROJECT NAME: Logistics
//CLASS NAME: SSSFSTaxInvStaxCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSTaxInvStaxCreate : ISSSFSTaxInvStaxCreate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSTaxInvStaxCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSTaxInvStaxCreateSp(
			string InvNum,
			int? InvSeq,
			DateTime? InvDate,
			string CustNum,
			int? CustSeq)
		{
			InvNumType _InvNum = InvNum;
			InvSeqType _InvSeq = InvSeq;
			DateType _InvDate = InvDate;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSTaxInvStaxCreateSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
