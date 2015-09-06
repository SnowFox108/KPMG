namespace KPMG.Infrasructure.Adapter.Mapping
{
    public interface IMapperAdapter
    {
        TTarget Adapt<TSource, TTarget>(TSource source)
            where TTarget : class,new()
            where TSource : class;

        TTarget Adapt<TTarget>(object source)
            where TTarget : class,new();
    }
}
