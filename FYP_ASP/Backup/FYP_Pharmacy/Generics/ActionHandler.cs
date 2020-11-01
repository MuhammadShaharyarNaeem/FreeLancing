namespace Generics
{
    public abstract class ActionHandler<T1>
    {
        public MessageCollection MessageCollection = new MessageCollection();
        public abstract void DoAction();
        public abstract void DoFillGridAction();
        public abstract void DoFillBackPanelAction(int ID);
        public abstract void Insert(T1 Model);
        public abstract void Update(T1 Model);
        public abstract void Delete(int ID);
    }
}
