//PROJECT NAME: Data
//CLASS NAME: GetPropertiesByIDO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetPropertiesByIDO : IGetPropertiesByIDO
	{
		readonly IApplicationDB appDB;
		
		public GetPropertiesByIDO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string DynamicSQL) GetPropertiesByIDOSp(
			string DomainIDOName,
			string DomainProperty,
			string DomainListProperty,
			string SiteRef,
			string KeyValue = null,
			string DynamicSQL = null)
		{
			CollectionNameType _DomainIDOName = DomainIDOName;
			CollectionPropertyNameType _DomainProperty = DomainProperty;
			CollectionPropertyNameType _DomainListProperty = DomainListProperty;
			SiteType _SiteRef = SiteRef;
			DimensionValueType _KeyValue = KeyValue;
			NoteType _DynamicSQL = DynamicSQL;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPropertiesByIDOSp";
				
				appDB.AddCommandParameter(cmd, "DomainIDOName", _DomainIDOName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomainProperty", _DomainProperty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomainListProperty", _DomainListProperty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KeyValue", _KeyValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DynamicSQL", _DynamicSQL, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DynamicSQL = _DynamicSQL;
				
				return (Severity, DynamicSQL);
			}
		}
	}
}
