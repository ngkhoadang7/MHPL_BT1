using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;
using BO;

namespace BLL
{
    public class UserBLL
    {
        public static List<User> getAllUser()
        {
            List<User> data = UserDAL.getAllUser();
            return data;
        }
        public List<User> getAllUserExceptMe(int id)
        {
            List<User> data = UserDAL.getAllUserExceptMe(id);
            return data;
        }

        public List<User> getAllUserExceptAdmin()
        {
            List<User> data = UserDAL.getAllUserExceptAdmin();
            return data;
        }

        public static User getUser(int id)
        {
            return UserDAL.getUser(id);
        }

        public static bool addUser(User user)
        {
            user.password = MD5Hash(user.password);

            return UserDAL.addUser(user);
        }

        public static bool editUser(User user)
        {
            user.password = MD5Hash(user.password);

            return UserDAL.editUser(user);
        }

        public static bool deleteUser(int id)
        {
            return UserDAL.deleteUser(id);
        }

        public User login(string email, string password)
        {
            password = MD5Hash(password);

            User user = UserDAL.login(email, password);
            if (user == null)
            {
                return null;
            } 
            else
            {
                return user;
            }
        }

        public static bool isManager(int id)
        {
            return UserDAL.isManager(id);
        }


        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
