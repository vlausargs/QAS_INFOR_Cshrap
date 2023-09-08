//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemInvFrez.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemInvFrez
	{
		int ItemInvFrezSp(string SelectedWhse,
		                  byte? PhyInvFlag,
		                  ref int? ItemwhseCount,
		                  ref string Infobar);
	}
	
	public class ItemInvFrez : IItemInvFrez
	{
		readonly IApplicationDB appDB;
		
		public ItemInvFrez(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ItemInvFrezSp(string SelectedWhse,
		                         byte? PhyInvFlag,
		                         ref int? ItemwhseCount,
		                         ref string Infobar)
		{
			WhseType _SelectedWhse = SelectedWhse;
			ListYesNoType _PhyInvFlag = PhyInvFlag;
			IntType _ItemwhseCount = ItemwhseCount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemInvFrezSp";
				
				appDB.AddCommandParameter(cmd, "SelectedWhse", _SelectedWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhyInvFlag", _PhyInvFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemwhseCount", _ItemwhseCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemwhseCount = _ItemwhseCount;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
