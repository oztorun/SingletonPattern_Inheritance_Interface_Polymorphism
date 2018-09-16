using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SingletonPattern
{
    public class LoadBalancer
    {
        private static LoadBalancer _instance;
        private static object m_SyncObject = new object();
        private List<Server> m_ServerList = new List<Server>();

        private LoadBalancer()
        {
            Server server = new Server("10.75.5.1", 10001);
            Server emailServer = new Server("10.75.5.1", 10001);
            Server emailWebServer = new Server("10.75.5.1", 10001);
            Server smsServer = new Server("10.75.5.1", 10001);

            m_ServerList.Add(server);
            m_ServerList.Add(emailServer);
            m_ServerList.Add(emailWebServer);
            m_ServerList.Add(smsServer);
        }
        
        public List<Server> GetServers()
        {
            return m_ServerList;
        }

        public static LoadBalancer Instance()
        {
            if (_instance != null)
                return _instance;

            lock (m_SyncObject)
            {
                if (_instance == null)
                {
                    _instance = new LoadBalancer();
                }
            }
            return _instance;
        }
    }

    public class Server
    {
        private string m_IP;
        private int m_Port;

        public Server(string ip, int port)
        {
            m_IP = ip;
            m_Port = port;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int i = 5;
             Thread thread2 = new Thread(new ThreadStart(executeNewThread));
             thread2.Start();
            
            Console.WriteLine("main thread working");
            LoadBalancer loadBalancer1 = LoadBalancer.Instance();
            //LoadBalancer loadBalancer2 = LoadBalancer.Instance();

            //if (loadBalancer1 == loadBalancer2)
            //{
            //    Console.Write("Nesneler aynı durumda");
            //}

            Console.ReadKey();

        }

        private static void executeNewThread()
        {
            LoadBalancer loadBalancer2 = LoadBalancer.Instance();
        }
    }
}
