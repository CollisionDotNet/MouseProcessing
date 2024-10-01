namespace MouseProcessing.Domain.BaseTypes
{
    public interface IMapper<T1, T2>
    {
        public T1 Map(T2 obj);
        public T2 Map(T1 obj);
    }
}
