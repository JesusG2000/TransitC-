using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service.Impl
{
    public class UserService : IUserService
    {
        private readonly AppDbContext context;
        private const string strPermutation = "ouiveyxaqtd";
        private const int bytePermutation1 = 0x19;
        private const int bytePermutation2 = 0x59;
        private const int bytePermutation3 = 0x17;
        private const int bytePermutation4 = 0x41;

        public UserService(AppDbContext context)
        {
            this.context = context;
        }

        public User Create(User t)
        {
            t.Password = Encrypt(t.Password);
            context.User.Add(t);

            context.SaveChanges();
            return t;
        }

        public void Delete(int id)
        {
            context.User.Remove(context.User.Find(id));
            context.SaveChanges();
        }

        public void Delete(User t)
        {
            context.User.Remove(t);
            context.SaveChanges();
        }

        public User Read(int id)
        {
            return context.User.Find(id);
        }

        public User Update(User t)
        {
            User user = context.User.Find(t.Id);
            if (user != null)
            {
                context.User.Update(t);
                context.SaveChanges();
                return user;
            }
            return null;

        }
        private string Encrypt(string strData)
        { 
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));
        }
        private string Decrypt(string strData)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(strData)));
        }
        private byte[] Encrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(strPermutation,
            new byte[] {bytePermutation1,
                         bytePermutation2,
                        bytePermutation3,
                         bytePermutation4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }
        private byte[] Decrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(strPermutation,
            new byte[] { bytePermutation1,
                         bytePermutation2,
                         bytePermutation3,
                         bytePermutation4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateDecryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }

        public bool IsExist(User user)
        {
            return context.User.Any(u => u.Login == user.Login);
        }

        public User GetByLogin(string login)
        {
            return context.User.First(u => u.Login == login);
        }

        public User GetByLoginAndPassword(string login, string password)
        {
            User user = context.User.First(u => u.Login == login && u.Password == Encrypt(password));
            user.Role = context.UserRole.Find(user.RoleId);
            return user;
        }

        public List<User> GetAll()
        {
            return context.User.ToList();
        }
    }
}
