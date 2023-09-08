//PROJECT NAME: Production
//CLASS NAME: FormulaTermValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class FormulaTermValidate : IFormulaTermValidate
	{
		readonly IApplicationDB appDB;
		
		
		public FormulaTermValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) FormulaTermValidateSp(string PropertyName,
		string CollectionName,
		string OperationType = null,
		int? IncludeKeySequence = 0,
		string Infobar = null)
		{
			StringType _PropertyName = PropertyName;
			StringType _CollectionName = CollectionName;
			PP_OperationType2Type _OperationType = OperationType;
			ListYesNoType _IncludeKeySequence = IncludeKeySequence;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FormulaTermValidateSp";
				
				appDB.AddCommandParameter(cmd, "PropertyName", _PropertyName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CollectionName", _CollectionName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperationType", _OperationType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeKeySequence", _IncludeKeySequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
