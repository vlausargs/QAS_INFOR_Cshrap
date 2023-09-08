//PROJECT NAME: CSICustomer
//CLASS NAME: COHeaderWarehouseChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICOHeaderWarehouseChange
	{
		int COHeaderWarehouseChangeSp(string StartingCONum,
		                              string EndingCONum,
		                              string OldWhse,
		                              string NewWhse,
		                              ref string Infobar);
	}
	
	public class COHeaderWarehouseChange : ICOHeaderWarehouseChange
	{
		readonly IApplicationDB appDB;
		
		public COHeaderWarehouseChange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int COHeaderWarehouseChangeSp(string StartingCONum,
		                                     string EndingCONum,
		                                     string OldWhse,
		                                     string NewWhse,
		                                     ref string Infobar)
		{
			CoNumType _StartingCONum = StartingCONum;
			CoNumType _EndingCONum = EndingCONum;
			WhseType _OldWhse = OldWhse;
			WhseType _NewWhse = NewWhse;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "COHeaderWarehouseChangeSp";
				
				appDB.AddCommandParameter(cmd, "StartingCONum", _StartingCONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCONum", _EndingCONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldWhse", _OldWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewWhse", _NewWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
