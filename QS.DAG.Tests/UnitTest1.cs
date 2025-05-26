using QS.DAG.Core;
using QS.Reactive;
using QS.Reactive.Flow;

namespace QS.DAG.Tests
{
    public class Tests
    {
        DAGraph dag;
        [SetUp]
        public void Setup()
        {
            var entry = new SimpleNode("entry",null, true, null);
            var node = new SimpleNode("node", null, false, null);
            dag = new DAGraph("DAG"
                , [entry, node]
                , new Dictionary<int, IEnumerable<int>>()
                {
                    {0, [1] }
                }, 
                null);
        }

        [Test]
        public void Test1()
        {
            Assert.That(dag.GetCurrentNode(), Is.Null);
            dag.Start().Subscribe();
            Assert.Multiple(() =>
            {
                Assert.That(dag.IsStarted(), Is.True);
                Assert.That(dag.GetCurrentNode(), Is.Not.Null);
            });
            Assert.That(dag.GetCurrentNode().IsEntry, Is.True);

            var msg = new Message();
            dag.Forward(Flow<IMessage>.Just(msg)).Subscribe();
            Assert.Multiple(() =>
            {
                Assert.That(!dag.IsCompleted(), Is.True);
                Assert.That(dag.GetCurrentNode().IsEntry, Is.EqualTo(false));
            });
            dag.Forward(Flow<IMessage>.Just(msg)).Subscribe();
            Assert.That(dag.IsCompleted(), Is.True);

        }
    }
}