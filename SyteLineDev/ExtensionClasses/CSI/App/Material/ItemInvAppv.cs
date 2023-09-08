//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemInvAppv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemInvAppv
	{
		DataTable ItemInvAppvSp(string SelectedWhse,
		                        byte? RunMode,
		                        ref int? PhyInvCount,
		                        ref string Infobar);
	}
	
	public class ItemInvAppv : IItemInvAppv
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public ItemInvAppv(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable ItemInvAppvSp(string SelectedWhse,
		                               byte? RunMode,
		                               ref int? PhyInvCount,
		                               ref string Infobar)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				WhseType _SelectedWhse = SelectedWhse;
				FlagNyType _RunMode = RunMode;
				IntType _PhyInvCount = PhyInvCount;
				InfobarType _Infobar = Infobar;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "ItemInvAppvSp";
					
					appDB.AddCommandParameter(cmd, "SelectedWhse", _SelectedWhse, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RunMode", _RunMode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PhyInvCount", _PhyInvCount, ParameterDirection.InputOutput);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                    dtReturn = appDB.ExecuteQuery(cmd);

                    PhyInvCount = _PhyInvCount;
					Infobar = _Infobar;
					
					return dtReturn;
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
