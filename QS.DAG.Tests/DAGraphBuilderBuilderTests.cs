using QS.DAG.Config;
using QS.DAG.Core;
using QS.Reactive.Flow;
using QS.Reactive.Util;

namespace QS.DAG.Tests
{
    internal class DAGraphBuilderBuilderTests
    {
        class DAGListener(Action<INode, INode> onVisitNode, Action onStart, Action onEnd) : DAGraphListenerAdapter
        {
            readonly Action onStart = onStart;
            readonly Action onEnd = onEnd; 
            readonly Action<INode, INode> onVisitNode = onVisitNode;

            public override void OnVisitNode(INode currentNode, INode nextNode)
            {
                onVisitNode?.Invoke(currentNode, nextNode);
            }
            public override void OnStart()
            {
                onStart?.Invoke();
            }
            public override void OnEnd()
            {
                onEnd?.Invoke();
            }
        }

        //var modelBuilder = new DAGra
        [Test]
        public void Test()
        {
            int nStartCalled = 0;
            int nVisitCalled = 0;
            int nEndCalled = 0; 
            var builder = new DAGraphBuilder();
            builder.WithModel()
                .WithNode()
                    .Id("aaa")
                    .UserData(1)
                    .WithNext()
                        .UserData(2);
            builder.WithConfiguration()
                .Id("dag")
                .Listener(new DAGListener((p,n)=>nVisitCalled++, ()=>nStartCalled++, ()=>nEndCalled++));

            var dag = builder.Build();
            dag.Start().Subscribe();
            Assert.Multiple(() =>
            {
                Assert.That(dag.GetCurrentNode().UserData, Is.EqualTo(1));
                Assert.That(dag.IsStarted(), Is.True);
            });


            var msg = new Message();
            dag.Forward(Flow<IMessage>.Just(msg)).Subscribe();
            Assert.Multiple(() =>
            {
                Assert.That(dag.GetCurrentNode().UserData, Is.EqualTo(2));
                Assert.That(!dag.IsCompleted(), Is.True);
                Assert.That(dag.GetCurrentNode().IsEntry == false, Is.True);
            });
            dag.Forward(Flow<IMessage>.Just(msg)).Subscribe();

            Assert.Multiple(() =>
            {
                Assert.That(dag.IsCompleted(), Is.True);
                Assert.That(dag.GetCurrentNode(), Is.Null);
                Assert.That(nVisitCalled, Is.EqualTo(2));
                Assert.That(nStartCalled, Is.EqualTo(1));
                Assert.That(nEndCalled, Is.EqualTo(1));
            });

        }

    }
}
