namespace Nancy.Devsum.MessageBoard
{
    using System.Collections;
    using System.Collections.Generic;

    public class InMemoryMessageService : IMessageService
    {
        private readonly IList<MessageModel> cache;

        public InMemoryMessageService()
        {
            this.cache = new List<MessageModel>();
        }

        public IEnumerator<MessageModel> GetEnumerator()
        {
            return this.cache.GetEnumerator();
        }

        public void Add(MessageModel message)
        {
            this.cache.Add(message);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}