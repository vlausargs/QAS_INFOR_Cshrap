using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CSI.Data.RecordSets
{
    public class LeftOuterJoinViaScan
    {
        public IRecordCollection Join(
            IRecordCollection left,
            IRecordCollection right,
            IEnumerable<string> requestedColumns,
            IEnumerable<KeyValuePair<string, string>> leftReferenceToRight)
        {
            var requestedColumnsOnLeft = left.Columns.Intersect(requestedColumns);
            var requestedColumnsOnRight = right.Columns.Intersect(requestedColumns);

            var ambiguous = requestedColumnsOnLeft.Intersect(requestedColumnsOnRight);
            if (ambiguous.Count() != 0)
                throw new Exception(string.Format("Ambiguous column(s) found in both collections: {0}", string.Join(", ", ambiguous))); ;

            var missing = requestedColumns.Except(requestedColumnsOnLeft).Except(requestedColumnsOnRight);
            if (missing.Count() != 0)
                throw new Exception(string.Format("Requested column(s) not found: {0}", string.Join(", ", missing)));

            var records = new List<Dictionary<string, object>>();

            //perform the join for every record on the left
            foreach (IRecord l in left)
            {
                var leftRecord = l as IRecordInternal;
                if (leftRecord is null)
                    throw new Exception("Internal error: IRecordInternal not implemented");

                bool foundOne = false;
                var record = new Dictionary<string, object>();
              
                //scan the right for matches
                foreach (IRecord r in right)
                {
                    var rightRecord = r as IRecordInternal;
                    if (rightRecord is null)
                        throw new Exception("Internal error: IRecordInternal not implemented");

                    if (matches(leftRecord, rightRecord, leftReferenceToRight))
                    {
                        foundOne = true;
                        foreach (var column in requestedColumnsOnLeft)
                            record[column] = leftRecord.GetValue(column);
                        foreach (var column in requestedColumnsOnRight)
                            record[column] = rightRecord.GetValue(column);
                        records.Add(record);
                    }
                }

                if (!foundOne)
                {
                    //since this is an OUTER, we need a null record
                    foreach (var column in requestedColumnsOnLeft)
                        record[column] = leftRecord.GetValue(column);
                    foreach (var column in requestedColumnsOnRight)
                        record[column] = null; 
                    records.Add(record);
                }
            }

            return RecordCollection.Create(requestedColumns, records);
        }

        bool matches(
            IRecord leftRecord, IRecord rightRecord,
            IEnumerable<KeyValuePair<string, string>> leftRefersToRight)
        {
            var leftRecordInternal = leftRecord as IRecordInternal;
            var rightRecordInternal = rightRecord as IRecordInternal;

            foreach (var reference in leftRefersToRight)
            {
                if (!leftRecordInternal.GetValue(reference.Key).Equals(rightRecordInternal.GetValue(reference.Value)))
                    return false;
            }

            return true;
        }
    }
}
