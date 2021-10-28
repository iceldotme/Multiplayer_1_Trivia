using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2WebApiCsharp.Logic
{
   
    public class TicTacToe
    {
        private static TicTacToe _instance;
        public static TicTacToe Instance {
            get {
                if (_instance == null) _instance = new TicTacToe();
                return _instance;
            }
        }

        public string boardState = "---------";


        private readonly string[] WinningStates = new string[]{
    "xxx------"
    ,"---xxx---"
        ,"------xxx"
        ,"X--x--x--"
        ,"-x--x--x-"
        ,"--x--x--x"
        ,"x---x---x"
        ,"--x-x-x--"
    };
    }
}