//PROJECT NAME: Logistics
//CLASS NAME: GetNextVchPrStaxSequence.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetNextVchPrStaxSequence : IGetNextVchPrStaxSequence
	{
		readonly IApplicationDB appDB;
		
		
		public GetNextVchPrStaxSequence(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? NextSequenceNum,
		string Infobar) GetNextVchPrStaxSequenceSp(int? PreRegisterNum,
		int? NextSequenceNum,
		string Infobar)
		{
			PreRegisterType _PreRegisterNum = PreRegisterNum;
			StaxSeqType _NextSequenceNum = NextSequenceNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetNextVchPrStaxSequenceSp";
				
				appDB.AddCommandParameter(cmd, "PreRegisterNum", _PreRegisterNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextSequenceNum", _NextSequenceNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextSequenceNum = _NextSequenceNum;
				Infobar = _Infobar;
				
				return (Severity, NextSequenceNum, Infobar);
			}
		}
	}
}
