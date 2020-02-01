using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public interface ILoadManager
{
    ILoadableObject Read(IloadableObjectLoader loader);
}

public interface ILoadableObject { }

public interface IloadableObjectLoader
{
    ILoadObject load(ILoadManager man);
    //ILoadableObject Load(LoadManager loadManager);//todo Load
}

public interface ILoadObject
{
    void Load();
    bool TryLoad();
}

class LoadManager : ILoadManager
{
    public ILoadableObject Read(IloadableObjectLoader loader)//todo Load
    {
        throw new NotImplementedException();
        //return loader.Load(this);
    }

    //public class Loader : ILoadableObject
    //{
    //    public Loader() { }
    //    public ILoadableObject Load(ILoadManager man)
    //    {
    //        return new Player(man);
    //    }
    //}

}