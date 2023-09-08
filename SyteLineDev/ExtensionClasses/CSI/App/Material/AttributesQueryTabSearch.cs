//PROJECT NAME: CSIMaterial
//CLASS NAME: AttributesQueryTabSearch.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IAttributesQueryTabSearch
    {
        int AttributesQueryTabSearchSp(AttributeGroupClassType AttrGroupClass,
                                       StringType SearchStr,
                                       StringType CriteriaSepa,
                                       ref StringType RowPointerStr,
                                       ref InfobarType Infobar);
    }

    public class AttributesQueryTabSearch : IAttributesQueryTabSearch
    {
        readonly IApplicationDB appDB;

        public AttributesQueryTabSearch(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AttributesQueryTabSearchSp(AttributeGroupClassType AttrGroupClass,
                                              StringType SearchStr,
                                              StringType CriteriaSepa,
                                              ref StringType RowPointerStr,
                                              ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AttributesQueryTabSearchSp";

                appDB.AddCommandParameter(cmd, "AttrGroupClass", AttrGroupClass, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SearchStr", SearchStr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CriteriaSepa", CriteriaSepa, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RowPointerStr", RowPointerStr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
