//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQLinesGenVal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQLinesGenVal : ISSSRFQLinesGenVal
	{
		readonly IApplicationDB appDB;
		
		public SSSRFQLinesGenVal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			string LastRFQNum,
			int? LastRFQLine,
			string ProductCode) SSSRFQLinesGenValSp(
			string Method,
			string Item,
			int? FromGenUtils,
			string Infobar,
			string LastRFQNum = null,
			int? LastRFQLine = null,
			string ProductCode = null)
		{
			StringType _Method = Method;
			ItemType _Item = Item;
			ListYesNoType _FromGenUtils = FromGenUtils;
			Infobar _Infobar = Infobar;
			RFQNumType _LastRFQNum = LastRFQNum;
			RFQLineType _LastRFQLine = LastRFQLine;
			ProductCodeType _ProductCode = ProductCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQLinesGenValSp";
				
				appDB.AddCommandParameter(cmd, "Method", _Method, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromGenUtils", _FromGenUtils, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LastRFQNum", _LastRFQNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LastRFQLine", _LastRFQLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				LastRFQNum = _LastRFQNum;
				LastRFQLine = _LastRFQLine;
				ProductCode = _ProductCode;
				
				return (Severity, Infobar, LastRFQNum, LastRFQLine, ProductCode);
			}
		}
	}
}
