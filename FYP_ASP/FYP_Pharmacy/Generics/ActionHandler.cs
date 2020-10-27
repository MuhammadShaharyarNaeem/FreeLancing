namespace Generics
{
    public abstract class ActionHandler
    {
        public MessageCollection MessageCollection = new MessageCollection();
        public abstract void DoAction();
    }
}
