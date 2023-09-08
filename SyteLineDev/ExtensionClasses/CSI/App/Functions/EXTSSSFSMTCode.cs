//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSMTCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSMTCode : IEXTSSSFSMTCode
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSMTCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string TDtype,
			string TDto,
			string TDfrom) EXTSSSFSMTCodeSp(
			string MatltranTransType,
			string MatltranRefType,
			string TDref,
			string TDtype,
			string TDto,
			string TDfrom)
		{
			MatlTransTypeType _MatltranTransType = MatltranTransType;
			RefTypeIJKOPRSTWType _MatltranRefType = MatltranRefType;
			LongListType _TDref = TDref;
			LongListType _TDtype = TDtype;
			LongListType _TDto = TDto;
			LongListType _TDfrom = TDfrom;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSMTCodeSp";
				
				appDB.AddCommandParameter(cmd, "MatltranTransType", _MatltranTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatltranRefType", _MatltranRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDref", _TDref, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDtype", _TDtype, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDto", _TDto, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDfrom", _TDfrom, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TDtype = _TDtype;
				TDto = _TDto;
				TDfrom = _TDfrom;
				
				return (Severity, TDtype, TDto, TDfrom);
			}
		}
	}
}
