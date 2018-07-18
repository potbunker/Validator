using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp
{
    enum Status
    {
        [Description("Item is available for Assignment")]
        Available = 0,
        [Obsolete("Obsoleted Enum Value", true)]
        [Description("Item is in process")]
        InProcess = 1,
        [Description("Item is being reviewed")]
        PeerReviewed = 2,
        [Description("Item has been completed.")]
        Completed = 4
    }

    public static class EnumExtension
    {
        public static string Description(this Enum value)
        {
            return value.GetType().GetField(value.ToString())
                .GetCustomAttributes(false)
                .Where(x=> x is DescriptionAttribute)
                .Cast<DescriptionAttribute>()
                .Select(x => x.Description)
                .DefaultIfEmpty(value.ToString())
                .FirstOrDefault();
        }
    }
    public static class ObservableUtils
    {
        public static IObservable<int> ToIndex()
        {
            return Observable.Repeat(1).Scan<int>((a,b) => a + b);
        }
    }
}
