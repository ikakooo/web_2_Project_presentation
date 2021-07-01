using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using Backend_WebProject_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace Backend_WebProject_API
{
    public static class Helper


    {
        private static List<TodoItemModel> todoItemModels = new List<TodoItemModel>();


        private static List<ApplicationUserModel> usersList = new List<ApplicationUserModel>();
        private static List<String> usersUUIDList = new List<String>();

        public static bool  IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }


        public static string anscriptUsernameAndPassword(LoginModel UsernameAndPassword)
        {
            const string salt = "ewufbydiwyuabdwnbdjgaedbjaqpoweqweuru3orhsdsdgyuyuyubbhjbhjjnjnplpwqqezuwerhndfsnncxz558dsjioflasxxkjawdjwed939ri2t5y75therw80";

            char[] characters = (UsernameAndPassword.UserName + UsernameAndPassword.Password + salt).ToArray();
            List<char> newcharacters = new List<char>();
            Array.Sort(characters);

            for (int i = 0; i < 128; i++)
            {
                newcharacters.Add(characters[i]);
            }


            return new string(newcharacters.ToArray());

        }

        public static bool isUserLoggedIn(String UUID)
        {
            if (usersUUIDList.Contains(UUID))
            {
                return true;
            }else
            {
                return false;
            }
        }

        public static void registerUserIn(ApplicationUserModel userInfo)
        {

            usersUUIDList.Add(anscriptUsernameAndPassword(new LoginModel()
            {
                UserName = userInfo.UserName,
                Password = userInfo.Password

            }));


        }


        public static void addToDoTaskInList(TodoItemModel todoItemModel)
        {
            todoItemModels.Add(todoItemModel);
        }


        public static List<TodoItemModel> getAllToDoTaskInList(String UUID)
        {

             List<TodoItemModel> filteredtodoItemModels = new List<TodoItemModel>();

            foreach (TodoItemModel Task in todoItemModels)
            {
                if(Task.UUID == UUID)
                {
                    filteredtodoItemModels.Add(Task);
                }

            }

            return filteredtodoItemModels;


        }


        

    


    }
}
