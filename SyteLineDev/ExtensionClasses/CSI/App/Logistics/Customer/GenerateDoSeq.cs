//PROJECT NAME: Logistics
//CLASS NAME: GenerateDoSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateDoSeq : IGenerateDoSeq
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateDoSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ErrorMessage) GenerateDoSeqSp(string DoNum,
		int? DoLine,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		DateTime? CoShipDate,
		int? CoDateSeq,
		string ErrorMessage)
		{
			DoNumType _DoNum = DoNum;
			CoLineType _DoLine = DoLine;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoLineType _CoRelease = CoRelease;
			DateTimeType _CoShipDate = CoShipDate;
			IntType _CoDateSeq = CoDateSeq;
			InfobarType _ErrorMessage = ErrorMessage;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateDoSeqSp";
				
				appDB.AddCommandParameter(cmd, "DoNum", _DoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoLine", _DoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoShipDate", _CoShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoDateSeq", _CoDateSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorMessage", _ErrorMessage, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ErrorMessage = _ErrorMessage;
				
				return (Severity, ErrorMessage);
			}
		}
	}
}
