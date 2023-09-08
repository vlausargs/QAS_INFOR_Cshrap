//PROJECT NAME: CSIProduct
//CLASS NAME: Ejoblow.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface IEjoblow
	{
		DataTable EjoblowSp(string PList);
	}
	
	public class Ejoblow : IEjoblow
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public Ejoblow(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable EjoblowSp(string PList)
		{
			StringType _PList = PList;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EjoblowSp";
				
				appDB.AddCommandParameter(cmd, "PList", _PList, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
			}
		}
	}
}
