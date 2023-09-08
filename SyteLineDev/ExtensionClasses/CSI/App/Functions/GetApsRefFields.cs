//PROJECT NAME: Data
//CLASS NAME: GetApsRefFields.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetApsRefFields : IGetApsRefFields
	{
		readonly IApplicationDB appDB;
		
		public GetApsRefFields(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRel,
			int? RefSeq) GetApsRefFieldsSp(
			string OrderId,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRel,
			int? RefSeq)
		{
			ApsOrderType _OrderId = OrderId;
			MrpOrderTypeType _RefType = RefType;
			ApsOrderType _RefNum = RefNum;
			MrpOrderLineType _RefLineSuf = RefLineSuf;
			UnknownRefReleaseType _RefRel = RefRel;
			JobmatlSequenceType _RefSeq = RefSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetApsRefFieldsSp";
				
				appDB.AddCommandParameter(cmd, "OrderId", _OrderId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefRel", _RefRel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefSeq", _RefSeq, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RefType = _RefType;
				RefNum = _RefNum;
				RefLineSuf = _RefLineSuf;
				RefRel = _RefRel;
				RefSeq = _RefSeq;
				
				return (Severity, RefType, RefNum, RefLineSuf, RefRel, RefSeq);
			}
		}
	}
}
