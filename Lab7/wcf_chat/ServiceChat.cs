using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_chat
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceChat" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        readonly List<ServerUser> Users = new List<ServerUser>();
        private int nextId = 1;
        readonly List<string> messageHistory = new List<string>();

        public int Connect(string name)
        {
            ServerUser user = new ServerUser()
            {
                ID = nextId,
                Name = name,
                OperationContext = OperationContext.Current
            };
            nextId++;
            SendMessage(user.Name+ " подключился к чату!", 0);
            Users.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = Users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                Users.Remove(user);
                SendMessage(user.Name+" покинул чат!",0);
            }
            
        }

        public List<string> GetMessageHistory() => messageHistory;

        public void SendMessage(string message, int id)
        {
            var userSender = Users.FirstOrDefault(i => i.ID == id);
            foreach (var user in Users)
            {
                string answer = DateTime.Now.ToShortTimeString();
                if (userSender != null)
                    answer += ": " + userSender.Name + " ";
                answer +=" "+ message;
                messageHistory.Add(answer);
                user.OperationContext.GetCallbackChannel<IServerChatCallBack>().MessageCallBack(answer);
            }
        }
    }
}
