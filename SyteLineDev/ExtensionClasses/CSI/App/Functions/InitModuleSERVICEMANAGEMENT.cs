//PROJECT NAME: Data
//CLASS NAME: InitModuleSERVICEMANAGEMENT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleSERVICEMANAGEMENT : IInitModuleSERVICEMANAGEMENT
	{
		readonly IApplicationDB appDB;
		
		public InitModuleSERVICEMANAGEMENT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleSERVICEMANAGEMENTSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleSERVICEMANAGEMENTSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
