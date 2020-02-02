using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class Logger
//{
//    TextWriter output;
//    public Logger(TextWriter output)
//    {
//        this.output = output;
//    }
//    public virtual void WriteLine(string message)
//    {
//        output.WriteLine(message);
//    }
//}

//class DatedLogger : Logger
//{
//    public DatedLogger(TextWriter output) : base(output) { }
//    public override void WriteLine(string message)
//    {
//        base.WriteLine($"{DateTime.Now} {message}");
//    }
//}

class LoadLogger
{
    LoadManager man;

    public LoadLogger(LoadManager man)
    {
        this.man = man;
        //this.log = log;
        man.ObjectDidLoad += OnObjectLoad;
        //man.DidStartLoad += OnDidStartLoad;
        //man.DidEndLoad += OnDidEndLoad;
    }
    protected virtual void OnObjectLoad(object sender, ILoadableObject obj)
    {
        Debug.Log($"Объект успешно загружен: {obj}");
    }
    protected virtual void OnDidStartLoad(object sender, PlayerPrefs file)
    {
        Debug.Log($"Начата загрузка из файла: {file}");

    }
    protected virtual void OnDidEndLoad(object sender, PlayerPrefs file)
    {
        Debug.Log($"Завершена загрузка из файла: {file}");
    }
    ~LoadLogger()
    {
        man.ObjectDidLoad -= OnObjectLoad;
        //man.DidStartLoad -= OnDidStartLoad;
        //man.DidEndLoad -= OnDidStartLoad;
    }
}
