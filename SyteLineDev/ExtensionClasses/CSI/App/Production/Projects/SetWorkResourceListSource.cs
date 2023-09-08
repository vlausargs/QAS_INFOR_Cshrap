//PROJECT NAME: Production
//CLASS NAME: SetWorkResourceListSource.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class SetWorkResourceListSource : ISetWorkResourceListSource
	{
		readonly IApplicationDB appDB;
		
		
		public SetWorkResourceListSource(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Ref_num_ido_source,
		string Ref_name_property_source,
		string Ref_num_property_source,
		string ref_num_ido_source_filter,
		string Infobar) SetWorkResourceListSourceSp(string ResourceType,
		string Ref_num_ido_source,
		string Ref_name_property_source,
		string Ref_num_property_source,
		string ref_num_ido_source_filter,
		string Infobar)
		{
			ProjectResourceTypeType _ResourceType = ResourceType;
			CollectionNameType _Ref_num_ido_source = Ref_num_ido_source;
			CollectionPropertyNameType _Ref_name_property_source = Ref_name_property_source;
			CollectionPropertyNameType _Ref_num_property_source = Ref_num_property_source;
			FilterType _ref_num_ido_source_filter = ref_num_ido_source_filter;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetWorkResourceListSourceSp";
				
				appDB.AddCommandParameter(cmd, "ResourceType", _ResourceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Ref_num_ido_source", _Ref_num_ido_source, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Ref_name_property_source", _Ref_name_property_source, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Ref_num_property_source", _Ref_num_property_source, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ref_num_ido_source_filter", _ref_num_ido_source_filter, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Ref_num_ido_source = _Ref_num_ido_source;
				Ref_name_property_source = _Ref_name_property_source;
				Ref_num_property_source = _Ref_num_property_source;
				ref_num_ido_source_filter = _ref_num_ido_source_filter;
				Infobar = _Infobar;
				
				return (Severity, Ref_num_ido_source, Ref_name_property_source, Ref_num_property_source, ref_num_ido_source_filter, Infobar);
			}
		}
	}
}
