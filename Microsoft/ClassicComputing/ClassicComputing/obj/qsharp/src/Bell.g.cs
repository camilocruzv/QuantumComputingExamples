#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("Quantum.ClassicComputing", "Set (desired : Result, q1 : Qubit) : ()", new string[] { }, "C:\\Users\\sony6\\source\\repos\\ClassicComputing\\ClassicComputing\\Bell.qs", 172L, 7L, 5L)]
[assembly: OperationDeclaration("Quantum.ClassicComputing", "BellTest (count : Int, initial : Result) : (Int, Int)", new string[] { }, "C:\\Users\\sony6\\source\\repos\\ClassicComputing\\ClassicComputing\\Bell.qs", 407L, 20L, 5L)]
#line hidden
namespace Quantum.ClassicComputing
{
    public class Set : Operation<(Result,Qubit), QVoid>, ICallable
    {
        public Set(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Result,Qubit)>, IApplyData
        {
            public In((Result,Qubit) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits
            {
                get
                {
                    yield return Data.Item2;
                }
            }
        }

        String ICallable.Name => "Set";
        String ICallable.FullName => "Quantum.ClassicComputing.Set";
        protected ICallable<Qubit, Result> M
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get;
            set;
        }

        public override Func<(Result,Qubit), QVoid> Body => (__in) =>
        {
            var (desired,q1) = __in;
#line 10 "C:\\Users\\sony6\\source\\repos\\ClassicComputing\\ClassicComputing\\Bell.qs"
            var current = M.Apply(q1);
#line 12 "C:\\Users\\sony6\\source\\repos\\ClassicComputing\\ClassicComputing\\Bell.qs"
            if ((desired != current))
            {
#line 14 "C:\\Users\\sony6\\source\\repos\\ClassicComputing\\ClassicComputing\\Bell.qs"
                MicrosoftQuantumPrimitiveX.Apply(q1);
            }

#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.MicrosoftQuantumPrimitiveX = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.X));
        }

        public override IApplyData __dataIn((Result,Qubit) data) => new In(data);
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Result desired, Qubit q1)
        {
            return __m__.Run<Set, (Result,Qubit), QVoid>((desired, q1));
        }
    }

    public class BellTest : Operation<(Int64,Result), (Int64,Int64)>, ICallable
    {
        public BellTest(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Int64,Result)>, IApplyData
        {
            public In((Int64,Result) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        public class Out : QTuple<(Int64,Int64)>, IApplyData
        {
            public Out((Int64,Int64) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        String ICallable.Name => "BellTest";
        String ICallable.FullName => "Quantum.ClassicComputing.BellTest";
        protected Allocate Allocate
        {
            get;
            set;
        }

        protected ICallable<Qubit, Result> M
        {
            get;
            set;
        }

        protected Release Release
        {
            get;
            set;
        }

        protected ICallable<(Result,Qubit), QVoid> Set
        {
            get;
            set;
        }

        public override Func<(Int64,Result), (Int64,Int64)> Body => (__in) =>
        {
            var (count,initial) = __in;
#line 23 "C:\\Users\\sony6\\source\\repos\\ClassicComputing\\ClassicComputing\\Bell.qs"
            var numOnes = 0L;
#line 24 "C:\\Users\\sony6\\source\\repos\\ClassicComputing\\ClassicComputing\\Bell.qs"
            var qubits = Allocate.Apply(1L);
#line 26 "C:\\Users\\sony6\\source\\repos\\ClassicComputing\\ClassicComputing\\Bell.qs"
            foreach (var test in new Range(1L, count))
            {
#line 28 "C:\\Users\\sony6\\source\\repos\\ClassicComputing\\ClassicComputing\\Bell.qs"
                Set.Apply((initial, qubits[0L]));
#line 30 "C:\\Users\\sony6\\source\\repos\\ClassicComputing\\ClassicComputing\\Bell.qs"
                var res = M.Apply(qubits[0L]);
                // Count the number of ones we saw:
#line 33 "C:\\Users\\sony6\\source\\repos\\ClassicComputing\\ClassicComputing\\Bell.qs"
                if ((res == Result.One))
                {
#line 35 "C:\\Users\\sony6\\source\\repos\\ClassicComputing\\ClassicComputing\\Bell.qs"
                    numOnes = (numOnes + 1L);
                }
            }

#line 38 "C:\\Users\\sony6\\source\\repos\\ClassicComputing\\ClassicComputing\\Bell.qs"
            Set.Apply((Result.Zero, qubits[0L]));
#line hidden
            Release.Apply(qubits);
            // Return number of times we saw a |0> and number of times we saw a |1>
#line 41 "C:\\Users\\sony6\\source\\repos\\ClassicComputing\\ClassicComputing\\Bell.qs"
            return ((count - numOnes), numOnes);
        }

        ;
        public override void Init()
        {
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
            this.Set = this.Factory.Get<ICallable<(Result,Qubit), QVoid>>(typeof(Quantum.ClassicComputing.Set));
        }

        public override IApplyData __dataIn((Int64,Result) data) => new In(data);
        public override IApplyData __dataOut((Int64,Int64) data) => new Out(data);
        public static System.Threading.Tasks.Task<(Int64,Int64)> Run(IOperationFactory __m__, Int64 count, Result initial)
        {
            return __m__.Run<BellTest, (Int64,Result), (Int64,Int64)>((count, initial));
        }
    }
}