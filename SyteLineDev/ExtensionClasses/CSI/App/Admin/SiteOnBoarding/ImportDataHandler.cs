using CSI.Data.Utilities;
using CSI.MG.MGCore;
using System;
using System.Linq;

namespace CSI.Admin.SiteOnBoarding
{
    public class ImportDataHandler : IImportDataHandler
    {
        private readonly IXmlStringToDictionaryConvertor _xmlStringToDictionaryConvertor;
        private readonly IByteArrayToListConvertor _byteArrayToListConvertor;
        private readonly IImportDataCRUD _importDataCRUD;
        private readonly IUnionUtil _unionUtil;
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;
        private readonly ISetTriggerState _setTriggerState;
        private readonly IRestoreTriggerState _restoreTriggerState;

        public ImportDataHandler(
            IXmlStringToDictionaryConvertor xmlStringToDictionaryConvertor,
            IByteArrayToListConvertor byteArrayToListConvertor,
            IImportDataCRUD importDataCRUD,
            IUnionUtil unionUtil,
            ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD,
            ISetTriggerState setTriggerState,
            IRestoreTriggerState restoreTriggerState)
        {
            _xmlStringToDictionaryConvertor = xmlStringToDictionaryConvertor;
            _byteArrayToListConvertor = byteArrayToListConvertor;
            _importDataCRUD = importDataCRUD;
            _unionUtil = unionUtil;
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
            _setTriggerState = setTriggerState;
            _restoreTriggerState = restoreTriggerState;
        }

        public void InsertData(
            byte[] fileContent,
            string site,
            string tableName,
            int? tableLevel,
            string taskRowPointer)
        {
            var bulkList = _byteArrayToListConvertor.ConvertByteArrayToList(fileContent);
            string PreviousState = "";
            string Infobar = "";
            int? ReturnCode = 0;

            try
            {
                foreach (var bulk in bulkList)
                {
                    foreach (var columnDictionary in bulk.Select(
                        content =>
                            _xmlStringToDictionaryConvertor.ConvertXmlStringToImportDataDictionary(
                                site,
                                tableName,
                                tableLevel,
                                content)))
                    {
                        _unionUtil.Add(
                            _importDataCRUD.ReadCollectionLoadResponseForImportData(
                                columnDictionary));
                    }

                    (ReturnCode, PreviousState, Infobar) = _setTriggerState.SetTriggerStateSp(
                        SkipReplicating: 1,
                        SkipBase: 1,
                        ScopeProcess: 1,
                        PreviousState: PreviousState,
                        Infobar: Infobar);

                    _importDataCRUD.InsertImportData(
                        tableName,
                        _unionUtil.Process());

                    (ReturnCode, Infobar) = _restoreTriggerState.RestoreTriggerStateSp(
                        ScopeProcess: 1,
                        SavedState: PreviousState,
                        Infobar: Infobar);

                    _unionUtil.Clear();
                }
            }
            catch (Exception e)
            {
                _tmpSiteMgmtTaskCRUD.UpdateTaskStatus(
                    taskRowPointer,
                    TaskStatus.F,
                    e.Message);
            }
        }

        public void UpdateData(
            byte[] fileContent,
            string site,
            string tableName,
            int? tableLevel,
            string taskRowPointer)
        {
            var bulkList = _byteArrayToListConvertor.ConvertByteArrayToList(fileContent);

            try
            {
                foreach (var bulk in bulkList)
                {
                    // Select PK and nullable FK
                    foreach (var content in bulk)
                    {
                        var (nullableForeignColumns, nullableForeignKeys, whereClause) =
                            _xmlStringToDictionaryConvertor
                                .ConvertXmlStringToUpdateDataDictionary(
                                    site,
                                    tableName,
                                    content);

                        _importDataCRUD.UpdateImportData(
                            tableName,
                            whereClause,
                            nullableForeignColumns,
                            nullableForeignKeys);
                    }
                }
            }
            catch (Exception e)
            {
                _tmpSiteMgmtTaskCRUD.UpdateTaskStatus(
                    taskRowPointer,
                    TaskStatus.F,
                    e.Message);
            }
        }
    }
}