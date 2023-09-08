//PROJECT NAME: CSIMaterial
//CLASS NAME: IsShipmentShipped.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IIsShipmentShipped
	{
		(int? ReturnCode, byte? Shipped, string Infobar) IsShipmentShippedSp(string ParentContainerNum,
		byte? Shipped = (byte)0,
		string Infobar = null);
	}
	
	public class IsShipmentShipped : IIsShipmentShipped
	{
		readonly IApplicationDB appDB;
		
		public IsShipmentShipped(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? Shipped, string Infobar) IsShipmentShippedSp(string ParentContainerNum,
		byte? Shipped = (byte)0,
		string Infobar = null)
		{
			ContainerNumType _ParentContainerNum = ParentContainerNum;
			ListYesNoType _Shipped = Shipped;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IsShipmentShippedSp";
				
				appDB.AddCommandParameter(cmd, "ParentContainerNum", _ParentContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Shipped", _Shipped, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Shipped = _Shipped;
				Infobar = _Infobar;
				
				return (Severity, Shipped, Infobar);
			}
		}
	}
}
