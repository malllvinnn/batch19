namespace LearnGenerics
{
    class Stack<T>
    {
        private int _position;
        T[] _data = new T[100];

        public void Push(T obj)
        {
            _data[_position++] = obj;
        }

        public T Pop()
        {
            return _data[--_position];
        }
    }
}