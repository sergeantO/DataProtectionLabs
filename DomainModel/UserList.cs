using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MVP.DomainModel
{
    public class UserList
    {
        List<User> _users = new List<User>();
        string _fileName;
        XmlSerializer formatter = new XmlSerializer(typeof(List<User>));

        public UserList(string fileName)
        {
            _fileName = fileName;
            Load();
        }

        public void Save()
        {
            // сериализация
            using (FileStream fs = new FileStream($"{_fileName}.xml", FileMode.Create))
            {
                formatter.Serialize(fs, _users);
            }
        }

        public void Load()
        {
            // десериализация
            using (FileStream fs = new FileStream($"{_fileName}.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    _users = (List<User>)formatter.Deserialize(fs);
                }
                catch
                {
                    _users = new List<User>();
                    Add("ADMIN");
                }

            }
        }

        public User Find(string name)
        {
            foreach (User user in _users)
            {
                if (user.Name == name)
                {
                    return user;
                }
            }
            return null;
        }

        public List<User> Data()
        {
            return _users;
        }

        public void Add(string name)
        {
            if (Find(name) != null)
            {
                throw new Exception($"Имя \"{name}\" уже занято");
            }

            User newUser = new User
            {
                Name = name
            };

            _users.Add(newUser);
        }
    }
}
