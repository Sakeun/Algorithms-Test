using System.Collections;

namespace MatchingAlgorithms;

// Dit zou voor Service en Repository gemaakt moeten worden
public interface IGenericInterface<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
}

// Mocht er een service of repo zijn met meer functionaliteiten, dan krijgen ze een eigen interface
public interface IConcreteInterface<T>: IGenericInterface<T>
{
    Task<T> AddNew(T obj);
}

// Deze classes zouden dan services en repositories zijn
public class GenericClass: IGenericInterface<Model>
{
    public Task<IEnumerable<Model>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Model> GetById(int id)
    {
        throw new NotImplementedException();
    }
}

public class ConcreteClass : IConcreteInterface<Model>
{
    public Task<IEnumerable<Model>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Model> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Model> AddNew(Model obj)
    {
        throw new NotImplementedException();
    }
}



public class Model
{
    
}