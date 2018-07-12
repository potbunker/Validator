using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    public delegate string[] VFunc<in T>(T input);
    public delegate string[] VFunc<in T1, in T2>(T1 input1, T2 input2);

    interface IValidator
    {
    }

    abstract public class Validator<T1, T2>
    {
        protected static readonly string[] NO_ERROR = Array.Empty<string>();
        protected VFunc<T1, T2>[] All { get; set; }

        public string[] ValidateLazy(T1 input1, T2 input2)
        {
            return All.Select(func => func(input1, input2))
                .Where(r => r.Count() != 0)
                .DefaultIfEmpty(NO_ERROR)
                .FirstOrDefault();
        }

        public string[] ValidateEager(T1 input1, T2 input2)
        {
            return All.Select(func => func(input1, input2))
                .Aggregate(new List<string>(), (a, b) => a.Concat(b).ToList())
                .ToArray();
        }
    }

    abstract public class Validator<T>
    {
        protected static readonly string[] NO_ERROR = Array.Empty<string>();
        protected VFunc<T>[] All { get; set; }

        public string[] ValidateLazy(T input)
        {
            return All.Select(func => func(input))
                .Where(r => r.Count() != 0)
                .DefaultIfEmpty(NO_ERROR)
                .FirstOrDefault();
        }

        public string[] ValidateEager(T input)
        {
            return All.Select(func => func(input))
                .Aggregate(new List<string>(), (a, b) => a.Concat(b).ToList())
                .ToArray();
        }
    }

    class BitValidator: Validator<Bit>
    {
        static IDictionary<string, string[]> ERRORS = new Dictionary<string, string[]>()
        {
            { "GoodHeadline", new [] { "Headline cannot be empty." } }
        };

        public static readonly VFunc<Bit> Authors = bit =>
        {
            return NO_ERROR;
        };

        public static readonly VFunc<Bit> GoodHeadline = bit =>
        {
            return string.IsNullOrWhiteSpace(bit.Headline)
                ? ERRORS[System.Reflection.MethodBase.GetCurrentMethod().Name]
                : NO_ERROR;
        };

        BitValidator()
        {
            All = new[] {
                Authors,
                GoodHeadline
            };
        }
    }
}
