namespace Geeks.Practices.LinkedList.Infrastructure
{
    /// <summary>
    /// Circular and doubly linked list.
    /// </summary>
    public class ThatLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Last { get; set; }

        public void Insert(Node<T> node, T data)
        {
            var newNode = new Node<T>(data) { Next = node.Next, Pre = node };
            node.Next.Pre = newNode;
            node.Next = newNode;
            if (node == Last)
            {
                Last = newNode;
            }
        }

        public void Prepend(T data)
        {
            Head = Add(data);
        }

        public void Append(T data)
        {
            Last = Add(data);
        }

        private Node<T> Add(T data)
        {
            var newNode = new Node<T>(data);
            if (Head == null)
            {
                Last = Head = newNode;
            }

            Head.Pre = newNode;
            newNode.Pre = Last;

            Last.Next = newNode;
            newNode.Next = Head;

            return newNode;
        }
    }
}