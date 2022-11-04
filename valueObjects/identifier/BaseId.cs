namespace president.valueObjects.identifier
{
    public abstract class BaseId : IValueObject
    {
        private readonly Guid value;

        protected BaseId(Guid value)
        {
            this.value = value;
        }

        public String Value
        {
            get { return value.ToString(); }
        }

        // public override Boolean Equals(Object? o)
        // {
        //     if(this == o) return true;
        //     if(o == null || GetType() != o.GetType()) return false;
        //     BaseId baseId = (BaseId) o;
        //     return value.Equals(baseId.value);
        // }

        // public override int GetHashCode()
        // {
        //     return value.GetHashCode();
        // }
    }
}