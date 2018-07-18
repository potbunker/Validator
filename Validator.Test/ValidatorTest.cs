using System;
using System.Reactive.Linq;
using NUnit.Framework;

namespace Validator
{
    [TestFixture]
    public class ValidatorTest
    {
        class _validator: Validator<string>
        {
            static VFunc<string> One = s => NO_ERROR;
            static VFunc<string> Two = s => new[] { "Value is invalid" };
            static VFunc<string> Three = s => NO_ERROR;
            static VFunc<string> Four = s => new[] { "Value is invalid" };
            internal _validator()
            {
                All = new[]
                {
                    One, Two, Three, Four
                };
            }
        }
        class Asserter: IObserver<string>
        {
            public virtual void OnCompleted()
            {
                Assert.Pass();
            }

            public virtual void OnError(Exception error)
            {
                throw new NotImplementedException();
            }

            public virtual void OnNext(string value)
            {
                Assert.IsNotNull(value);
            }
        }

        private Validator<string> validator;
        private IObserver<string> observer;
        [OneTimeSetUp]
        public void Init()
        {
            validator = new _validator();
            observer = new Asserter();
        }

        [Test]
        public void TestGoodHeadline()
        {
            validator.Validate("").Take(1).Subscribe(observer);
        }
    }
}
