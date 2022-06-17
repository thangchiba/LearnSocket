using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestSocket
{
    [Serializable]
    public class MessageContent : TransformModel
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

