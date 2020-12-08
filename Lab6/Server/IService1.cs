using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server_1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void ConnectionInfo(string name, string port, string localPath, string uri, string scheme);

        [OperationContract]
        void DoWork();

        [OperationContract]
        DataTable GetData();

        [OperationContract]
        DataTable GetComboValue();

        [OperationContract]
        void NewRec(string auto, string work, string data);
    }
}
