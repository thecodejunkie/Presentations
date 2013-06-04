namespace Nancy.Devsum.MessageBoard
{
    using System.Collections.Generic;

    public interface IMessageService : IEnumerable<MessageModel>
    {
        void Add(MessageModel message);
    }
}