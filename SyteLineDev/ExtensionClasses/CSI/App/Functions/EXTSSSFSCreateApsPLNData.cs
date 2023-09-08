//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSCreateApsPLNData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSCreateApsPLNData : IEXTSSSFSCreateApsPLNData
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSCreateApsPLNData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string pRefType,
			string pRefNum,
			int? pRefLineSuf,
			int? pRefRel,
			int? pRefSeq,
			string pTopReference) EXTSSSFSCreateApsPLNDataSp(
			string pOrderId,
			string pRefType,
			string pRefNum,
			int? pRefLineSuf,
			int? pRefRel,
			int? pRefSeq,
			string pTopReference)
		{
			ApsOrderType _pOrderId = pOrderId;
			MrpOrderTypeType _pRefType = pRefType;
			ApsOrderType _pRefNum = pRefNum;
			MrpOrderLineType _pRefLineSuf = pRefLineSuf;
			UnknownRefReleaseType _pRefRel = pRefRel;
			JobmatlSequenceType _pRefSeq = pRefSeq;
			MediumDescType _pTopReference = pTopReference;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSCreateApsPLNDataSp";
				
				appDB.AddCommandParameter(cmd, "pOrderId", _pOrderId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRefType", _pRefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pRefNum", _pRefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pRefLineSuf", _pRefLineSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pRefRel", _pRefRel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pRefSeq", _pRefSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pTopReference", _pTopReference, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pRefType = _pRefType;
				pRefNum = _pRefNum;
				pRefLineSuf = _pRefLineSuf;
				pRefRel = _pRefRel;
				pRefSeq = _pRefSeq;
				pTopReference = _pTopReference;
				
				return (Severity, pRefType, pRefNum, pRefLineSuf, pRefRel, pRefSeq, pTopReference);
			}
		}
	}
}
