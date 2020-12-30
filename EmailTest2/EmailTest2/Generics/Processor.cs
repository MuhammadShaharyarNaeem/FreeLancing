namespace EmailingProject.Generics
{
    public abstract class Processor
    {
        public MessageCollection messageCollection;
        protected Processor(MessageCollection messageCollection)
        {
            this.messageCollection = messageCollection;
        }

    }
}
