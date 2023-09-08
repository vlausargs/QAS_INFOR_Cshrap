//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROSSDDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROSSDDefaults
	{
		(int? ReturnCode, string EcCode, string TransNat, string TransNatDesc, string Delterm, string DeltermDesc, string ProcessInd) SSSFSSROSSDDefaultsSp(string SRONum = null,
		string TransType = null,
		string DropType = null,
		string DropNum = null,
		int? DropSeq = null,
		string EcCode = null,
		string TransNat = null,
		string TransNatDesc = null,
		string Delterm = null,
		string DeltermDesc = null,
		string ProcessInd = null);
	}
	
	public class SSSFSSROSSDDefaults : ISSSFSSROSSDDefaults
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROSSDDefaults(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string EcCode, string TransNat, string TransNatDesc, string Delterm, string DeltermDesc, string ProcessInd) SSSFSSROSSDDefaultsSp(string SRONum = null,
		string TransType = null,
		string DropType = null,
		string DropNum = null,
		int? DropSeq = null,
		string EcCode = null,
		string TransNat = null,
		string TransNatDesc = null,
		string Delterm = null,
		string DeltermDesc = null,
		string ProcessInd = null)
		{
			FSSRONumType _SRONum = SRONum;
			FSSROMatlTransTypeType _TransType = TransType;
			FSDropShipTypeType _DropType = DropType;
			FSPartnerType _DropNum = DropNum;
			DropSeqType _DropSeq = DropSeq;
			EcCodeType _EcCode = EcCode;
			TransNatType _TransNat = TransNat;
			DescriptionType _TransNatDesc = TransNatDesc;
			DeltermType _Delterm = Delterm;
			DescriptionType _DeltermDesc = DeltermDesc;
			ProcessIndType _ProcessInd = ProcessInd;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROSSDDefaultsSp";
				
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropType", _DropType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropNum", _DropNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropSeq", _DropSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EcCode", _EcCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNatDesc", _TransNatDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Delterm", _Delterm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DeltermDesc", _DeltermDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProcessInd", _ProcessInd, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EcCode = _EcCode;
				TransNat = _TransNat;
				TransNatDesc = _TransNatDesc;
				Delterm = _Delterm;
				DeltermDesc = _DeltermDesc;
				ProcessInd = _ProcessInd;
				
				return (Severity, EcCode, TransNat, TransNatDesc, Delterm, DeltermDesc, ProcessInd);
			}
		}
	}
}
