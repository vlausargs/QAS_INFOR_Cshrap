//PROJECT NAME: CSIProjects
//CLASS NAME: GetECVatValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IGetECVatValues
	{
		int GetECVatValuesSp(string ProjNum,
		                     ref string TransNat,
		                     ref string TransNat2,
		                     ref string Delterm,
		                     ref string ProcessInd);
	}
	
	public class GetECVatValues : IGetECVatValues
	{
		readonly IApplicationDB appDB;
		
		public GetECVatValues(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetECVatValuesSp(string ProjNum,
		                            ref string TransNat,
		                            ref string TransNat2,
		                            ref string Delterm,
		                            ref string ProcessInd)
		{
			ProjNumType _ProjNum = ProjNum;
			TransNatType _TransNat = TransNat;
			TransNat2Type _TransNat2 = TransNat2;
			DeltermType _Delterm = Delterm;
			ProcessIndType _ProcessInd = ProcessInd;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetECVatValuesSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNat2", _TransNat2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Delterm", _Delterm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProcessInd", _ProcessInd, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TransNat = _TransNat;
				TransNat2 = _TransNat2;
				Delterm = _Delterm;
				ProcessInd = _ProcessInd;
				
				return Severity;
			}
		}
	}
}
