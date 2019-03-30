using Singleton;
using System.Collections;
using System.Collections.Generic;

namespace Tests.TestData
{
    internal class StaticLoggerTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { StaticLogger.Instance };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
