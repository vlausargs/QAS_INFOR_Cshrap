//PROJECT NAME: Data
//CLASS NAME: InitModuleSERVICEMANAGEMENT_MS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleSERVICEMANAGEMENT_MS : IInitModuleSERVICEMANAGEMENT_MS
	{
		readonly IApplicationDB appDB;
		
		public InitModuleSERVICEMANAGEMENT_MS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleSERVICEMANAGEMENT_MSSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleSERVICEMANAGEMENT_MSSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
