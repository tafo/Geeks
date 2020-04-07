namespace Geeks.Practices.LinkedList.Infrastructure
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Next;
        public Node<T> Pre;

        public Node(T data)
        {
            Data = data;
            Next = null;
            Pre = null;
        }
    }
}