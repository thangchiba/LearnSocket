using System;
namespace TestSocket
{
    [Serializable]
    public class MessageContent
    {
        private String name;
        private String content;

        public MessageContent(String name, String content)
        {
            this.name = name;
            this.content = content;
        }

        public string Name { get => name; set => name = value; }
        public string Content { get => content; set => content = value; }
    }
}

