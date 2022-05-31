using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace questao_01
{
    class Context
    {
        private IStrategy isstrategy;

        public Context() { }

        public Context(IStrategy strategy)
        {
            this.isstrategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this.isstrategy = strategy;
        }

        public void MyList()
        {
            var result = this.isstrategy.StrategyInterface(new List<int> { 1, 2, 3, 4, 5 });

            string resultStr = string.Empty;
            foreach (var element in result as List<int>)
            {
                resultStr += element + "  ";
            }

            Console.WriteLine(resultStr);
        }
    }

    public interface IStrategy
    {
        object StrategyInterface(object data);
    }

    class StrategySort : IStrategy
    {
        public object StrategyInterface(object data)
        {
            var list = data as List<int>;
            list.Sort();
            return list;
        }
    }

    class StrategyReverse : IStrategy
    {
        public object StrategyInterface(object data)
        {
            var list = data as List<int>;
            list.Reverse();
            return list;
        }
    }

    class StrategyInsert : IStrategy
    {
        public object StrategyInterface(object data)
        {
            var list = data as List<int>;
            list.Insert(3, 4);
            return list;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            Console.WriteLine("Normal sorting: ");
            context.SetStrategy(new StrategySort());
            context.MyList();

            Console.WriteLine();

            Console.WriteLine("Reverse sorting: ");
            context.SetStrategy(new StrategyReverse());
            context.MyList();

            Console.WriteLine();

            Console.WriteLine("Insert into sequence: ");
            context.SetStrategy(new StrategyInsert());
            context.MyList();
        }
    }
}

