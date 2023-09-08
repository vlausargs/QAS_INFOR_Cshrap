//PROJECT NAME: Data
//CLASS NAME: ValidateJobOrdersXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValidateJobOrdersXref : IValidateJobOrdersXref
	{
		readonly IApplicationDB appDB;
		
		public ValidateJobOrdersXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ValidateJobOrdersXrefSp(
			string POrdType,
			string POrdNum,
			int? POrdLine,
			int? POrdRelease,
			string Infobar)
		{
			RefTypeIKOTType _POrdType = POrdType;
			CoProjTrnNumType _POrdNum = POrdNum;
			CoProjTaskTrnLineType _POrdLine = POrdLine;
			CoReleaseType _POrdRelease = POrdRelease;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateJobOrdersXrefSp";
				
				appDB.AddCommandParameter(cmd, "POrdType", _POrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrdNum", _POrdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrdLine", _POrdLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrdRelease", _POrdRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
