delegate int AsyncFoo(int i);
    class Program
    {
        /// ﹤summary﹥   
        /// 输出当前线程的信息   
        /// ﹤/summary﹥      
        /// ﹤param name="name"﹥方法名称﹤/param﹥    
        static void PrintCurrThreadInfo(string name)
        {
            Console.WriteLine("Thread Id of " + name + " is: " + Thread.CurrentThread.ManagedThreadId + ", current thread is "
                + (Thread.CurrentThread.IsThreadPoolThread ? "" : "not ") + "thread pool thread.");
        }


        /// ﹤summary﹥   
        /// 测试方法，Sleep一定时间   
        /// ﹤/summary﹥   
        /// ﹤param name="i"﹥Sleep的时间﹤/param﹥   
        static int Foo(int i)
        {
            PrintCurrThreadInfo("Foo()");
            Thread.Sleep(10000);
            return i;
        }


        /// ﹤summary﹥   
        /// 投递一个异步调用   
        /// ﹤/summary﹥   
        static void PostAsync(int i)
        {
            AsyncFoo caller = new AsyncFoo(Foo);
            caller.BeginInvoke(i, new AsyncCallback(FooCallBack), caller);
        }


        static void Main(string[] args)
        {
            PrintCurrThreadInfo("Main()");
            for (int i = 0; i < 5; i++)
            {
                PostAsync(i);
            }
            Console.ReadLine();
        }


        static void FooCallBack(IAsyncResult ar)
        {           
            AsyncFoo caller = (AsyncFoo)ar.AsyncState;
            int i=caller.EndInvoke(ar);
            PrintCurrThreadInfo("FooCallBack() "+i.ToString()+"  ");
        }

    }
