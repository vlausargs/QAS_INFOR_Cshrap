//PROJECT NAME: CSIMaterial
//CLASS NAME: MpsGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IMpsGen
	{
		(int? ReturnCode, string Infobar) MpsGenSp(string FromPlanCode,
		string ToPlanCode,
		string FromItem,
		string ToItem,
		byte? DeleteMrpWb = (byte)0,
		string Infobar = null);
	}
	
	public class MpsGen : IMpsGen
	{
		readonly IApplicationDB appDB;
		
		public MpsGen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MpsGenSp(string FromPlanCode,
		string ToPlanCode,
		string FromItem,
		string ToItem,
		byte? DeleteMrpWb = (byte)0,
		string Infobar = null)
		{
			UserCodeType _FromPlanCode = FromPlanCode;
			UserCodeType _ToPlanCode = ToPlanCode;
			ItemType _FromItem = FromItem;
			ItemType _ToItem = ToItem;
			ListYesNoType _DeleteMrpWb = DeleteMrpWb;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MpsGenSp";
				
				appDB.AddCommandParameter(cmd, "FromPlanCode", _FromPlanCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToPlanCode", _ToPlanCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteMrpWb", _DeleteMrpWb, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
