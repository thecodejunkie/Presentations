namespace Nancy.Devsum.MessageBoard
{
    using System;

    public class MessageModel
    {
        public MessageModel()
        {
            this.Posted = DateTime.Now;
        }

        public string Author { get; set; }

        public string Message { get; set; }
        
        public DateTime Posted { get; set; }
    }
}