//PROJECT NAME: CSICodes
//CLASS NAME: CLM_LoadInlineList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface ICLM_LoadInlineList
	{
		DataTable CLM_LoadInlineListSp(string ObjectName,
		                               string Attribute);
	}
	
	public class CLM_LoadInlineList : ICLM_LoadInlineList
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public CLM_LoadInlineList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable CLM_LoadInlineListSp(string ObjectName,
		                                      string Attribute)
		{
			DimensionObjectType _ObjectName = ObjectName;
			DimensionAttributeType _Attribute = Attribute;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_LoadInlineListSp";
				
				appDB.AddCommandParameter(cmd, "ObjectName", _ObjectName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Attribute", _Attribute, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
			}
		}
	}
}
