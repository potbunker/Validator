using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    public delegate string[] VFunc<in T>(T input);
    public delegate string[] VFunc<in T1, in T2>(T1 input1, T2 input2);

    public abstract class BaseValidator
    {
        protected static readonly string[] NO_ERROR = Array.Empty<string>();
    }

    abstract public class Validator<T1, T2>: BaseValidator
    {
        protected VFunc<T1, T2>[] All { get; set; }

        public IObservable<string> Validate(T1 input1, T2 input2)
        {
            return All.ToObservable()
                .SelectMany(func => func(input1, input2));
        }
    }

    abstract public class Validator<T>: BaseValidator
    {
        protected VFunc<T>[] All { get; set; }

        public IObservable<string> Validate(T input)
        {
            return All.ToObservable()
                .SelectMany(func => func(input));
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
