//PROJECT NAME: MG.MGCore
//CLASS NAME: IBuildXMLFilterString.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IBuildXMLFilterString
    {
        (int? ReturnCode, string XmlFilterString) BuildXMLFilterStringSp(string PropertyName,
        string Operator = "=",
        string Value = null,
        string DataType = "VeryLongListType",
        string NameInParmList = null,
        int? IsPropertyInWhereClause = 1,
        int? UseSpecifiedDataType = 1,
        int? DataLength = 0,
        string XmlFilterString = null);
    }
}

