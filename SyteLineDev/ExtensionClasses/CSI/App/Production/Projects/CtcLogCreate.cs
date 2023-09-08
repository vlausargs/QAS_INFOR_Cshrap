//PROJECT NAME: Production
//CLASS NAME: CtcLogCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class CtcLogCreate : ICtcLogCreate
	{
		readonly IApplicationDB appDB;
		
		
		public CtcLogCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CtcLogCreateSp(string FromProjNum,
		string ToProjNum,
		int? FromTaskNum,
		int? ToTaskNum,
		string FromCostCode,
		string ToCostCode,
		string Infobar)
		{
			HighLowCharType _FromProjNum = FromProjNum;
			HighLowCharType _ToProjNum = ToProjNum;
			GenericIntType _FromTaskNum = FromTaskNum;
			GenericIntType _ToTaskNum = ToTaskNum;
			HighLowCharType _FromCostCode = FromCostCode;
			HighLowCharType _ToCostCode = ToCostCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CtcLogCreateSp";
				
				appDB.AddCommandParameter(cmd, "FromProjNum", _FromProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToProjNum", _ToProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTaskNum", _FromTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTaskNum", _ToTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCostCode", _FromCostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCostCode", _ToCostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
