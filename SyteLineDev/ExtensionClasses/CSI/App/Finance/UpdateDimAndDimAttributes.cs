//PROJECT NAME: Finance
//CLASS NAME: UpdateDimAndDimAttributes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class UpdateDimAndDimAttributes : IUpdateDimAndDimAttributes
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateDimAndDimAttributes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UpdateDimAndDimAttributesSp(int? Selected,
		string ObjectName,
		string Attribute,
		string DimName,
		string DimDescription,
		int? Required)
		{
			ListYesNoType _Selected = Selected;
			DimensionObjectType _ObjectName = ObjectName;
			DimensionAttributeType _Attribute = Attribute;
			DimensionNameType _DimName = DimName;
			DescriptionType _DimDescription = DimDescription;
			ListYesNoType _Required = Required;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateDimAndDimAttributesSp";
				
				appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ObjectName", _ObjectName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Attribute", _Attribute, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DimName", _DimName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DimDescription", _DimDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Required", _Required, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
