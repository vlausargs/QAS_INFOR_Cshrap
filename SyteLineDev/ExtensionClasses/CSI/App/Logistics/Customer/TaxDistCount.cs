//PROJECT NAME: Logistics
//CLASS NAME: TaxDistCount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class TaxDistCount : ITaxDistCount
	{
		readonly IApplicationDB appDB;
		
		
		public TaxDistCount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PDistCount,
		string Infobar) TaxDistCountSp(string PCoNum,
		int? PDistCount,
		string Infobar)
		{
			CoNumType _PCoNum = PCoNum;
			IntType _PDistCount = PDistCount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TaxDistCountSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDistCount", _PDistCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PDistCount = _PDistCount;
				Infobar = _Infobar;
				
				return (Severity, PDistCount, Infobar);
			}
		}
	}
}
