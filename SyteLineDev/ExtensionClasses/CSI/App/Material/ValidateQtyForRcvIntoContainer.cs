//PROJECT NAME: Material
//CLASS NAME: ValidateQtyForRcvIntoContainer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IValidateQtyForRcvIntoContainer
	{
		(int? ReturnCode, string Infobar) ValidateQtyForRcvIntoContainerSp(string PItem,
		string PWhse,
		string PLoc,
		string PLot,
		string PSite = null,
		string Infobar = null);
	}
	
	public class ValidateQtyForRcvIntoContainer : IValidateQtyForRcvIntoContainer
	{
		readonly IApplicationDB appDB;
		
		public ValidateQtyForRcvIntoContainer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ValidateQtyForRcvIntoContainerSp(string PItem,
		string PWhse,
		string PLoc,
		string PLot,
		string PSite = null,
		string Infobar = null)
		{
			ItemType _PItem = PItem;
			WhseType _PWhse = PWhse;
			LocType _PLoc = PLoc;
			LotType _PLot = PLot;
			SiteType _PSite = PSite;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateQtyForRcvIntoContainerSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
