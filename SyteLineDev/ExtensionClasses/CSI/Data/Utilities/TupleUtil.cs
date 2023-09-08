using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSI.Data.Utilities
{
    public class TupleUtil: ITupleUtil
    {       
        private const int maxTupleMembers = 7;
        private const int maxTupleArity = maxTupleMembers + 1;
        private readonly Type[] tupleTypes = new[]
        {
            typeof(ValueTuple<>),
            typeof(ValueTuple<,>),
            typeof(ValueTuple<,,>),
            typeof(ValueTuple<,,,>),
            typeof(ValueTuple<,,,,>),
            typeof(ValueTuple<,,,,,>),
            typeof(ValueTuple<,,,,,,>),
            typeof(ValueTuple<,,,,,,,>),
        };
        public object CreateValueTuple(IList<object> values, IEnumerable<Type> returnTupleFieldTypes)
        {
            int numTuples = (int)Math.Ceiling((double)values.Count / maxTupleMembers);

            object currentTuple = null;
            Type currentTupleType = null;

            // We need to work backwards, from the last tuple
            for (int tupleIndex = numTuples - 1; tupleIndex >= 0; tupleIndex--)
            {
                bool hasRest = currentTuple != null;
                int numTupleMembers = hasRest ? maxTupleMembers : values.Count - (maxTupleMembers * tupleIndex);
                int tupleArity = numTupleMembers + (hasRest ? 1 : 0);

                var typeArguments = new Type[tupleArity];
                object[] ctorParameters = new object[tupleArity];
                for (int i = 0; i < numTupleMembers; i++)
                {
                    ctorParameters[i] = values[tupleIndex * maxTupleMembers + i];
                    //get the type for each element. So, nullable type value can be supported.
                    typeArguments[i] = returnTupleFieldTypes.ElementAt(tupleIndex * maxTupleMembers + i);//ctorParameters[i].GetType();
                }
                if (hasRest)
                {
                    ctorParameters[ctorParameters.Length - 1] = currentTuple;
                    typeArguments[typeArguments.Length - 1] = currentTupleType;
                }
                currentTupleType = tupleTypes[tupleArity - 1].MakeGenericType(typeArguments);
                currentTuple = currentTupleType.GetConstructors()[0].Invoke(ctorParameters);
            }

            return currentTuple;
        }
        public IList<object> EnumerateValueTuple(object valueTuple)
        {
            var returnList = new List<object>();
            var tuples = new Queue<object>();
            tuples.Enqueue(valueTuple);

            while (tuples.Count > 0 && tuples.Dequeue() is object tuple)
            {
                foreach (var field in tuple.GetType().GetFields())
                {
                    if (field.Name == "Rest")
                        returnList.AddRange(EnumerateValueTuple(field.GetValue(tuple)));
                    else
                        returnList.Add(field.GetValue(tuple));
                }
            }
            return returnList;
        }

        public bool IsTuple(object tuple)
        {
            return tuple?.GetType().Name.Contains("ValueTuple`") ?? false;
        }
    }
}
