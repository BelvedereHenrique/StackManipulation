using System;

namespace Stack
{
    public class Stack
    {
        private int[] _myStack;
        private int _nextFreeIndex;
        private int[] _minStack;
        private int _lastMinIndex;
        
        public Stack()
        {
            _myStack = new int[0];
            _minStack = new int[0];
            _nextFreeIndex = 0;
            _lastMinIndex = 0;
        }

        //O(n)
        public void Push(int value)
        {

            try
            {
                if (_nextFreeIndex == _myStack.Length)
                    Array.Resize(ref _myStack, _myStack.Length + 1);

                if (_nextFreeIndex == 0)
                {
                    Array.Resize(ref _minStack, 1);
                    _minStack[0] = value;
                    _myStack[_nextFreeIndex++] = value;
                    return;
                }

                _myStack[_nextFreeIndex++] = value;

                if (_myStack[_nextFreeIndex - 1] <= _minStack[_lastMinIndex])
                {
                    _lastMinIndex++;

                    if (_lastMinIndex == _minStack.Length)
                        Array.Resize(ref _minStack, _minStack.Length + 1);

                    _minStack[_lastMinIndex] = value;
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("The stack is full.");
            }
        }

        //O(n)
        public int Pop()
        {
            if (_nextFreeIndex == 0)
                throw new InvalidOperationException("Empty stack.");

            _nextFreeIndex--;

            int returnValue = _myStack[_nextFreeIndex];

            if (returnValue == _minStack[_lastMinIndex])
            {
                if (_lastMinIndex == 0)
                {
                    Array.Resize(ref _minStack, 0);
                    _lastMinIndex = 0;
                }
                else
                {
                    Array.Resize(ref _minStack, _minStack.Length - 1);
                    _lastMinIndex--;
                }

            }

            if (_myStack.Length == 1)
                Array.Resize(ref _myStack, 0);
            else if (_myStack.Length > 1)
                Array.Resize(ref _myStack, _myStack.Length - 1);

            return returnValue;
        }

        //O(1)
        public int Min()
        {
            try
            {
                return _minStack[_lastMinIndex];
            }
            catch (IndexOutOfRangeException)
            {
                return -1;
            }
        }

        public int[] GetFullStack()
        {
            return _myStack;
        }
    }
}
