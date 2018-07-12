using System;
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


        [Test]
        public void TestGoodHeadline()
        {
            
            Assert.True(new _validator().ValidateLazy("").Length == 1);
            Assert.True(new _validator().ValidateEager("").Length == 2);
        }
    }
}
