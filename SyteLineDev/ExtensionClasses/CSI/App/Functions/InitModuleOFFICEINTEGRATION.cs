//PROJECT NAME: Data
//CLASS NAME: InitModuleOFFICEINTEGRATION.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleOFFICEINTEGRATION : IInitModuleOFFICEINTEGRATION
	{
		readonly IApplicationDB appDB;
		
		public InitModuleOFFICEINTEGRATION(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleOFFICEINTEGRATIONSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleOFFICEINTEGRATIONSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
