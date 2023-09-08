//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateSourceCoNumForCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IValidateSourceCoNumForCopy
	{
		int ValidateSourceCoNumForCopySp(string CoNum,
		                                 string OrderType,
		                                 ref short? StartLineNum,
		                                 ref short? EndLineNum,
		                                 ref string Infobar);
	}
	
	public class ValidateSourceCoNumForCopy : IValidateSourceCoNumForCopy
	{
		readonly IApplicationDB appDB;
		
		public ValidateSourceCoNumForCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ValidateSourceCoNumForCopySp(string CoNum,
		                                        string OrderType,
		                                        ref short? StartLineNum,
		                                        ref short? EndLineNum,
		                                        ref string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoTypeType _OrderType = OrderType;
			CoLineType _StartLineNum = StartLineNum;
			CoLineType _EndLineNum = EndLineNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateSourceCoNumForCopySp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLineNum", _StartLineNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndLineNum", _EndLineNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				StartLineNum = _StartLineNum;
				EndLineNum = _EndLineNum;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
