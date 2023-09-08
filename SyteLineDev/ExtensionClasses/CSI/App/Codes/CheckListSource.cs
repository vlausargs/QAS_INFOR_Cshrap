//PROJECT NAME: CSICodes
//CLASS NAME: CheckListSource.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public interface ICheckListSource
	{
		int? CheckListSourceSp(string Acct = null,
		                       string Attribute = null,
		                       string Value = null,
		                       string SiteRef = null);
	}
	
	public class CheckListSource : ICheckListSource
	{
		readonly IApplicationDB appDB;
		
		public CheckListSource(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CheckListSourceSp(string Acct = null,
		                              string Attribute = null,
		                              string Value = null,
		                              string SiteRef = null)
		{
			AcctType _Acct = Acct;
			DimensionAttributeType _Attribute = Attribute;
			DimensionValueType _Value = Value;
			SiteType _SiteRef = SiteRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckListSourceSp";
				
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Attribute", _Attribute, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
