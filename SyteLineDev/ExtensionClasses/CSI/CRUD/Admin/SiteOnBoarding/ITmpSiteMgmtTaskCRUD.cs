using CSI.Data.CRUD;
using System;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITmpSiteMgmtTaskCRUD
    {
        ICollectionLoadResponse LoadTaskToDelete(string site);

        void DeleteTask(ICollectionLoadResponse taskLoadResponse);

        ICollectionLoadResponse ReadAvailableTask(
                string site);

        bool IsExistTask(
            string site,
            string tableName,
            int taskNum,
            string bookmark,
            TaskType taskType);

        ICollectionLoadResponse LoadTaskToCreate(
            string tableName,
            string site,
            int taskNum,
            string errorMsg,
            TaskStatus taskStatus,
            TaskType taskType);

        void CreateTask(ICollectionLoadResponse nonTableLoadResponse);

        string ReadTaskRowPointer(
            string site,
            string tableName,
            int taskNum,
            string bookmark,
            TaskStatus taskStatus,
            TaskType taskType);

        void UpdateTaskStatus(
            string rowPointer,
            TaskStatus taskStatus,
            string errorMsg);

        void UpdateTaskStartTime(string rowPointer, DateTime startTime);

        void UpdateTaskEndTime(string rowPointer, DateTime endTime);

        ICollectionLoadResponse ReadTask(string rowPointer);

        void CreateTaskWithBookmark(string tableName, string site, int taskNum, string bookMark, TaskStatus taskStatus, TaskType taskType);

        void DeleteCompletedTask(string rowPointer);

        bool ReadExistTask(string site);
    }
}