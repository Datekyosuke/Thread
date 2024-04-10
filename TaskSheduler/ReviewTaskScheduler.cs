using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TaskSchedulerFunctionality
{
    internal class ReviewTaskScheduler : TaskScheduler
    {
        private readonly LinkedList<Task> taskList = new LinkedList<Task>();    
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return taskList;
        }

        protected override void QueueTask(Task task)
        {
            Console.WriteLine($"    [QueueTask] Задача #{task.Id} поставлена в очередь..");
            taskList.AddLast(task);
            ThreadPool.QueueUserWorkItem(ExecuteTasks, null);
            //ExecuteTasks(null);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            Console.WriteLine($"        [TryExecuteTaskInline] Попытка выполнить задачу #{task.Id} синхронно..");
            lock (taskList)
            {
                taskList.Remove(task);
            }
            return base.TryExecuteTask(task);
        }
        protected override bool TryDequeue(Task task)
        {
            Console.WriteLine($"            [TryDequeue] Попытка удалить задачу {task.Id} из очереди..");
            bool result = false;

            lock(taskList)
            {
                result = taskList.Remove(task);
            }

            if(result == true)
            {
                Console.WriteLine($"                [TryDequeue] Задача {task.Id} была удалена из очереди на выполнение..");
            }
            return result;
        }
        private void ExecuteTasks( object _)
        {
            while(true)
            {
                //Thread.Sleep(2000);
                Task task = null;

                lock (taskList)
                {
                    if (taskList.Count == 0)
                    {
                        break;
                    }
                    task = taskList.First.Value;
                    taskList.RemoveFirst();
                }
                if(task == null)
                {
                    break;
                }
                base.TryExecuteTask(task);
            }
        }
    }
}
