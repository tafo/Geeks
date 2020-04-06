using Geeks.Practices.Arrays.Basic;

namespace Geeks.Practices.LinkedList.Infrastructure
{
    public class LinkedList<T>
    {
        public Node<T> Head;

        /// <summary>
        /// Except Head
        /// </summary>
        public Node<T> Last;

        public void Insert(Node<T> node, T data)
        {
            var newNode = new Node<T>(data) {Next = node.Next};
            node.Next = newNode;
        }

        public void Prepend(T data)
        {
            var newNode = new Node<T>(data) {Next = Last};
            Last = newNode;
        }

        public void Append(T data)
        {
            var newNode = new Node<T>(data);
            if (Head == null)
            {
                Last = Head = newNode;
            }
            else
            {
                Last = Last.Next = newNode;
            }
        }
    }
}