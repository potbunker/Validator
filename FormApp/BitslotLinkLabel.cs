using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reactive.Linq;

namespace FormApp
{
    public partial class BitslotLinkLabel : LinkLabel, IObserver<long>
    {
        public BitslotLinkLabel()
        {
            InitializeComponent();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(long value)
        {
            Text = "Updated";
            LinkVisited = false;
        }

        public void Setup()
        {
            Observable.FromEventPattern<PaintEventHandler, EventArgs>(h => this.Paint += h, h => this.Paint -= h)
                .Do(_ => Console.WriteLine(_.EventArgs.ToString()))
                .SelectMany(_ => Observable.Return(this.FindForm()).Cast<Main>()
                    .Do(form => Observable.FromEventPattern<EventArgs>(
                            h => form.BitslotChanged += h, h => form.BitslotChanged -= h)
                        .Do(_1 => Console.WriteLine(@"This is a test")).Subscribe()))
                .Subscribe();

        }
    }
}
