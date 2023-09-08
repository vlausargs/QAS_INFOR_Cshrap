//PROJECT NAME: CSIProjects
//CLASS NAME: CLM_RevMsNom.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface ICLM_RevMsNom
	{
		DataTable CLM_RevMsNomSp(DateTime? PActDate,
		                         DateTime? PPlanDate,
		                         string Filter);
	}
	
	public class CLM_RevMsNom : ICLM_RevMsNom
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public CLM_RevMsNom(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable CLM_RevMsNomSp(DateTime? PActDate,
		                                DateTime? PPlanDate,
		                                string Filter)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				DateType _PActDate = PActDate;
				DateType _PPlanDate = PPlanDate;
				LongListType _Filter = Filter;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_RevMsNomSp";
					
					appDB.AddCommandParameter(cmd, "PActDate", _PActDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PPlanDate", _PPlanDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Filter", _Filter, ParameterDirection.Input);

                    dtReturn = appDB.ExecuteQuery(cmd);

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
