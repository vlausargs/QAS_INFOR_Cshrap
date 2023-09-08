//PROJECT NAME: Data
//CLASS NAME: InitModuleSERVICEMANAGEMENTLITE.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleSERVICEMANAGEMENTLITE : IInitModuleSERVICEMANAGEMENTLITE
	{
		readonly IApplicationDB appDB;
		
		public InitModuleSERVICEMANAGEMENTLITE(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleSERVICEMANAGEMENTLITESp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleSERVICEMANAGEMENTLITESp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
