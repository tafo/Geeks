namespace Geeks.Practices.LinkedList.Infrastructure
{
    public class LinkedList<T>
    {
        private readonly bool _isCircular;
        
        public LinkedList(bool isCircular = false)
        {
            _isCircular = isCircular;
        }

        public Node<T> Head;

        /// <summary>
        /// Except Head
        /// </summary>
        public Node<T> Last;

        public void Insert(Node<T> node, T data)
        {
            var newNode = new Node<T>(data) {Next = node.Next};
            node.Next = newNode;
            if (node == Last)
            {
                Last = newNode;
            }
        }

        public void Prepend(T data)
        {
            var newNode = new Node<T>(data) {Next = Head};
            Head = newNode;
            CheckCircularity();
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

            CheckCircularity();
        }

        private void CheckCircularity()
        {
            if (_isCircular)
            {
                Last.Next = Head;
            }
        }
    }
}