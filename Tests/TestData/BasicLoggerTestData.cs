using Singleton;
using System.Collections;
using System.Collections.Generic;

namespace Tests.TestData
{
    internal class BasicLoggerTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { BasicLogger.Instance };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
