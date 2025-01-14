﻿namespace SpaceObject;
public class SpaceObject
{
}

public class Pool<T> where T : new()
{
    private readonly Queue<T> pool;

    public Pool(int initialCapacity)
    {
        pool = new Queue<T>(initialCapacity);
        for (int i = 0; i < initialCapacity; i++)
        {
            pool.Enqueue(new T());
        }
    }

    public T GetObject()
    {
        if (pool.Count > 0)
        {
            return pool.Dequeue();
        }
        else
        {
            return new T();
        }
    }

    public void ReturnObject(T obj)
    {
        pool.Enqueue(obj);
    }
}

public class PoolGuard<T> : IDisposable where T : new()
{
    private readonly Pool<T> pool;
    private readonly T obj;

    public PoolGuard(Pool<T> pool)
    {
        this.pool = pool;
        obj = pool.GetObject();
    }

    public T Object => obj;

    public void Dispose()
    {
        pool.ReturnObject(obj);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Pool<SpaceObject> spaceObjectPool = new Pool<SpaceObject>(10);
        using (PoolGuard<SpaceObject> guard = new PoolGuard<SpaceObject>(spaceObjectPool))
        {
            SpaceObject spaceObject = guard.Object;
        }
    }
}