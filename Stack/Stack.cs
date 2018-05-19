using System;
using System.Collections.Generic;

namespace Stack
{
    public class Stack
    {

        public LinkedList<int> stack { get; }
        LinkedList<int> minStack;

        public Stack()
        {
            stack = new LinkedList<int>();
            minStack = new LinkedList<int>();
        }

        public void Push(int value)
        {
            stack.AddLast(value);
            if (minStack.Count == 0)
            {
                minStack.AddLast(value);
                return;
            }

            if (minStack.Count > 0 && minStack.Last.Value >= value)
                minStack.AddLast(value);
        }

        public int Pop()
        {
            if (stack.Count == 0)
                throw new InvalidOperationException("Empty stack.");

            if (stack.Last.Value == minStack.Last.Value)
                minStack.RemoveLast();

            var lastItem = stack.Last.Value;

            stack.RemoveLast();

            return lastItem;
        }

        public int Min()
        {
            if (minStack.Count == 0)
                throw new InvalidOperationException("There is no minimum value");

            return minStack.Last.Value;
        }
    }
}
