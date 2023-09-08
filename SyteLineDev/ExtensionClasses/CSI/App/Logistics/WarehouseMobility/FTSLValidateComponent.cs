//PROJECT NAME: Logistics
//CLASS NAME: FTSLValidateComponent.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateComponent
	{
		(int? ReturnCode, string Infobar) FTSLValidateComponentSp(string ValidateObject,
		string Job,
		short? Suffix,
		int? Oper,
		string Infobar = null);
	}
	
	public class FTSLValidateComponent : IFTSLValidateComponent
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateComponent(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) FTSLValidateComponentSp(string ValidateObject,
		string Job,
		short? Suffix,
		int? Oper,
		string Infobar = null)
		{
			JobType _ValidateObject = ValidateObject;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _Oper = Oper;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateComponentSp";
				
				appDB.AddCommandParameter(cmd, "ValidateObject", _ValidateObject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Oper", _Oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
