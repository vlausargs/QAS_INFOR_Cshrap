//PROJECT NAME: Finance
//CLASS NAME: B2Arpmtd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class B2Arpmtd : IB2Arpmtd
	{
		readonly IApplicationDB appDB;
		
		public B2Arpmtd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? POpenBal,
			int? PFixedRate) B2ArpmtdSp(
			Guid? PRecid,
			decimal? POpenBal,
			int? PFixedRate)
		{
			RowPointerType _PRecid = PRecid;
			AmountType _POpenBal = POpenBal;
			ListYesNoType _PFixedRate = PFixedRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "B2ArpmtdSp";
				
				appDB.AddCommandParameter(cmd, "PRecid", _PRecid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POpenBal", _POpenBal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFixedRate", _PFixedRate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				POpenBal = _POpenBal;
				PFixedRate = _PFixedRate;
				
				return (Severity, POpenBal, PFixedRate);
			}
		}
	}
}
