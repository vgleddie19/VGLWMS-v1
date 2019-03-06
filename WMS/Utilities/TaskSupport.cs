using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


public class TaskSupport
{
    public List<Action> hourly_tasks = new List<Action>();
    public List<Func<Object>> hourly_functions = new  List<Func<Object>>();
    public Thread thread;

    public void StartTasks()
    {
        thread = new Thread(new ThreadStart(()=> {
            while (true)
            {
                if (DateTime.Now.Minute==1)
                {
                    foreach (var action in hourly_tasks)
                    {
                        action.Invoke();
                    }
                    foreach (var function in hourly_functions)
                    {
                        function.Invoke();
                    }
                }

                Thread.Sleep(1000 * 60);
            }
        }));

        thread.Start();       
    }

}

