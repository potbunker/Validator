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
        public Main()
        {
            var layout = Observable.FromEventPattern<ControlEventHandler, ControlEventArgs>(h => ControlAdded += h, h => ControlAdded -= h);
            layout.Subscribe(_ => DoSomething(_.EventArgs));
            InitializeComponent();
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
