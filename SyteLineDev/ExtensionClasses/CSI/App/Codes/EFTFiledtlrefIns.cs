//PROJECT NAME: CSICodes
//CLASS NAME: EFTFiledtlrefIns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IEFTFiledtlrefIns
	{
		int EFTFiledtlrefInsSp(decimal? VarBatchId,
		                       decimal? dtlSequence,
		                       string RefType,
		                       string RefObject,
		                       Guid? RefRowPointer,
		                       string VarFileName);
	}
	
	public class EFTFiledtlrefIns : IEFTFiledtlrefIns
	{
		readonly IApplicationDB appDB;
		
		public EFTFiledtlrefIns(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int EFTFiledtlrefInsSp(decimal? VarBatchId,
		                              decimal? dtlSequence,
		                              string RefType,
		                              string RefObject,
		                              Guid? RefRowPointer,
		                              string VarFileName)
		{
			EFTBatchIdType _VarBatchId = VarBatchId;
			SequenceType _dtlSequence = dtlSequence;
			ReferenceType _RefType = RefType;
			ReferenceObjectType _RefObject = RefObject;
			RowPointerType _RefRowPointer = RefRowPointer;
			EFTFileNameType _VarFileName = VarFileName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EFTFiledtlrefInsSp";
				
				appDB.AddCommandParameter(cmd, "VarBatchId", _VarBatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "dtlSequence", _dtlSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefObject", _RefObject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VarFileName", _VarFileName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
