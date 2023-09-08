//PROJECT NAME: Production
//CLASS NAME: WhatIfExpectedReceiptsItemChg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class WhatIfExpectedReceiptsItemChg : IWhatIfExpectedReceiptsItemChg
	{
		readonly IApplicationDB appDB;
		
		
		public WhatIfExpectedReceiptsItemChg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Description) WhatIfExpectedReceiptsItemChgSp(int? AltNo,
		string Item,
		string Description)
		{
			ApsAltNoType _AltNo = AltNo;
			ApsMaterialType _Item = Item;
			ApsDescriptType _Description = Description;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WhatIfExpectedReceiptsItemChgSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Description = _Description;
				
				return (Severity, Description);
			}
		}
	}
}
