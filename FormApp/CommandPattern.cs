using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp
{
    public interface IRequest
    {
        string getId();
        string getTitle();
    }
    public interface IResponse
    {
        string getId();
        string getTitle();
    }

    public class CommandPattern
    {
        public delegate IObservable<TValue> QueryDelegate<in TWhere, out TValue>(TWhere clause);
        public delegate IObservable<TRequest> ToRequest<in TSource, out TRequest>(TSource source);
        public delegate IObservable<TValue> FromResponse<in TResponse, out TValue>(TResponse response);
        public delegate IObservable<TResponse> CommandDelegate<in TRequest, out TResponse>(TRequest request);

        public delegate IObservable<TValue> QueryPattern<TSource, TRequest, TResponse, TValue>(
            TSource source,
            ToRequest<TSource, TRequest> request,
            QueryDelegate<TRequest, TResponse> query,
            FromResponse<TResponse, TValue> response);

        public QueryPattern<BitslotLinkLabel, 
            ToRequest<BitslotLinkLabel, IRequest>,
            QueryDelegate<IRequest, IResponse>, 
            FromResponse<IResponse, string>> titles = (control, request, query, response) => 
            {
                return Observable.Return(control)
                    .SelectMany(c => request(c)
                        .SelectMany(q => query(q)
                            .SelectMany(r => response(r))));
            };
    }
}
