using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FormApp
{
    public partial class Main : Form
    {
        private long _bitslotId;
        public long BitslotId {
            get {
                return _bitslotId; }
            set {
                _bitslotId = value;
            }
        }

        public event EventHandler<EventArgs> BitslotChanged;

        public Main()
        {
            var layout = Observable.FromEventPattern<ControlEventHandler, ControlEventArgs>(
                h => ControlAdded += h, h => ControlAdded -= h)
                .Do(_ => Console.WriteLine($@"Control {_.EventArgs.Control} is layed out."))
                .Subscribe();
            //layout.Subscribe(_ => DoSomething(_.EventArgs));
            InitializeComponent();

            BitslotLinkLabel.Setup();
            Observable.FromEventPattern<EventHandler, EventArgs>(h => this.button1.Click += h, h => this.button1.Click += h)
                .Select(_ => MessageBox.Show("OK Clicked", "MessageBox", MessageBoxButtons.OKCancel))
                .Where(result => result == DialogResult.OK)
                .Do(result => Console.WriteLine(result.Description()))
                .Subscribe();

            Observable.FromEventPattern<EventArgs>(h => BitslotChanged += h, h => BitslotChanged -= h)
                .Do(_1 => Console.WriteLine(@"Bitslot Changed"))
                .Select(_ => 10L)
                .Subscribe((IObserver<long>)BitslotLinkLabel);

            Observable.FromEvent<BitslotLinkLabel>(h => BitslotLinkLabel.CreationRequested += h, h => BitslotLinkLabel.CreationRequested -= h)
                    .Delay(TimeSpan.FromSeconds(1))
                    .Do(_ => _.WithList(new List<string> { }))
                    .Subscribe();

            Observable.FromEventPattern<LinkLabelLinkClickedEventHandler, LinkLabelLinkClickedEventArgs>(
                    h => BitslotLinkLabel.LinkClicked += h, h => BitslotLinkLabel.LinkClicked -= h)
                .Do(_1 => Console.WriteLine(@"LinkLabel clicked"))
                .Do(_1 => BitslotLinkLabel.WithList(new List<string> { }))
                .Do(_ => BitslotChanged(_.Sender, _.EventArgs))
                .Select(_ => 10L)
                .Subscribe();

        }

        private void DoSomething(ControlEventArgs _)
        {
            var panel = Observable.Return(typeof(Status))
                .SelectMany(t => Enum.GetValues(t).Cast<Status>())
                .Zip(ObservableUtils.ToIndex(), (a, b) => Tuple.Create(b, a))
                .Select(x => {
                    var index = x.Item1;
                    var value = x.Item2;
                    var button = new RadioButton()
                    {
                        Name = value.ToString(),
                        Text = value.Description(),
                        Width = _.Control.Width,
                        Top = 24 * index,
                        Checked = index == 1,
                    };
                    return button;
                })
                .Collect<RadioButton, ListBox>(() => new ListBox() {
                    Width = _.Control.Width,
                    Height = _.Control.Height
                }, (f, r) => {
                    f.Controls.Add(r);
                    return f; })
                .First();
            _.Control.Controls.Add(panel);
        }

        private static Func<GroupBox, LayoutEventArgs, object> GetValue = (box, args) =>
        {
            return null;
        };

    }
}
