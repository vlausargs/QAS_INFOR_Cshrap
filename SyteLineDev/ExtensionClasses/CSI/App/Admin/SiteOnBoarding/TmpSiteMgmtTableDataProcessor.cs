using System;
using System.Collections.Generic;
using System.Linq;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITmpSiteMgmtTableDataProcessor
    {
        (bool IsSuccess, string Infobar) CreateTableData(List<(string TableName, string AppViewName, int ReferenceCount, string Referenced)> referencedTableDataTables, string site);
    }

    public class TmpSiteMgmtTableDataProcessor : ITmpSiteMgmtTableDataProcessor
    {
        private readonly ITmpSiteMgmtTableData _tmpSiteMgmtTableData;
        private readonly INullableForeignKeyColumnAcquisition _nullableForeignKeyColumnAcquisition;

        public TmpSiteMgmtTableDataProcessor(ITmpSiteMgmtTableData tmpSiteMgmtTableData,
            INullableForeignKeyColumnAcquisition nullableForeignKeyColumnAcquisition)
        {
            _tmpSiteMgmtTableData = tmpSiteMgmtTableData;
            _nullableForeignKeyColumnAcquisition = nullableForeignKeyColumnAcquisition;
        }

        public (bool IsSuccess, string Infobar) CreateTableData(List<(string TableName, string AppViewName, int ReferenceCount, string Referenced)> referencedTableDataTables, string site)
        {
            foreach (var (appViewName, tableName, referenceCount, referenced) in
                from referencedTable in
                    referencedTableDataTables
                let appViewName = referencedTable.AppViewName
                let tableName = referencedTable.TableName
                let referenceCount = referencedTable.ReferenceCount
                let referenced = referencedTable.Referenced
                select (appViewName, tableName, referenceCount, referenced))
            {
                if (string.IsNullOrWhiteSpace(appViewName))
                {
                    _tmpSiteMgmtTableData.CreateSiteMgmtTableData(tableName,
                        site,
                        "AppViewName is Null",
                        TableStatus.F,
                        0,
                        string.Empty,
                        string.Empty);
                }
                else
                {
                    try
                    {
                        if (appViewName.Contains("_all"))
                            continue;

                        if (referenceCount == 0)
                        {
                            _tmpSiteMgmtTableData.CreateSiteMgmtTableData(appViewName,
                                site,
                                string.Empty,
                                TableStatus.P,
                                referenceCount,
                                referenced,
                                string.Empty);
                        }
                        else
                        {
                            var nullableColumn = _nullableForeignKeyColumnAcquisition.GetNullableForeignKeyColumn(tableName);
                            _tmpSiteMgmtTableData.CreateSiteMgmtTableData(appViewName,
                                site,
                                string.Empty,
                                TableStatus.P,
                                referenceCount,
                                referenced,
                                nullableColumn);
                        }
                    }
                    catch (Exception e)
                    {
                        _tmpSiteMgmtTableData.CreateSiteMgmtTableData(appViewName,
                            site,
                            e.Message,
                            TableStatus.F,
                            0,
                            string.Empty,
                            string.Empty);
                        return (false, e.Message);
                    }
                }
            }
            return (true, "");
        }
    }
}
