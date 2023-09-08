using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IXmlStringToDictionaryConvertor
    {
        Dictionary<string, object> ConvertXmlStringToImportDataDictionary(
            string site,
            string tableName,
            int? tableLevel,
            string xmlString);

        (Dictionary<string, string> NullableForeignColumns, Dictionary<string, object>
            NullableForeignKeys, string WhereClause)
            ConvertXmlStringToUpdateDataDictionary(
                string site,
                string tableName,
                string xmlString);
    }

    public class XmlStringToDictionaryConvertor : IXmlStringToDictionaryConvertor
    {
        private readonly ITmpSiteMgmtTableDataCRUD _tmpSiteMgmtTableDataCRUD;
        private readonly IWhereClauseForUpdate _whereClauseForUpdate;
        private readonly INullableForeignKeyHandler _nullableForeignKeyHandler;

        public XmlStringToDictionaryConvertor(
            ITmpSiteMgmtTableDataCRUD tmpSiteMgmtTableDataCRUD,
            IWhereClauseForUpdate whereClauseForUpdate,
            INullableForeignKeyHandler nullableForeignKeyHandler)
        {
            _tmpSiteMgmtTableDataCRUD = tmpSiteMgmtTableDataCRUD;
            _whereClauseForUpdate = whereClauseForUpdate;
            _nullableForeignKeyHandler = nullableForeignKeyHandler;
        }

        public Dictionary<string, object> ConvertXmlStringToImportDataDictionary(
            string site,
            string tableName,
            int? tableLevel,
            string xmlString)
        {
            var xmlElement = XElement.Parse(xmlString);
            var rootElement = xmlElement.Descendants().First();

            if (tableLevel != 0)
            {
                var tableNullableForeignKey =
                    _tmpSiteMgmtTableDataCRUD.ReadTableNullableForeignKey(site, tableName)
                        .Split(',').ToDictionary(key => key, value => value);
                var a = string.Compare("null", "null", true) == 0 ? 0 : 1;

                return rootElement.Elements()
                    .ToDictionary(
                        el => XmlConvert.DecodeName(el.Name.LocalName),
                        el => _nullableForeignKeyHandler.SetNullableForeignKeyToEmpty(
                            el,
                            tableNullableForeignKey));
            }

            return rootElement.Elements()
                .ToDictionary(
                    el => XmlConvert.DecodeName(el.Name.LocalName),
                    el => el.Name.LocalName == "RowPointer"
                        ? Guid.Parse(el.Value)
                        : string.Compare(el.Value, "null", true) == 0 ? null : (object)el.Value
                        );
        }

        public (Dictionary<string, string> NullableForeignColumns, Dictionary<string, object>
            NullableForeignKeys, string WhereClause)
            ConvertXmlStringToUpdateDataDictionary(
                string site,
                string tableName,
                string xmlString)
        {
            var xmlElement = XElement.Parse(xmlString);
            var rootElement = xmlElement.Descendants().First();

            var row = rootElement.Elements()
                .ToDictionary(
                    el => XmlConvert.DecodeName(el.Name.LocalName),
                    el => el.Name.LocalName == "RowPointer"
                        ? Guid.Parse(el.Value)
                        : (object)el.Value);

            var foreignKeys =
                _tmpSiteMgmtTableDataCRUD.ReadTableNullableForeignKey(site, tableName);

            var tableNullableForeignColumns = foreignKeys
                .Split(',').ToDictionary(key => key, key => key);

            var tableNullableForeignKeys = foreignKeys
                .Split(',').ToDictionary(key => key, key => row[key]);

            var whereClause = _whereClauseForUpdate.GetWhereClauseForUpdate(tableName, row);

            return (tableNullableForeignColumns, tableNullableForeignKeys, whereClause);
        }
    }
}