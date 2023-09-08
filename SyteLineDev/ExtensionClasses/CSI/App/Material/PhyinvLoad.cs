//PROJECT NAME: CSIMaterial
//CLASS NAME: PhyinvLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IPhyinvLoad
	{
		DataTable PhyinvLoadSp(string Process,
		                       string CountMethod,
		                       string Whse,
		                       byte? ListOpts,
		                       ref string Infobar);
	}
	
	public class PhyinvLoad : IPhyinvLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public PhyinvLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable PhyinvLoadSp(string Process,
		                              string CountMethod,
		                              string Whse,
		                              byte? ListOpts,
		                              ref string Infobar)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				StringType _Process = Process;
				PhytagsCountMethType _CountMethod = CountMethod;
				WhseType _Whse = Whse;
				ListYesNoType _ListOpts = ListOpts;
				InfobarType _Infobar = Infobar;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "PhyinvLoadSp";
					
					appDB.AddCommandParameter(cmd, "Process", _Process, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CountMethod", _CountMethod, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ListOpts", _ListOpts, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                    dtReturn = appDB.ExecuteQuery(cmd);

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
