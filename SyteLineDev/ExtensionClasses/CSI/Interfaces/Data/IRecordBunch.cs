using CSI.Data.Cache;
using CSI.Data.CRUD;
using System;

namespace CSI.Data
{
    public interface IRecordBunch : IDisposable
    {
        ICollectionLoadResponse CurrentPage { get; }
        bool ReadPage();
        bool EOF { get; }
    }
}
